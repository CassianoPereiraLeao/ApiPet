using newapi.domain.dtos;
using newapi.domain.entities;
using newapi.domain.interfaces;
using newapi.results;
using newapi.infra.interfaces;

namespace newapi.domain.services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserResult> GetAllUsers(int? page)
    {
        int limit = 30;
        var users = await _repository.GetAll(page, limit);
        if (users == null)
        {
            return new UserResult(false, ["Erro ao listar os usuários"]);
        }
        
        var usersResponse = new List<UserDTOResponse>();

        foreach (var user in users)
        {
            usersResponse.Add(new UserDTOResponse(user.Id, user.Name, user.Email, user.PetId));
        }

        return new UserResult(true, [], usersResponse: usersResponse);
    }

    public async Task<UserResult> GetUserById(Guid id)
    {
        var user = await _repository.GetUser(id);
        if (user == null)
        {
            return new UserResult(false, ["Usuário não encontrado"]);
        }

        var userResponse = new UserDTOResponse(user.Id, user.Name, user.Email, user.PetId);

        return new UserResult(true, [], userResponse);
    }

    public async Task<UserResult> CreateUser(UserDTO userDTO)
    {
        List<string?> errors = [];
        var user = new User();

        var email = user.CreateEmail(userDTO.Email);
        if (email != null)
        {
            errors.Add(email);
        }

        var password = user.CreatePassword(userDTO.Password);
        if (password != null)
        {
            errors.Add(password);
        }

        user.CreateName(userDTO.Name);
        // Retorno antes de salvar
        if (errors.Count > 0)
        {
            return new UserResult(false, errors);
        }
        var response = await _repository.CreateUser(user);
        // caso algo der errado como servidor offline ou algo do tipo
        if (response != null)
        {
            errors.Add(response);
            return new UserResult(false, errors);
        }

        var userResponse = new UserDTOResponse(user.Id, user.Name, user.Email, user.PetId);

        return new UserResult(true, [], userResponse);
    }

    public Task<UserResult> Login(UserDTO userDTO)
    {
        throw new NotImplementedException();
    }
}
