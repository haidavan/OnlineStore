using AutoMapper;
using Store.Application.Mappings;
using Store.Application.Products.Commands.AddProductCommand;

namespace Store.WebAPI.Models;

public class CreateProductDTO:IMapWith<AddProductCommand>
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string UrlImage { get; set; }
    public required string Article { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateProductDTO, AddProductCommand>()
            .ForMember(p => p.Name,
                opt => opt.MapFrom(p => p.Name))
            .ForMember(p => p.Description,
                opt => opt.MapFrom(p => p.Description))
             .ForMember(p => p.UrlImage,
                opt => opt.MapFrom(p => p.UrlImage))
              .ForMember(p => p.Article,
                opt => opt.MapFrom(p => p.Article));
    }
}
