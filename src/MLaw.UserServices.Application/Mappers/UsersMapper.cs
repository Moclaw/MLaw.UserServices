using AutoMapper;
using MLaw.UserServices.Application.Contracts.Requests;
using MLaw.UserServices.Entities;

namespace MLaw.UserServices.Mappers
{
    public class UsersMapper : Profile
    {
        public UsersMapper()
        {
            CreateMap<UsersRequest, Users>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

            CreateMap<RegisterRequest, Users>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
        }
    }
}
