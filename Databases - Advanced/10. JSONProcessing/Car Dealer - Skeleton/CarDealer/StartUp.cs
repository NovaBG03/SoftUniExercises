using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var suppliersJson = File.ReadAllText(@"..\..\..\Datasets\suppliers.json");
            ImportSuppliers(context, suppliersJson);

            var partsJson = File.ReadAllText(@"..\..\..\Datasets\parts.json");
            ImportParts(context, partsJson);

            var carsJson = File.ReadAllText(@"..\..\..\Datasets\cars.json");
            ImportCars(context, carsJson);

            var customersJson = File.ReadAllText(@"..\..\..\Datasets\customers.json");
            ImportCustomers(context, customersJson);

            var salesJson = File.ReadAllText(@"..\..\..\Datasets\sales.json");
            ImportSales(context, salesJson);
            
            var message = GetSalesWithAppliedDiscount(context);

            Console.WriteLine(message);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var cust = context.Customers
                .ToArray();

            var sales = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = s.Discount.ToString("F2"),
                    price = s.Car.PartCars.Sum(pc => pc.Part.Price).ToString("F2"),
                    priceWithDiscount = (s.Car.PartCars.Sum(pc => pc.Part.Price) 
                        * ((100 - s.Discount)/100)).ToString("F2")

                })
                .ToList();

            var json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return json;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var cust = context.Customers
                .ToArray();

            var customers = context.Customers
                .Where(c => c.Sales.Count() > 0)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count(),
                    spentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                })
                .ToArray();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new CarsPartsDto
                {
                    Car = new CarDto
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },
                    Parts = c.PartCars
                        .Select(pc => new PartDto
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price.ToString("F2")
                        })
                        .ToArray()
                })
                .ToArray();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new LocalSupplierDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToArray();

            var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return json;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new ToyotaCarDto()
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToArray();

            var result = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return result;
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new OrderedCustomerDto
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToArray();

            var result = JsonConvert.SerializeObject(customers, Formatting.Indented);
            return result;
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(suppliers);

            var count = context.SaveChanges();
            return $"Successfully imported {count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson);

            var suppliers = context.Suppliers.ToArray();
            var validParts = parts.Where(p => suppliers.Any(s => s.Id == p.SupplierId));

            context.Parts.AddRange(validParts);

            var count = context.SaveChanges();
            return $"Successfully imported {count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            JArray array = JArray.Parse(inputJson);

            var cars = array.Select(x => new Car
            {
                Make = (string)x["make"],
                Model = (string)x["model"],
                TravelledDistance = (long)x["travelledDistance"],
                PartCars = x["partsId"].Select(y => new PartCar()
                {
                    PartId = (int)y
                })
                .Distinct(new PartCarComparer())
                .ToArray()
            })
            .ToList();

            context.Cars.AddRange(cars);

            context.SaveChanges();
            return $"Successfully imported {cars.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);

            var count = context.SaveChanges();
            return $"Successfully imported {count}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales);

            var count = context.SaveChanges();
            return $"Successfully imported {count}.";
        }
    }
}