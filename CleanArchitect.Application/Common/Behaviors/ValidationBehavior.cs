using CleanArchitect.Domain.Common.BaseErrors;
using CleanArchitect.Domain.Common.Models.Abstracts;
using FluentValidation;
using Mediator;

namespace CleanArchitect.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ICommand<TResponse>, IQuery<TResponse>
    where TResponse : IResult
{
    private readonly IValidator<TRequest> _reguestValidator;

    public ValidationBehavior(IValidator<TRequest> reguestValidator)
    {
        _reguestValidator = reguestValidator;
    }

    public async ValueTask<TResponse> Handle(TRequest request, CancellationToken cancellationToken, MessageHandlerDelegate<TRequest, TResponse> next)
    {
        var validationResult = _reguestValidator.Validate(request);
        if (validationResult is null || validationResult.IsValid)
        {
            return await next(request, cancellationToken);
        }
        var errors = validationResult
            .Errors
            .ConvertAll(validationFailure => Error.Validation(
                validationFailure.PropertyName,
                validationFailure.ErrorMessage));
        return (dynamic)errors;
    }
}