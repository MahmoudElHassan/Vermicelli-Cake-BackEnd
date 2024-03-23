using AutoMapper;
using E_Commerce_DAL;
using E_Commerce_DAL.Identity;

namespace E_Commerce_BL;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Product, ReadProductDTO>()
            .ForMember(x => x.productBrand, z => z.MapFrom(v => v.productBrand.Name))
            .ForMember(x => x.productType, z => z.MapFrom(v => v.productType.Name))
            .ForMember(x => x.PictureURL, z => z.MapFrom<ProducrAPIResolver>());

        CreateMap<AddProductDTO, Product>();
        CreateMap<UpdateProductDTO, Product>();

        CreateMap<ProductType, ReadProductTypeDTO>();
        CreateMap<AddProductTypeDTO, ProductType>();
        CreateMap<UpdateProductTypeDTO, ProductType>();

        CreateMap<ProductBrand, ReadProductBrandDTO>();
        CreateMap<AddProductBrandDTO, ProductBrand>();
        CreateMap<UpdateProductBrandDTO, ProductBrand>();

        CreateMap<CustomerBasketDto, CustomerBasket>();
        CreateMap<BasketItemDto, BasketItem>();

        CreateMap<Address, AddressDto>().ReverseMap();

        CreateMap<AddressDto, E_Commerce_DAL.OrderAggregate.Address>();

        CreateMap<Order, OrderToReturnDto>()
    .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
    .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));
        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.ProductItemId))
            .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
            .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.ItemOrdered.PictureUrl))
            .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());
    }
}
