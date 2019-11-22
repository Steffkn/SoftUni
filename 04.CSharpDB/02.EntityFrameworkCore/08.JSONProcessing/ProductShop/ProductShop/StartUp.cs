using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new ProductShopContext())
            {
                //ResetDatabase(db);

                //Console.WriteLine(ImportUsers(db, File.ReadAllText("Datasets/users.json")));
                //Console.WriteLine(ImportProducts(db, File.ReadAllText("Datasets/products.json")));
                //Console.WriteLine(ImportCategories(db, File.ReadAllText("Datasets/categories.json")));
                //Console.WriteLine(ImportCategoryProducts(db, File.ReadAllText("Datasets/categories-products.json")));


                //Console.WriteLine(GetProductsInRange(db));
                Console.WriteLine(GetCategoriesByProductsCount(db));
            }
        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);
            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);
            context.Products.AddRange(products);
            context.SaveChanges();
            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var serializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson, serializerSettings)
                .Where(x => x.Name != null).ToList();
            context.Categories.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);
            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();
            return $"Successfully imported {categoriesProducts.Count}";
        }

        // Problem 05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(c => c.Price >= 500 && c.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .ToList();

            var json = JsonConvert.SerializeObject(products, Formatting.Indented);

            return json;
        }

        // Problem 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
               .Users
               .Where(x => x.ProductsSold.Any(p => p.Buyer != null))
               .Select(u => new
               {
                   firstName = u.FirstName,
                   lastName = u.LastName,
                   soldProducts = u.ProductsSold
                                   .Where(p => p.Buyer != null)
                                   .Select(x => new
                                   {
                                       name = x.Name,
                                       price = x.Price,
                                       buyerFirstName = x.Buyer.FirstName,
                                       buyerLastName = x.Buyer.LastName
                                   })
                                   .ToList()
               })
               .OrderBy(x => x.lastName)
               .ThenBy(x => x.firstName)
               .ToList();

            var json = JsonConvert.SerializeObject(users, Formatting.Indented);

            return json;
        }

        // Problem 07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count,
                    averagePrice = c.CategoryProducts.Select(pp => pp.Product.Price).Average().ToString("f2"),
                    totalRevenue = c.CategoryProducts.Select(pp => pp.Product.Price).Sum().ToString("f2")
                })
                .OrderByDescending(x => x.productsCount)
                .ToList();

            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return json;
        }

        // Problem 08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(x => x.ProductsSold.Any())
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold
                                    .Where(p => p.Buyer != null)
                                    .Count(),
                        products = u.ProductsSold
                                    .Where(p => p.Buyer != null)
                                    .Select(p => new
                                    {
                                        name = p.Name,
                                        price = p.Price
                                    }).ToList()
                    }
                })
                .OrderByDescending(x => x.soldProducts.count)
                .ToList();

            var jsonSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            var json = JsonConvert.SerializeObject(new { usersCount = users.Count, users = users }, jsonSettings);

            return json;
        }

        private static void ResetDatabase(ProductShopContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Console.WriteLine("ProductShop database created successfully.");
        }
    }
}