using newapi.domain.entities;

namespace newapi.infra.interfaces;

public interface IUserRepository
{
    Task<List<User>> GetAll(int? pages, int limit);
    Task<string?> CreateUser(User user);
    Task<User?> GetUser(Guid id);
}