using newapi.domain.dtos;
using newapi.domain.entities;
using newapi.infra.data;
using newapi.infra.interfaces;
using newapi.results;

namespace newapi.domain.services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;
    public UserService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<UserResult> Login(UserDTO userDTO)
    {
        var user = new User();
        user.CreateEmail(userDTO.Email);
        user.CreateName(userDTO.Name);
        user.CreatePassword(userDTO.Password);
        await _context.Users.AddAsync(user);
        _context.SaveChanges();
        return new UserResult(true, null, user);
    }
}
