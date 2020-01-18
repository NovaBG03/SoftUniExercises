using System.Linq;
using AutoMapper;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UserImportDto, User>();
            this.CreateMap<ProductImportDto, Product>();
            this.CreateMap<CategoryImportDto, Category>();
            this.CreateMap<CategoryProductImportDto, CategoryProduct>();

            this.CreateMap<Product, ProductInRangeExportDto>()
                .ForMember(d => d.BuyerName, s => s.MapFrom(p => p.Buyer.FirstName + " " + p.Buyer.LastName));

            this.CreateMap<User, UserSoldProductsExportDto>();

            //this.CreateMap<Category, CategoryByProductExportDto>()
            //    .ForMember(d => d.ProductsCount, s => s.MapFrom(c => c.CategoryProducts.Count))
            //    .ForMember(d => d.AveragePrice, s => s.MapFrom(c => c.CategoryProducts.Average(cp => cp.Product.Price)))
            //    .ForMember(d => d.totalRevenue, s => s.MapFrom(c => c.CategoryProducts.Sum(cp => cp.Product.Price)));
        }
    }
}
