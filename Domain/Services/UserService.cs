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

    public async Task<UserResult> GetAllUsers()
    {
        List<string?> errors = [];
        var user = new User();
        // não faz nada é para apenas tirar um possivel erro por não ser async
        await _context.Users.AddAsync(user);
        // _context.SaveChanges();
        // return new UserResult(true, null, user);
        errors.Add("Erro ao capturar os usuários");
        return new UserResult(false, errors);
    }

    public Task<UserResult> GetUserById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<UserResult> CreateUser(UserDTO userDTO)
    {
        var user = new User();
        user.CreateEmail(userDTO.Email);
        user.CreateName(userDTO.Name);
        user.CreatePassword(userDTO.Password);
        await _context.Users.AddAsync(user);
        _context.SaveChanges();
        return new UserResult(true, [], user);
    }

    public Task<UserResult> Login(UserDTO userDTO)
    {
        throw new NotImplementedException();
    }
}
