using MasterChefe.Mobile.Model;

namespace MasterChefe.Mobile.Interface
{
    public interface IUserService
    {
        bool VerifyLogin(string username, string password);
        bool CreateNewUser(string email, string password);
    }
}