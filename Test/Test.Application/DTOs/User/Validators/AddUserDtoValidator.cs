using FluentValidation;
using Test.Application.Contracts.Persistence;

namespace Test.Application.DTOs.User.Validators
{
    public class AddUserDtoValidator : AbstractValidator<AddUserDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddUserDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
    }
}
