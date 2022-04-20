using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;

namespace WebApp.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Writer
            CreateMap<WriterDto, Writer>()
                .AfterMap((src, dest) =>
                {
                    dest.User = new User
                    {
                        UserId = src.UserId,
                        UserEmail = src.UserEmail,
                        UserFirstName = src.UserFirstName,
                        UserLastName = src.UserLastName,
                    };
                });

            CreateMap<Writer, WriterDto>()
                .ForMember(dest => dest.UserFirstName, opt => opt.MapFrom(src => src.User.UserFirstName))
                .ForMember(dest => dest.UserLastName, opt => opt.MapFrom(src => src.User.UserLastName))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.UserEmail));

            // User
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
