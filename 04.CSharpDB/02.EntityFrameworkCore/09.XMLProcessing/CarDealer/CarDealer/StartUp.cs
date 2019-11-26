using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using CarDealer.Dtos.Export;
using System.Text;
using System.Xml;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new CarDealerContext())
            {
                db.Database.EnsureCreated();

                Mapper.Initialize(cfg => cfg.AddProfile<CarDealerProfile>());

                string suppliersInput = File.ReadAllText(@"./Datasets/suppliers.xml");
                string partsInput = File.ReadAllText(@"./Datasets/parts.xml");
                string carsInput = File.ReadAllText(@"./Datasets/cars.xml");
                string customersInput = File.ReadAllText(@"./Datasets/customers.xml");
                string salesInput = File.ReadAllText(@"./Datasets/sales.xml");

                //Console.WriteLine(ImportSuppliers(db,suppliersInput));
                //Console.WriteLine(ImportParts(db,partsInput));
                //Console.WriteLine(ImportCars(db,carsInput));
                //Console.WriteLine(ImportCustomers(db,customersInput));
                //Console.WriteLine(ImportSales(db,salesInput));

                Console.WriteLine(GetTotalSalesByCustomer(db));
            }
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(SupplierImportDTO[]), new XmlRootAttribute("Suppliers"));
            var deserializationResult = (SupplierImportDTO[])serializer.Deserialize(new StringReader(inputXml));

            var suppliers = new List<Supplier>();

            foreach (var entity in deserializationResult)
            {
                var supplier = Mapper.Map<Supplier>(entity);

                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(PartImportDTO[]), new XmlRootAttribute("Parts"));
            var deserializationResult = (PartImportDTO[])serializer.Deserialize(new StringReader(inputXml));

            var parts = new List<Part>();

            foreach (var entity in deserializationResult)
            {
                var part = Mapper.Map<Part>(entity);

                if (context.Suppliers.Any(s => s.Id == part.SupplierId))
                {
                    parts.Add(part);
                }
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(CarImportDTO[]), new XmlRootAttribute("Cars"));
            var deserializationResult = (CarImportDTO[])serializer.Deserialize(new StringReader(inputXml));

            var cars = new List<Car>();

            foreach (var entity in deserializationResult)
            {
                var car = Mapper.Map<Car>(entity);
                cars.Add(car);

                foreach (var carPart in entity.Parts)
                {
                    if (context.Parts.Any(p => p.Id == carPart.PartId))
                    {
                        var partCar = new PartCar { CarId = car.Id, PartId = carPart.PartId };

                        if (car.PartCars.FirstOrDefault(pc => pc.PartId == carPart.PartId) == null)
                        {
                            car.PartCars.Add(partCar);
                        }
                    }
                }

            }

            context.Cars.AddRange(cars);

            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(CustomerImportDTO[]), new XmlRootAttribute("Customers"));
            var deserializationResult = (CustomerImportDTO[])serializer.Deserialize(new StringReader(inputXml));

            var customers = new List<Customer>();

            foreach (var entity in deserializationResult)
            {
                var customer = Mapper.Map<Customer>(entity);

                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(SaleImportDTO[]), new XmlRootAttribute("Sales"));
            var deserializationResult = (SaleImportDTO[])serializer.Deserialize(new StringReader(inputXml));

            var sales = new List<Sale>();

            foreach (var entity in deserializationResult)
            {
                var sale = Mapper.Map<Sale>(entity);

                if (context.Cars.Any(c => c.Id == sale.CarId))
                {
                    sales.Add(sale);
                }

            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new CarDistanceExportDTO
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            var serializer = new XmlSerializer(cars.GetType(), new XmlRootAttribute("cars"));
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new CarMakerExportDTO
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            var serializer = new XmlSerializer(cars.GetType(), new XmlRootAttribute("cars"));
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                  .Where(s => !s.IsImporter)
                  .Select(s => new SupplierExportDTO
                  {
                      Id = s.Id,
                      Name = s.Name,
                      PartsCount = s.Parts.Count()
                  })
                  .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(SupplierExportDTO[]), new XmlRootAttribute("suppliers"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), suppliers, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new CarPartsExportDTO
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars
                .Select(pc => new PartExportDTO
                {
                    Name = pc.Part.Name,
                    Price = pc.Part.Price
                })
                .OrderByDescending(pc => pc.Price)
                .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            var serializer = new XmlSerializer(typeof(CarPartsExportDTO[]), new XmlRootAttribute("cars"));
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });
            var sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new SaleExportDTO
                {
                    CarDTO = new CarExportDTO
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(ps => ps.Part.Price),
                    PriceWithDiscount = s.Car.PartCars.Sum(ps => ps.Part.Price) - s.Car.PartCars.Sum(ps => ps.Part.Price) * s.Discount / 100
                })
                .ToArray();

            var serializer = new XmlSerializer(typeof(SaleExportDTO[]), new XmlRootAttribute("sales"));
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });
            var sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), sales, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new CustomerExportDTO
                {
                    Name = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            var serializer = new XmlSerializer(typeof(CustomerExportDTO[]), new XmlRootAttribute("customers"));
            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });
            var sb = new StringBuilder();

            serializer.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}