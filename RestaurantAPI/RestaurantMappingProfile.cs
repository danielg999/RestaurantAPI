﻿using AutoMapper;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI
{
    public class RestaurantMappingProfile : Profile
    {
        public RestaurantMappingProfile()
        {
            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode));
            CreateMap<Dish, DishDto>();

            CreateMap<CreateRestaurantDto, Restaurant>()
                .ForMember(r => r.Address, c => c.MapFrom(dto => new Address() 
                    { City = dto.City, Street = dto.Street, PostalCode = dto.PostalCode }));

            CreateMap<CreateDishDto, Dish>();
           /* CreateMap<ModifyRestaurantDto, Restaurant>()
                .ForMember(m => m.Name, c => c.MapFrom(s => s.Name))
                .ForMember(m => m.Description, c => c.MapFrom(s => s.Description))
                .ForMember(m => m.HasDelivery, c => c.MapFrom(s => s.HasDelivery));*/
        }
    }
}
