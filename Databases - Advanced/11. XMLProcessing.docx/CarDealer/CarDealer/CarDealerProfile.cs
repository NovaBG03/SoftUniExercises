using AutoMapper;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<SupplierImportDto, Supplier>();
            this.CreateMap<PartImportDto, Part>();
            this.CreateMap<CarImportDto, Car>()
                .ForMember(dest => dest.PartCars, src => src.MapFrom(c => c.PartCarDtos));
            this.CreateMap<PartCarImportDto, PartCar>();
            this.CreateMap<CustomerImportDto, Customer>();
            this.CreateMap<SaleImportDto, Sale>();

            this.CreateMap<Car, CarWithDistanceExportDto>();
            this.CreateMap<Car, BmwExportDto>();
        }
    }
}
