using newapi.domain.dtos;
using newapi.domain.entities;
using newapi.domain.interfaces;
using newapi.results;
using newapi.infra.interfaces;
using newapi.token;
using newapi.ownedtypes;

namespace newapi.domain.services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserResult> GetAllUsers(int? page, string key)
    {
        int limit = 30;
        var users = await _repository.GetAll(page, limit);
        if (users == null)
        {
            return new UserResult(false, ["Erro ao listar os usuários"]);
        }

        var usersResponse = new List<UserDTOResponse>();

        var token = new GenerateToken(key);

        foreach (var user in users)
        {
            usersResponse.Add(new UserDTOResponse(user.Id, user.Name, user.Email, token.Generate(user), user.Profile, user.PetId));
        }

        return new UserResult(true, [], usersResponse: usersResponse);
    }

    public async Task<UserResult> GetUserById(Guid id, string key)
    {
        var user = await _repository.GetUser(id);
        if (user == null)
        {
            return new UserResult(false, ["Usuário não encontrado"]);
        }

        var token = new GenerateToken(key);

        var userResponse = new UserDTOResponse(user.Id, user.Name, user.Email, token.Generate(user), user.Profile, user.PetId);

        var userResult = new UserResult(true, [], userResponse);
        userResult.userDTO = new UserDTO(user.Name, user.Email, user.Password, user.Profile);

        return userResult;
    }

    public async Task<UserResult> CreateUser(UserDTO userDTO, string key)
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

        var profile = user.CreateProfile(userDTO.Profile);

        if (profile != null)
        {
            errors.Add(profile);
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

        var token = new GenerateToken(key);

        var userResponse = new UserDTOResponse(user.Id, user.Name, user.Email, token.Generate(user), user.Profile, user.PetId);

        return new UserResult(true, [], userResponse);
    }

    public Task<UserResult> Login(UserDTO userDTO)
    {
        throw new NotImplementedException();
    }

    public async Task<UserResult> UpdateUser(Guid id, UserDTO? userDTO, string key)
    {
        List<string?> errors = [];



        if (userDTO == null)
        {
            return new UserResult(false, ["Usuário não encontrado"]);
        }

        var user = new User();

        user.CreateName(userDTO.Name);

        var password = user.CreatePassword(userDTO.Password);
        if (password != null)
        {
            errors.Add(password);
        }

        var profile = user.CreateProfile(userDTO.Profile);
        if (profile != null)
        {
            errors.Add(profile);
        }

        var email = user.CreateEmail(userDTO.Email);
        if (email != null)
        {
            errors.Add(email);
        }

        var response = await _repository.UpdateUser(id, user);
        if (response != null)
        {
            errors.Add("Usuário não pode ser atualizado");
        }

        if (errors.Count > 0) {
            return new UserResult(false, errors);
        }

        var token = new GenerateToken(key);

        var userResponse = new UserDTOResponse(user.Id, user.Name, user.Email, token.Generate(user), user.Profile, user.PetId);

        return new UserResult(true, [], userResponse);
    }
}
