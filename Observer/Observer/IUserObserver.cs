using BaseProject.Models;

namespace Observer.Observer
{
    public interface IUserObserver
    {
        void UserCreated(AppUser appUser);
    }
}