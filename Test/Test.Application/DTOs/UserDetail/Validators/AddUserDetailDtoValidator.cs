using FluentValidation;
using Test.Application.Contracts.Persistence;
using Test.Application.DTOs.User;

namespace Test.Application.DTOs.UserDetail.Validators
{
    public class AddUserDetailDtoValidator : AbstractValidator<AddUserDetailDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddUserDetailDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;


            RuleFor(a => a.Key).NotNull()
                               .NotEmpty()
                               .MaximumLength(50)
                               .MaximumLength(1)
                               .WithMessage("Invalid key");

            RuleFor(a => a.Value).NotNull()
                                 .NotEmpty()
                                 .WithMessage("Invalid value");


        }

    }
}
