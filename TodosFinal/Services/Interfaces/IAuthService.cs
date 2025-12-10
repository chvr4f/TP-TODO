using TodosFinal.ViewModel;

namespace TodosFinal.Services
{
    public interface IAuthService
    {
        bool Login(User user);
        void Logout();
     
    }
}