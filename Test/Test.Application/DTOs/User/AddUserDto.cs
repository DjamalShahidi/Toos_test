using Test.Application.DTOs.UserDetail;

namespace Test.Application.DTOs.User
{
    public class AddUserDto
    {
        public int Code { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<AddUserDetailDto> Details { get; set; }
    }
}
