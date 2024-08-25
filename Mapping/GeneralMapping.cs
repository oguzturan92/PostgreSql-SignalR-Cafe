using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KlassyCafePostgreSql.DAL.Entities;
using KlassyCafePostgreSql.Dtos.AboutDtos;
using KlassyCafePostgreSql.Dtos.BannerDtos;
using KlassyCafePostgreSql.Dtos.CategoryDtos;
using KlassyCafePostgreSql.Dtos.MenuDtos;
using KlassyCafePostgreSql.Dtos.ProductDtos;
using KlassyCafePostgreSql.Dtos.ReservationDtos;
using KlassyCafePostgreSql.Dtos.TableDtos;

namespace KlassyCafePostgreSql.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, GetByIdAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();

            CreateMap<Banner, ResultBannerDto>().ReverseMap();
            CreateMap<Banner, CreateBannerDto>().ReverseMap();
            CreateMap<Banner, GetByIdBannerDto>().ReverseMap();
            CreateMap<Banner, UpdateBannerDto>().ReverseMap();

            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, HomeResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Menu, ResultMenuDto>().ReverseMap();
            CreateMap<Menu, CreateMenuDto>().ReverseMap();
            CreateMap<Menu, GetByIdMenuDto>().ReverseMap();
            CreateMap<Menu, UpdateMenuDto>().ReverseMap();

            CreateMap<Reservation, ResultReservationDto>().ReverseMap();
            CreateMap<Reservation, CreateReservationDto>().ReverseMap();
            CreateMap<Reservation, GetByIdReservationDto>().ReverseMap();
            CreateMap<Reservation, UpdateReservationDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();

            CreateMap<Table, ResultTableDto>().ReverseMap();
            CreateMap<Table, CreateTableDto>().ReverseMap();
            CreateMap<Table, GetByIdTableDto>().ReverseMap();
            CreateMap<Table, UpdateTableDto>().ReverseMap();
        }
    }
}