using AutoMapper;
using DesafioTotvs.Application.Models;
using DesafioTotvs.Domain.Entities;

namespace DesafioTotvs.Application.AutoMapper.Profiles
{
    public class VehiclesProfile : Profile
    {
        public VehiclesProfile()
        {
           CreateMap<Vehicle, VehicleModel>().ReverseMap();
        }
    }
}