using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using WebReviewGame.Models.DBEnitity;

namespace WebReviewGame.Models
{
    [Authorize]
    public class UserViewModel : User
    {
        private readonly UserManager<User> _user;
        public UserViewModel(UserManager<User> userManager) 
        {
            _user = userManager;
        }

    }
}
