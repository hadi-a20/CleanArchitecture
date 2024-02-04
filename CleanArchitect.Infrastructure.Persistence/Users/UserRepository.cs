using CleanArchitect.Domain.Common.Models;
using CleanArchitect.Domain.Common.Models.Abstracts;
using CleanArchitect.Domain.Users;

namespace CleanArchitect.Infrastructure.Persistence.Users;

public class UserRepository : IUserRepository
{
    private static List<User> users = new();

    public async Task<Result<User>> AddAsync(User user, CancellationToken cancellationToken)
    {
        users.Add(user);
        return user;
    }

    public Task<Result<User>> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Result<User>> GetByIdAsync(Id id)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<bool>> UserWithMailExistsAsync(string email, CancellationToken cancellationToken)
    {
        return users.Exists(c => c.Email == email);
    }
}
