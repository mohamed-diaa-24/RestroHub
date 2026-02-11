using AutoMapper;
using RestroHub.Domain.Entities;

namespace RestroHub.Application.Dishes.Dtos;

public class DishesProfile : Profile
{
    public DishesProfile()
    {
        CreateMap<Dish, DishDto>();
    }
}