namespace ProductShop
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using ProductShop.Data;
    using ProductShop.Dtos.Export;
    using ProductShop.Dtos.Import;
    using ProductShop.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(opt =>
            {
                opt.AddProfile<ProductShopProfile>();
            });

            using (var context = new ProductShopContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var usersXml = File.ReadAllText("../../../Datasets/users.xml");
                ImportUsers(context, usersXml);

                var productsXml = File.ReadAllText("../../../Datasets/products.xml");
                ImportProducts(context, productsXml);

                var categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
                ImportCategories(context, categoriesXml);

                var categoryProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");
                ImportCategoryProducts(context, categoryProductsXml);

                var message = GetUsersWithProducts(context);

                Console.WriteLine(message);
            }
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var userDtos = context.Users
                .Where(u => u.ProductsSold.Count != 0)
                .OrderByDescending(u => u.ProductsSold.Count(ps => ps.CategoryProducts.Any()))
                .Select(u => new UserWithAgeExportDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductsCountExportDto
                    {
                        Products = u.ProductsSold
                            .OrderBy(ps => ps.Price)
                            .Select(ps => new ProductExportDto
                            {
                                Name = ps.Name,
                                Price = ps.Price
                            })
                            .ToList(),
                        Count = u.ProductsSold.Count(ps => ps.CategoryProducts.Any()),
                    }
                })
                .ToList();

            var userProductDtos = new UsersAndProductsExportDto()
            {
                Count = userDtos.Count,
                Users = userDtos
            };

            var serializer = new XmlSerializer(typeof(UsersAndProductsExportDto), new XmlRootAttribute("Users"));

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            var builder = new StringBuilder();
            using (var stringWriter = new StringWriter(builder))
            {
                serializer.Serialize(stringWriter, userProductDtos, namespaces);
            }

            return builder.ToString().TrimEnd();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoryDtos = context.Categories
                .Select(c => new CategoryByProductExportDto
                {
                    Name = c.Name,
                    ProductsCount = c.CategoryProducts.Count(),
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(x => x.ProductsCount)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            var serializer = new XmlSerializer(typeof(CategoryByProductExportDto[]), new XmlRootAttribute("Categories"));

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("", "")
            });

            var builder = new StringBuilder();
            using (var stringWriter = new StringWriter(builder))
            {
                serializer.Serialize(stringWriter, categoryDtos, namespaces);
            }

            return builder.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var userDtos = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ProjectTo<UserSoldProductsExportDto>()
                .ToArray();

            var serializer = new XmlSerializer(typeof(UserSoldProductsExportDto[]), new XmlRootAttribute("Users"));

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("", "")
            });

            var builder = new StringBuilder();
            using (var stringWriter = new StringWriter(builder))
            {
                serializer.Serialize(stringWriter, userDtos, namespaces);
            }

            return builder.ToString().TrimEnd();
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var productDtos = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .ProjectTo<ProductInRangeExportDto>()
                .ToArray();

            var serializer = new XmlSerializer(typeof(ProductInRangeExportDto[]), new XmlRootAttribute("Products"));

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("", "")
            });

            var builder = new StringBuilder();

            using (var stringWriter = new StringWriter(builder))
            {
                serializer.Serialize(stringWriter, productDtos, namespaces);
            }

            return builder.ToString().TrimEnd();
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(UserImportDto[]), new XmlRootAttribute("Users"));

            using (var stream = new StringReader(inputXml))
            {
                var userDtos = (UserImportDto[])serializer.Deserialize(stream);

                var users = userDtos.Select(u => Mapper.Map<User>(u));

                context.Users.AddRange(users);
            }

            var count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ProductImportDto[]), new XmlRootAttribute("Products"));

            using (var stream = new StringReader(inputXml))
            {
                var productDtos = (ProductImportDto[])serializer.Deserialize(stream);

                var products = productDtos.Select(p => Mapper.Map<Product>(p));

                context.Products.AddRange(products);
            }
            
            var count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var serialiser = new XmlSerializer(typeof(CategoryImportDto[]), new XmlRootAttribute("Categories"));

            using (var stream = new StringReader(inputXml))
            {
                var categoryDtos = (CategoryImportDto[])serialiser.Deserialize(stream);

                var categories = categoryDtos
                    .Where(c => !string.IsNullOrEmpty(c.Name) && !string.IsNullOrWhiteSpace(c.Name))
                    .Select(c => Mapper.Map<Category>(c));

                context.Categories.AddRange(categories);
            }
            
            var count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var serialiser = new XmlSerializer(typeof(CategoryProductImportDto[]), new XmlRootAttribute("CategoryProducts"));

            using (var stream = new StringReader(inputXml))
            {
                var categoryProductDtos = (CategoryProductImportDto[])serialiser.Deserialize(stream);

                var categoryProducts = categoryProductDtos
                    .Where(cp => context.Categories.Find(cp.CategoryId) != null
                        && context.Products.Find(cp.ProductId) != null)
                    .Select(cp => Mapper.Map<CategoryProduct>(cp));

                context.CategoryProducts.AddRange(categoryProducts);
            }

            var count = context.SaveChanges();

            return $"Successfully imported {count}";
        }
    }
}