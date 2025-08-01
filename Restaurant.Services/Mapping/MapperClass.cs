using AutoMapper;
using Restaurant.Entities.Domain;
using Restaurant.Entities.DTO_S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services.Mapping
{
    public class MapperClass : Profile
    {
        public MapperClass()
        {
            CreateMap<MenuItem, MenuItemDto>().ReverseMap();
            CreateMap<MenuItem, CreateMenuItemDto>().ReverseMap();
            CreateMap<MenuItem, UpdateMenuItemDto>().ReverseMap();

        }
    }
}
