using AutoMapper;
using Test.Application.DTOs.User;
using Test.Application.DTOs.UserDetail;
using Test.Domain;

namespace Test.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddUserDetailDto, UserDetail>().ForMember(a => a.Type, o => o.MapFrom(src => MapValueType(src.Value))).ReverseMap();

            CreateMap<AddUserDto, User>().ReverseMap();
        }

        private UserDetailValueType MapValueType(object value)
        {
            var stValue = value.ToString();

            if (int.TryParse(stValue, out _))
            {
                return UserDetailValueType.Int;
            }
            else if (bool.TryParse(stValue, out _))
            {
                return UserDetailValueType.Boolean;
            }
            else if (DateTime.TryParse(stValue, out _))
            {
                return UserDetailValueType.DateTime;
            }
            else
            {
                return UserDetailValueType.String;
            }
        }

    }
}
