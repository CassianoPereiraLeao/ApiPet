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
    public async Task<string?> CreateUser(User user)
    {
        var exists = await _context.Users.AnyAsync(u => u.Email._email == user.Email._email);
        if (exists)
        {
            return "Já existe esse email em nosso sistema";
        }

        var createdUser = await _context.Users.AddAsync(user);
        if (createdUser == null)
        {
            return "Não foi possivel salvar o usuário";
        }

        await _context.SaveChangesAsync();
        return null;
    }

    public async Task<List<User>> GetAll(int? pages = 1, int limit = 20)
    {
        var currentPage = pages ?? 1;
        var users = _context.Users;
        
        var query = users.AsQueryable();
        query = query.OrderBy(u => u.Name);
        query = query.Skip((currentPage - 1) * limit);
        query = query.Take(limit);

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

    public async Task<User?> UpdateUser(Guid id, User user)
    {
        var userResponse = await _context.Users.FindAsync(id);

        if (userResponse != null)
        {
            userResponse.UpdateName(user.Name);
            userResponse.UpdateProfile(user.Profile);
            userResponse.UpdatePassword(user.Password);
            userResponse.UpdateEmail(user.Email);
            _context.Users.Update(userResponse);
            await _context.SaveChangesAsync();
        }
        return user;
    }
}
