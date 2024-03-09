using AutoMapper;
using MediatR;
using Test.Application.Contracts.Persistence;
using Test.Application.DTOs.User.Validators;
using Test.Application.Logics.User.Requests.Commands;
using Test.Application.Responses;

namespace Test.Application.Logics.User.Handlers.Commands
{
    public class AddUserHandler : IRequestHandler<AddUser, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Handle(AddUser request, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new AddUserDtoValidator(_unitOfWork);

                var validatorResult = await validator.ValidateAsync(request.Request);

                if (validatorResult.IsValid == false)
                {
                    return new Response()
                    {
                        ErrorMessages = validatorResult.Errors.Select(a => a.ErrorMessage).ToList(),
                        IsSuccess = false,
                        Result = null
                    };
                }

                var user = _mapper.Map<Domain.User>(request.Request);

                var userDetails = _mapper.Map<List<Domain.UserDetail>>(request.Request.Details);

                using var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken);

                try
                {
                    await _unitOfWork.UserRepository.AddAsync(user);

                    await _unitOfWork.Save(cancellationToken);

                    userDetails.ForEach(a => a.UserId = user.Id);

                    await _unitOfWork.Save(cancellationToken);

                    await transaction.CommitAsync(cancellationToken);

                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    return new Response()
                    {
                        IsSuccess = false,
                        ErrorMessages = [ex.Message]
                    };
                }

                return new Response()
                {
                    IsSuccess = true
                };

            }
            catch (Exception ex)
            {
                return new Response()
                {
                    IsSuccess = false,
                    ErrorMessages = [ex.Message]
                };
            }
        }
    }

}

