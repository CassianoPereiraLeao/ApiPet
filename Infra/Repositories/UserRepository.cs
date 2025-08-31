using Microsoft.EntityFrameworkCore;
using newapi.domain.entities;
using newapi.infra.data;
using newapi.infra.interfaces;

namespace newapi.infra.repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<bool> CreateUser(User user)
    {
        var createdUser = await _context.Users.AddAsync(user);
        if (createdUser == null)
        {
            return false;
        }
        _context.SaveChanges();
        return true;

    }

    public async Task<List<User>> GetAll(int? pages = 1, int limit = 20)
    {
        var currentPage = pages ?? 1;
        var query = _context.Users
        .AsQueryable()
        .OrderBy(u => u.Id)
        .Skip((currentPage - 1) * limit)
        .Take(limit);

        return await query.ToListAsync();
    }

    public async Task<User?> GetUser(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return null;
        }

        return user;
    }
}
