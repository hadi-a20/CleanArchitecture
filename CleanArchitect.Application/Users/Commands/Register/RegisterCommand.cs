using CleanArchitect.Application.Users.Dtos;
using CleanArchitect.Domain.Common.Models.Abstracts;
using Mediator;

namespace CleanArchitect.Application.Users.Commands.RegisterUser;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : ICommand<Result<AuthenticationResultDto>>;