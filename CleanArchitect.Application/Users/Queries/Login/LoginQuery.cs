using CleanArchitect.Application.Users.Dtos;
using CleanArchitect.Domain.Common.Models.Abstracts;
using Mediator;

namespace CleanArchitect.Application.Users.Queries.Login;

public record LoginQuery(string Email, string Password) : IQuery<Result<AuthenticationResultDto>>;

