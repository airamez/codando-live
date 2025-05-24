using AutoMapper;
using WebAPI.Models;
using DataAccess.Models;

namespace WebAPI.Mappers;

public class CategoryProfile : Profile
{
  public CategoryProfile()
  {
    CreateMap<Category, CategoryDto>();
    CreateMap<CategoryDto, Category>()
        .ForMember(dest => dest.CategoryId, opt => opt.Ignore()); // Ignore CategoryId for POST to avoid overwriting
  }
}
