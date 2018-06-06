namespace HTTPServer.ByTheCakeApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HTTPServer.ByTheCakeApplication.Data;
    using HTTPServer.ByTheCakeApplication.Utilities;
    using Infrastructure;
    using Models;
    using Server.Http;
    using Server.Http.Contracts;
    using Server.Http.Response;

    public class AccountController : Controller
    {
        public IHttpResponse Register()
        {
            this.ViewData["showError"] = "none";
            this.ViewData["authDisplay"] = "none";

            return this.FileViewResponse(@"account\register");
        }

        public IHttpResponse Register(IHttpRequest req)
        {
            const string formNameKey = "name";
            const string formUsernameKey = "username";
            const string formPasswordKey = "password";
            const string formConfirmPasswordKey = "confirmPassword";

            if (!req.FormData.ContainsKey(formNameKey)
                || !req.FormData.ContainsKey(formUsernameKey)
                || !req.FormData.ContainsKey(formPasswordKey)
                || !req.FormData.ContainsKey(formConfirmPasswordKey))
            {
                DisplayError("You have wrong fields");
                return this.FileViewResponse(@"account\register");
            }

            string name = req.FormData[formNameKey];
            string username = req.FormData[formUsernameKey];
            string password = req.FormData[formPasswordKey];
            string confirmPassword = req.FormData[formConfirmPasswordKey];

            if (string.IsNullOrWhiteSpace(name) || name.Length < 3
                || string.IsNullOrWhiteSpace(username) || username.Length < 3
                || string.IsNullOrWhiteSpace(password)
                || string.IsNullOrWhiteSpace(confirmPassword))
            {
                DisplayError("You have wrong fields");
                return this.FileViewResponse(@"account\register");
            }

            if (password != confirmPassword)
            {
                return new BadRequestResponse();
            }

            var user = new User()
            {
                Name = name,
                Username = username,
                PasswordHash = PasswordUtilities.GenerateHash(password),
                RegistrationDate = DateTime.UtcNow
            };

            using (this.Context)
            {
                this.Context.Users.Add(user);
                this.Context.SaveChanges();
            }

            CompleteLogin(req, user.Id);
            return new RedirectResponse("/");
        }

        public IHttpResponse Profile(IHttpRequest req)
        {
            int userId = req.Session.Get<int>(SessionStore.CurrentUserKey);
            if (userId != 0)
            {
                User user = null;
                int ordersCount = 0;
                using (this.Context)
                {
                    user = this.Context.Users.Find(userId);
                    ordersCount = this.Context.Orders.Where(o => o.UserId == userId).Count();
                }

                if (user != null)
                {
                    this.ViewData["showResult"] = "block";
                    this.ViewData["name"] = user.Name;
                    this.ViewData["registerDate"] = user.RegistrationDate.ToString("dd-MM-yyy");
                    this.ViewData["ordersCount"] = ordersCount.ToString();

                    return this.FileViewResponse(@"account\profile");
                }
            }

            return new RedirectResponse("/login");
        }

        public IHttpResponse Login()
        {
            this.ViewData["showError"] = "none";
            this.ViewData["authDisplay"] = "none";

            return this.FileViewResponse(@"account\login");
        }

        public IHttpResponse Login(IHttpRequest req)
        {
            const string formNameKey = "name";
            const string formPasswordKey = "password";

            if (!req.FormData.ContainsKey(formNameKey)
                || !req.FormData.ContainsKey(formPasswordKey))
            {
                this.DisplayError("You have empty fields");
                return this.FileViewResponse(@"account\login");
            }

            var name = req.FormData[formNameKey];
            var password = req.FormData[formPasswordKey];

            if (string.IsNullOrWhiteSpace(name)
                || string.IsNullOrWhiteSpace(password))
            {
                this.DisplayError("You have empty fields");
                return this.FileViewResponse(@"account\login");
            }

            using (this.Context)
            {
                var dbUser = this.Context.Users.FirstOrDefault(user => user.Username == name);
                if (dbUser == null)
                {
                    this.DisplayError("Invalid credentials");
                    return this.FileViewResponse(@"account\login");
                }

                var passwordHash = PasswordUtilities.GenerateHash(password);
                if (passwordHash != dbUser.PasswordHash)
                {
                    this.DisplayError("Invalid credentials");
                    return this.FileViewResponse(@"account\login");
                }

                CompleteLogin(req, dbUser.Id);
            }

            return new RedirectResponse("/");
        }

        public IHttpResponse Logout(IHttpRequest req)
        {
            req.Session.Clear();

            return new RedirectResponse("/login");
        }

        public IHttpResponse Orders(IHttpRequest req)
        {
            const string tableContentKey = "tableContent";
            var userId = req.Session.Get<int>(SessionStore.CurrentUserKey);
            string tableData = "";
            using (this.Context)
            {
                var orders = this.Context.Orders.Where(o => o.UserId == userId);
                tableData = string.Join("", orders.Select(o => $"<tr><td><a href=\"/orderDetails/{o.Id}\">{ o.Id}</a></td><td>{ o.CreateOn.ToString("dd-MM-yyy")}</td><td>${ o.Sum.ToString("F2")}</td></tr >"));
            }

            if (string.IsNullOrEmpty(tableData))
            {
                this.ViewData["error"] = "<h2>You have no orders</h2>";
                this.ViewData["showResult"] = "none";
                this.ViewData["showError"] = "block";
            }
            else
            {
                this.ViewData[tableContentKey] = tableData;
                this.ViewData["showResult"] = "block";
                this.ViewData["showError"] = "none";
            }

            return this.FileViewResponse(@"account\orders");
        }

        public IHttpResponse OrderDetails(int id)
        {
            const string tableContentKey = "tableContent";
            Order order = null;
            string tableData = "";
            using (this.Context)
            {
                order = this.Context.Orders.Find(id);
                tableData = string.Join("", this.Context.ProductOrders
                    .Where(po => po.OrderId == id)
                    .Select(po => $"<tr><td><a href=\"/cakeDetails/{po.ProductId}\">{po.Product.Name}</a></td><td>${po.Product.Price.ToString("F2")}</td></tr >"));
            }

            if (order == null)
            {
                return new BadRequestResponse();
            }


            this.ViewData[tableContentKey] = tableData;
            this.ViewData["createdOn"] = order.CreateOn.ToString("dd-MM-yyyy");
            this.ViewData["showError"] = "none";

            return this.FileViewResponse(@"account\orderDetails");
        }

        private void DisplayError(string errorMessage)
        {
            this.ViewData["error"] = errorMessage;
            this.ViewData["showError"] = "block";
            this.ViewData["authDisplay"] = "none";
        }

        private static void CompleteLogin(IHttpRequest req, int userId)
        {
            req.Session.Add(SessionStore.CurrentUserKey, userId);
            req.Session.Add(ShoppingCart.SessionKey, new ShoppingCart());
        }
    }
}
