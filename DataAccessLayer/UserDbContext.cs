using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebReviewGame.Models.DBEnitity;

namespace WebReviewGame.DataAccessLayer
{
    public class UserDbContext : IdentityDbContext<User>
   {
        public UserDbContext(DbContextOptions option) : base(option) 
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var admin = new IdentityRole("admin");
            admin.NormalizedName = "admin";

            var user = new IdentityRole("user");
            user.NormalizedName = "user";

            builder.Entity<IdentityRole>().HasData(user, admin);
        }
    }
}
