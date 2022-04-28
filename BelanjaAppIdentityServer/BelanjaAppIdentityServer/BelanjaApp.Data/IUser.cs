using BelanjaAppIdentityServer.ViewModels;

namespace BelanjaAppIdentityServer.BelanjaApp.Data
{
    public interface IUser
    {
        Task Registration(UserCreateViewModels createUser);
        IEnumerable<UserViewModels> GetAllUsers();
        Task<UserViewModels> Authenticate(string username, string password);
    }
}
