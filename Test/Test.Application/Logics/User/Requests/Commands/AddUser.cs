using MediatR;
using Test.Application.DTOs.User;
using Test.Application.Responses;

namespace Test.Application.Logics.User.Requests.Commands
{
    public class AddUser:IRequest<Response>
    {
        public AddUserDto Request { get; set; }
    }
}
