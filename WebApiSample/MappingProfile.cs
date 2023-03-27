using AutoMapper;
using WebApiSample.DTOs;
using WebApiSample.Models;

namespace WebApiSample
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDto, User>().ForMember(user=>user.UserName, opt=>opt.MapFrom(cusRegDto=>cusRegDto.Email))
                .ForMember(user=>user.Role, opt=>opt.MapFrom(src=>"customer"));

            CreateMap<User, UserReturnDto>();
        }
    }
}
