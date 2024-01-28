using CleanArchitect.Domain.Common.Models;
using CleanArchitect.Domain.Common.Models.Abstracts;

namespace CleanArchitect.Domain.Users;

public interface IUserRepository
{
    public Task<Result<User>> GetByIdAsync(Id id);
    public Task<Result<User>> GetByEmailAsync(string email, CancellationToken cancellationToken);
    public Task<Result<bool>> UserWithMailExistsAsync(string email, CancellationToken cancellationToken);
    public Task<Result<User>> AddAsync(User user, CancellationToken cancellationToken);
}
