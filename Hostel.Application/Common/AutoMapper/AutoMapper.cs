using AutoMapper;
using Hostel.Application.Common.Dtos;
using Hostel.Domain.Entities;

namespace Hostel.Application.Common.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<TestEntity, TestDto>();
        }
    }
}