namespace CleanArchitect.Presentation.Contracts.Users.Responses;

public record AuthenticationResponse(
    long Id,
    string FirstName,
    string LastName,
    string Email,
    string Token);