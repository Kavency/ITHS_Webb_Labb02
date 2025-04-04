using KayakCove.Application.DTOs;
using KayakCove.Domain.Entities;

namespace KayakCove.Web.ApiServices
{
    public class LoginStateService
    {
        public bool IsAdminLoggedIn { get; private set; }
        public bool IsLoggedIn { get; private set; }
        public UserDto UserDto { get; set; } = new UserDto { Role = new Role() };

        public event Action OnChange;

        public void UpdateAdminLoginState(bool isLoggedIn)
        {
            IsAdminLoggedIn = isLoggedIn;
            IsLoggedIn = isLoggedIn;
            NotifyStateChanged();
        }

        public void UpdateUserLoginState(bool isLoggedIn)
        {
            IsAdminLoggedIn = false;
            IsLoggedIn = isLoggedIn;
            NotifyStateChanged();
        }

        public void SetUser(UserDto userDto)
        {
            UserDto = userDto;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
