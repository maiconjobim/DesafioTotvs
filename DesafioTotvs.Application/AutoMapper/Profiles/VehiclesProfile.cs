using AutoMapper;
using DesafioTotvs.Application.Models;
using DesafioTotvs.Domain.Entities;
using FluentValidation.Results;

namespace DesafioTotvs.Application.AutoMapper.Profiles
{
    public class VehiclesProfile : Profile
    {
        public VehiclesProfile()
        {
           CreateMap<Vehicle, VehicleModel>().ReverseMap();
           CreateMap<ValidationFailure, Failure>().ReverseMap();
        }
    }
}