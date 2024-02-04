using CleanArchitect.Application.Users.Commands.RegisterUser;
using CleanArchitect.Presentation.Contracts.Users.Requests;
using CleanArchitect.Presentation.Contracts.Users.Responses;
using MapsterMapper;
using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitect.Presentation.Api.Controllers.Users;


[AllowAnonymous]
[Route("[Controller]")]
public class RegisterController : ApiController
{
    private readonly ISender _mediatr;
    private readonly IMapper _mapper;

    public RegisterController(IMediator mediatr, IMapper mapper)
    {
        _mediatr = mediatr;
        _mapper = mapper;
    }

    [Route("register")]
    [HttpPost]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        var result = await _mediatr.Send(command);
        return result.Match(
            result => Ok(_mapper.Map<AuthenticationResponse>(result)),
            errors => Problem(errors));
    }
}

