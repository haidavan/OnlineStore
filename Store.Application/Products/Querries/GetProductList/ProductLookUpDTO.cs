using AutoMapper;
using Store.Application.Mappings;
using Store.Domain;
using System.Text.RegularExpressions;

namespace Store.Application.Products.Querries.GetProductList;

public class ProductLookUpDTO:IMapWith<Product>
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string UrlImage { get; set; }
    public required string Article { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductLookUpDTO>()
            .ForMember(product => product.Id,
                opt => opt.MapFrom(product => product.Id))
            .ForMember(product => product.Name,
                opt => opt.MapFrom(product => product.Article))
            .ForMember(product => product.Name,
                opt => opt.MapFrom(product => product.Description))
            .ForMember(product => product.Name,
                opt => opt.MapFrom(product => product.UrlImage));
    }
}
