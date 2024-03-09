using FluentValidation;
using Test.Application.Contracts.Persistence;
using Test.Application.DTOs.UserDetail.Validators;

namespace Test.Application.DTOs.User.Validators
{
    public class AddUserDtoValidator : AbstractValidator<AddUserDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddUserDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;


            RuleFor(a => a.FirstName).NotNull()
                                     .NotEmpty()
                                     .MaximumLength(50)
                                     .MaximumLength(1)
                                     .WithMessage("Invalid first name");

            RuleFor(a => a.LastName).NotNull()
                                     .NotEmpty()
                                     .MaximumLength(50)
                                     .MaximumLength(1)
                                     .WithMessage("Invalid last name");

            RuleFor(a => a.Code).GreaterThan(0)
                                .MustAsync(async (code, token) =>
                                {
                                    return await _unitOfWork.UserRepository.IsExistWithCode(code);

                                })
                                .WithMessage("Invalid code");

            RuleFor(a => a.Details).Must(details =>
                                   {
                                       var validator = new AddUserDetailDtoValidator(_unitOfWork);

                                       foreach (var detail in details)
                                       {
                                           var result = validator.Validate(detail);

                                           if (!result.IsValid)
                                               return false;
                                       }
                                       return true;
                                   })
                                   .WithMessage("Invalid details");
        }

    }
}
