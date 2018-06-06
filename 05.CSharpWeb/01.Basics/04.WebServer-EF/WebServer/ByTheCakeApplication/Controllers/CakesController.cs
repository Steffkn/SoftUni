namespace HTTPServer.ByTheCakeApplication.Controllers
{
    using Data;
    using HTTPServer.Server.Http.Response;
    using Infrastructure;
    using Models;
    using Server.Http.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CakesController : Controller
    {
        private readonly CakesData cakesData;

        public CakesController()
        {
            this.cakesData = new CakesData();
        }

        public IHttpResponse Add()
        {
            this.ViewData["showResult"] = "none";

            return this.FileViewResponse(@"cakes\add");
        }

        public IHttpResponse Add(string name, string price, string imageUrl)
        {
            var product = new Product
            {
                Name = name,
                Price = decimal.Parse(price),
                ImageUrl = imageUrl
            };

            using (this.Context)
            {
                this.Context.Products.Add(product);
                this.Context.SaveChanges();
            }

            this.ViewData["name"] = name;
            this.ViewData["price"] = price;
            this.ViewData["imageUrl"] = imageUrl;
            this.ViewData["showResult"] = "block";

            return this.FileViewResponse(@"cakes\add");
        }

        public IHttpResponse Details(int id)
        {
            Product cake = null;
            using (this.Context)
            {
                cake = this.Context.Products.Find(id);
            }

            if (cake == null)
            {
                return new BadRequestResponse();
            }

            this.ViewData["name"] = cake.Name;
            this.ViewData["price"] = cake.Price.ToString("F2");
            this.ViewData["imageUrl"] = cake.ImageUrl;
            this.ViewData["showResult"] = "block";

            return this.FileViewResponse(@"cakes\details");
        }

        public IHttpResponse Search(IHttpRequest req)
        {
            const string searchTermKey = "searchTerm";

            var urlParameters = req.UrlParameters;

            this.ViewData["results"] = string.Empty;
            this.ViewData[searchTermKey] = string.Empty;

            if (urlParameters.ContainsKey(searchTermKey))
            {
                var searchTerm = urlParameters[searchTermKey];

                this.ViewData[searchTermKey] = searchTerm;

                IEnumerable<string> cakeResults = null;
                using (this.Context)
                {
                    var lowerSearchTerm = searchTerm.ToLower();
                    cakeResults = this.Context.Products.Where(cake => cake.Name.ToLower().Contains(lowerSearchTerm))
                    .Select(c =>
                    $@"<div>
                        <img src=""{c.ImageUrl}"" alt=""iamge for {c.Name}"" style=""max-height: 200px;""/>
                        <br />
                        <a href=""/cakeDetails/{c.Id}"" target=""_blank"">{c.Name}</a> - ${c.Price:F2} 
                        <a href=""/shopping/add/{c.Id}?searchTerm={searchTerm}"">Order</a>
                    </div>")
                    .ToList();
                }

                var results = "No cakes found";
                if (cakeResults.Any())
                {
                    results = string.Join(Environment.NewLine, cakeResults);
                }

                this.ViewData["results"] = results;
            }
            else
            {
                this.ViewData["results"] = "Please, enter search term";
            }

            this.ViewData["showCart"] = "none";

            var shoppingCart = req.Session.Get<ShoppingCart>(ShoppingCart.SessionKey);

            if (shoppingCart.Orders.Any())
            {
                var totalProducts = shoppingCart.Orders.Count;
                var totalProductsText = totalProducts != 1 ? "products" : "product";

                this.ViewData["showCart"] = "block";
                this.ViewData["products"] = $"{totalProducts} {totalProductsText}";
            }

            return this.FileViewResponse(@"cakes\search");
        }
    }
}
