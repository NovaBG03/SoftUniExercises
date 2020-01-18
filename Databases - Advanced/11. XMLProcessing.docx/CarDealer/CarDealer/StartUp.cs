using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(opt =>
            {
                opt.AddProfile(new CarDealerProfile());
            });

            using (var context = new CarDealerContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                string suppliersXml = File.ReadAllText($"../../../Datasets/suppliers.xml");
                ImportSuppliers(context, suppliersXml);

                string partsXml = File.ReadAllText($"../../../Datasets/parts.xml");
                ImportParts(context, partsXml);

                string carsXml = File.ReadAllText($"../../../Datasets/cars.xml");
                ImportCars(context, carsXml);

                string customersXml = File.ReadAllText($"../../../Datasets/customers.xml");
                ImportCustomers(context, customersXml);

                string salesXml = File.ReadAllText($"../../../Datasets/sales.xml");
                ImportSales(context, salesXml);

                var message = GetCarsFromMakeBmw(context);
                Console.WriteLine(message);
            }
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var carDtos = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ProjectTo<BmwExportDto>()
                .ToArray();

            var serializer = new XmlSerializer(typeof(BmwExportDto[]), new XmlRootAttribute("cars"));

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("", "")
            });

            var builder = new StringBuilder();
            using (var stream = new StringWriter(builder))
            {
                serializer.Serialize(stream, carDtos, namespaces);
            }

            return builder.ToString().TrimEnd();
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var carDtos = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<CarWithDistanceExportDto>()
                .ToArray();

            var serializer = new XmlSerializer(typeof(CarWithDistanceExportDto[]), new XmlRootAttribute("cars"));

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("", "")
            });

            var builder = new StringBuilder();
            using (var stream = new StringWriter(builder))
            {
                serializer.Serialize(stream, carDtos, namespaces);
            }

            return builder.ToString().TrimEnd();
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(SaleImportDto[]), new XmlRootAttribute("Sales"));

            using (var stream = new StringReader(inputXml))
            {
                var saleDtos = (SaleImportDto[])serializer.Deserialize(stream);

                var sales = saleDtos
                    .Where(s => context.Cars.Find(s.CarId) != null)
                    .Select(s => Mapper.Map<Sale>(s));

                context.Sales.AddRange(sales);
            }

            var count = context.SaveChanges();

            return $"Successfully imported {count}"; ;
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(CustomerImportDto[]), new XmlRootAttribute("Customers"));

            using (var stream = new StringReader(inputXml))
            {
                var customerDtos = (CustomerImportDto[])serializer.Deserialize(stream);

                var customers = customerDtos.Select(c => Mapper.Map<Customer>(c));

                context.Customers.AddRange(customers);
            }

            var count = context.SaveChanges();

            return $"Successfully imported {count}"; ;
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(CarImportDto[]), new XmlRootAttribute("Cars"));

            int count = 0;
            using (var stream = new StringReader(inputXml))
            {
                var carDtos = (CarImportDto[])serializer.Deserialize(stream);

                carDtos.ToList().ForEach(c => c.PartCarDtos = c.PartCarDtos.Distinct(new PartCarComperarer()).ToArray());

                var validCars = carDtos
                    .Select(c => new CarImportDto
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TraveledDistance = c.TraveledDistance,
                        PartCarDtos = c.PartCarDtos.Where(pc => context.Parts.Find(pc.PartId) != null).ToArray()
                    });

                var cars = validCars.Select(c => new Car()
                {
                    Make = c.Make,
                    Model = c.Model,
                    PartCars = c.PartCarDtos.Select(pc => new PartCar()
                    {
                        PartId = pc.PartId 
                    }).ToArray(),
                    TravelledDistance = c.TraveledDistance
                });
                count = cars.Count();

                context.Cars.AddRange(cars);
            }

            context.SaveChanges();

            return $"Successfully imported {count}"; ;
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(PartImportDto[]), new XmlRootAttribute("Parts"));

            using (var stream = new StringReader(inputXml))
            {
                var partDtos = (PartImportDto[])serializer.Deserialize(stream);

                var validParts = partDtos.Where(p => context.Suppliers.Find(p.SupplierId) != null);

                var parts = validParts.Select(p => Mapper.Map<Part>(p));

                context.Parts.AddRange(parts);
            }

            var count = context.SaveChanges();

            return $"Successfully imported {count}"; ;
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(SupplierImportDto[]), new XmlRootAttribute("Suppliers"));

            using (var stream = new StringReader(inputXml))
            {
                var suppierDtos = (SupplierImportDto[])serializer.Deserialize(stream);

                var suppliers = suppierDtos.Select(s => Mapper.Map<Supplier>(s));

                context.Suppliers.AddRange(suppliers);
            }

            var count = context.SaveChanges();

            return $"Successfully imported {count}"; ;
        }
    }
}