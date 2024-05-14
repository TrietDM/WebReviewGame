using Microsoft.AspNetCore.Identity;

namespace WebReviewGame.Models.DBEnitity
{
    public class User : IdentityUser
    {
        public int Name { get; set; }
        public int Address { get; set; }
    }
}
