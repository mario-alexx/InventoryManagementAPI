using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Mappings
{
    /// <summary>
    /// AutoMapper profile for mapping entities to DTOs and vice versa.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile() 
        { 
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap(); 
        }

    }
}
