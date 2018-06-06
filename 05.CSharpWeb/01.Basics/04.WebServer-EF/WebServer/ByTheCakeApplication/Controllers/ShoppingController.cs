namespace HTTPServer.ByTheCakeApplication.Controllers
{
    using Data;
    using Models;
    using Infrastructure;
    using Server.Http.Contracts;
    using Server.Http.Response;
    using System.Linq;
    using System;
    using HTTPServer.Server.Http;

    public class ShoppingController : Controller
    {
        private readonly CakesData cakesData;

        public ShoppingController()
        {
            this.cakesData = new CakesData();
        }

        public IHttpResponse AddToCart(IHttpRequest req)
        {
            var id = int.Parse(req.UrlParameters["id"]);

            Product newCake = null;
            using (this.Context)
            {
                newCake = this.Context.Products.Find(id);
            }

            if (newCake == null)
            {
                return new NotFoundResponse();
            }

            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);
            shoppingCart.Orders.Add(newCake);

            var redirectUrl = "/search";

            const string searchTermKey = "searchTerm";

            if (req.UrlParameters.ContainsKey(searchTermKey))
            {
                redirectUrl = $"{redirectUrl}?{searchTermKey}={req.UrlParameters[searchTermKey]}";
            }

            return new RedirectResponse(redirectUrl);
        }

        public IHttpResponse ShowCart(IHttpRequest req)
        {
            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            if (!shoppingCart.Orders.Any())
            {
                this.ViewData["cartItems"] = "No items in your cart";
                this.ViewData["totalCost"] = "0.00";
            }
            else
            {
                var items = shoppingCart
                    .Orders
                    .Select(i => $"<div>{i.Name} - ${i.Price:F2}</div><br />");

                var totalPrice = shoppingCart
                    .Orders
                    .Sum(i => i.Price);

                this.ViewData["cartItems"] = string.Join(string.Empty, items);
                this.ViewData["totalCost"] = $"{totalPrice:F2}";
            }

            return this.FileViewResponse(@"shopping\cart");
        }

        public IHttpResponse FinishOrder(IHttpRequest req)
        {
            var userId = req.Session.Get<int>(SessionStore.CurrentUserKey);
            var products = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey).Orders;
            using (this.Context)
            {
                var order = new Order()
                {
                    UserId = userId,
                    CreateOn = DateTime.UtcNow,
                    Sum = products.Sum(p => p.Price),
                    Products = products.Select(p =>
                       new ProductOrder()
                       {
                           ProductId = p.Id,
                       }).ToList()
                };

                this.Context.Add(order);
                this.Context.SaveChanges();
            }

            req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey).Orders.Clear();
            return this.FileViewResponse(@"shopping\finish-order");
        }

        public IHttpResponse EmptyCart(IHttpRequest req)
        {
            req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey).Orders.Clear();
            return new RedirectResponse("/search");
        }
    }
}
