using AutoMapper;

namespace MLaw.UserServices.Mappers
{
    public class UsersMapper : Profile
    {
        public UsersMapper()
        {
            CreateMap<Application.Contracts.Requests.UsersRequest, Entities.Users>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
        }
    }
}
