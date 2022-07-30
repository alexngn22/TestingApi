using TestingApi.Models.Domain;

namespace TestingApi.Models.Interfaces
{
    public interface IUserRepository
    {
        int GetUserID(User user);
    }
}
