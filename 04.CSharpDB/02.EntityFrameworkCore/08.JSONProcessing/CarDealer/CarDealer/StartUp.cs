using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new CarDealerContext())
            {
                //ResetDatabase(db);

                //Console.WriteLine(ImportSuppliers(db, File.ReadAllText("Datasets/suppliers.json")));
                //Console.WriteLine(ImportParts(db, File.ReadAllText("Datasets/parts.json")));
                //Console.WriteLine(ImportCars(db, File.ReadAllText("Datasets/cars.json")));
                //Console.WriteLine(ImportCustomers(db, File.ReadAllText("Datasets/customers.json")));
                //Console.WriteLine(ImportSales(db, File.ReadAllText("Datasets/sales.json")));

                //Console.WriteLine(GetCarsFromMakeToyota(db));
                //Console.WriteLine(GetCarsWithTheirListOfParts(db));
                Console.WriteLine(GetTotalSalesByCustomer(db));
            }
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            return Import<Supplier>(context, inputJson);
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var serializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            var deserializedObjects = JsonConvert.DeserializeObject<List<Part>>(inputJson, serializerSettings)
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                .ToList();
            context.Set<Part>().AddRange(deserializedObjects);
            context.SaveChanges();
            return $"Successfully imported {deserializedObjects.Count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var serializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            var carsDTO = JsonConvert.DeserializeObject<List<CarsDTO>>(inputJson, serializerSettings);

            var cars = new List<Car>();
            var carParts = new List<PartCar>();

            foreach (var cardDTO in carsDTO)
            {
                var car = new Car()
                {
                    Make = cardDTO.Make,
                    Model = cardDTO.Model,
                    TravelledDistance = cardDTO.TravelledDistance,
                };

                foreach (var part in cardDTO.PartsId.Distinct())
                {
                    var carPart = new PartCar()
                    {
                        Car = car,
                        PartId = part
                    };

                    carParts.Add(carPart);
                }
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.PartCars.AddRange(carParts);
            context.SaveChanges();
            return $"Successfully imported {cars.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            return Import<Customer>(context, inputJson);
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            return Import<Sale>(context, inputJson);
        }

        // 14
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var objects = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = x.IsYoungDriver
                })
                .ToList();

            return PrintResult(objects);
        }

        // 15
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var objects = context.Cars
                .Where(c => c.Make == "Toyota")
               .Select(x => new
               {
                   x.Id,
                   x.Make,
                   x.Model,
                   x.TravelledDistance
               })
               .OrderBy(x => x.Model)
               .ThenByDescending(x => x.TravelledDistance)
               .ToList();


            return PrintResult(objects);
        }

        // 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var objects = context.Suppliers
                        .Where(c => !c.IsImporter)
                       .Select(x => new
                       {
                           x.Id,
                           x.Name,
                           PartsCount = x.Parts.Count()
                       })
                       .ToList();


            return PrintResult(objects);
        }

        // 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var objects = context.Cars
                        .Select(x => new
                        {
                            car = new
                            {
                                x.Make,
                                x.Model,
                                x.TravelledDistance
                            },
                            parts = x.PartCars.Select(p => new
                            {
                                Name = p.Part.Name,
                                Price = p.Part.Price.ToString("f2")
                            }).ToArray()
                        })
                        .ToList();


            return PrintResult(objects);
        }


        // 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var objects = context.Customers
                .Where(x => x.Sales.Count > 0)
                .Select(x => new
                {
                    fullName = x.Name,
                    boughtCars = x.Sales.Count(),
                    spentMoneyArray = x.Sales
                                .Select(s => s.Car.PartCars.Sum(p => p.Part.Price))
                })
                .Select(x => new
                {
                    x.fullName,
                    x.boughtCars,
                    spentMoney = Convert.ToDecimal(x.spentMoneyArray.Sum().ToString("f2"))
                })
                .OrderByDescending(x => x.spentMoney)
                .ThenByDescending(x => x.boughtCars)
                .ToList();


            return PrintResult(objects);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = $"{s.Discount:F2}",
                    price = $"{s.Car.PartCars.Sum(p => p.Part.Price):F2}",
                    priceWithDiscount = $@"{(s.Car.PartCars.Sum(p => p.Part.Price) -
                        s.Car.PartCars.Sum(p => p.Part.Price) * s.Discount / 100):F2}"
                })
                .Take(10)
                .ToList();

            var json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return json;
        }

        private static void ResetDatabase(CarDealerContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Console.WriteLine("CarDealerShop database created successfully.");
        }

        private static string Import<T>(CarDealerContext context, string inputJson)
            where T : class
        {
            var serializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            var deserializedObjects = JsonConvert.DeserializeObject<List<T>>(inputJson, serializerSettings);
            context.Set<T>().AddRange(deserializedObjects);
            context.SaveChanges();
            return $"Successfully imported {deserializedObjects.Count}.";
        }

        private static string PrintResult(object objects)
        {
            var jsonSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
            };

            var json = JsonConvert.SerializeObject(objects, jsonSettings);

            return json;
        }
    }
}