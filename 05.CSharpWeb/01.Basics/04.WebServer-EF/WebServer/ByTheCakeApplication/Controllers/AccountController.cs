namespace HTTPServer.ByTheCakeApplication.Controllers
{
    using System;
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
                this.ViewData["error"] = "You have empty fields";
                this.ViewData["showError"] = "block";
                this.ViewData["authDisplay"] = "none";

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
                this.ViewData["error"] = "You have wrong fields";
                this.ViewData["showError"] = "block";
                this.ViewData["authDisplay"] = "none";

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

            req.Session.Add(SessionStore.CurrentUserKey, name);
            req.Session.Add(ShoppingCart.SessionKey, new ShoppingCart());

            return new RedirectResponse("/");
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
                return new BadRequestResponse();
            }

            var name = req.FormData[formNameKey];
            var password = req.FormData[formPasswordKey];

            if (string.IsNullOrWhiteSpace(name)
                || string.IsNullOrWhiteSpace(password))
            {
                this.ViewData["error"] = "You have empty fields";
                this.ViewData["showError"] = "block";
                this.ViewData["authDisplay"] = "none";

                return this.FileViewResponse(@"account\login");
            }
            using (this.Context)
            {
                var dbUser = this.Context.Users.FirstOrDefault(user => user.Username == name);
                if (dbUser == null)
                {
                    this.ViewData["error"] = "Invalid credentials";
                    this.ViewData["showError"] = "block";
                    this.ViewData["authDisplay"] = "none";
                    return this.FileViewResponse(@"account\login");
                }

                var passwordHash = PasswordUtilities.GenerateHash(password);
                if (passwordHash != dbUser.PasswordHash)
                {
                    this.ViewData["error"] = "Invalid credentials";
                    this.ViewData["showError"] = "block";
                    this.ViewData["authDisplay"] = "none";
                    return this.FileViewResponse(@"account\login");
                }

                req.Session.Add(SessionStore.CurrentUserKey, dbUser.Username);
                req.Session.Add(ShoppingCart.SessionKey, new ShoppingCart());
            }

            return new RedirectResponse("/");
        }

        public IHttpResponse Logout(IHttpRequest req)
        {
            req.Session.Clear();

            return new RedirectResponse("/login");
        }
    }
}
