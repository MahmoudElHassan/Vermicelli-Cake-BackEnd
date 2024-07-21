using AutoMapper;
using E_Commerce_DAL;
using E_Commerce_DAL.Identity;

namespace E_Commerce_BL;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Product, ReadProductDTO>()
            .ForMember(x => x.Category, z => z.MapFrom(v => v.category.Name))
            //.ForMember(x => x.Flavor, z => z.MapFrom(v => v.flavor.Name))
            .ForMember(x => x.PictureURL, z => z.MapFrom<ProductAPIResolver>());
        CreateMap<AddProductDTO, Product>();
        CreateMap<UpdateProductDTO, Product>();

        //CreateMap<Flavor, ReadFlavorDTO>();
        //CreateMap<AddFlavorDTO, Flavor>();
        //CreateMap<UpdateFlavorDTO, Flavor>();

        CreateMap<Category, ReadCategoryDTO>()
            .ForMember(c => c.PictureURL, x => x.MapFrom<CategoryAPIResolver>());
        CreateMap<AddCategoryDTO, Category>();
        CreateMap<UpdateCategoryDTO, Category>();

        CreateMap<CustomerBasketDto, CustomerBasket>();
        CreateMap<BasketItemDto, BasketItem>();

        CreateMap<Address, AddressDto>().ReverseMap();

        CreateMap<AddressDto, E_Commerce_DAL.OrderAggregate.Address>();

        CreateMap<Order, OrderToReturnDto>()
            .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.Area))
            .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));

        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.ProductItemId))
            .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
            .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.ItemOrdered.PictureUrl))
            .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());
    }
}
