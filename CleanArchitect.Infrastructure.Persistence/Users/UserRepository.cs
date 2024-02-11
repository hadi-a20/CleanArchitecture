using CleanArchitect.Domain.Common.Models;
using CleanArchitect.Domain.Common.Models.Abstracts;
using CleanArchitect.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitect.Infrastructure.Persistence.Users;

public class UserRepository : IUserRepository
{
    private readonly CleanDbContext _dbContext;

    public UserRepository(CleanDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<User>> AddAsync(User user, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(user, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
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
        return await _dbContext.Users.AnyAsync(c => c.Email == email, cancellationToken);
    }
}
