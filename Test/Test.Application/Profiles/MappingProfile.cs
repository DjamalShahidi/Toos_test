using AutoMapper;
using Test.Domain;

namespace Test.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<PreInvoiceHeader, AddPreInvoiceHeaderDto>().ReverseMap();

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
            //else if (date.TryParse(stValue, out _)) DateTime
            //{
            //    return UserDetailValueType.Boolean;
            //}
            else
            {
                return UserDetailValueType.String;
            }
        }

    }
}
