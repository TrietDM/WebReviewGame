using Microsoft.EntityFrameworkCore;
using WebReviewGame.Models.DBEnitity;

namespace WebReviewGame.DataAccessLayer
{
    public class PostDbContext : DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options) : base(options)
        {
        }
        public DbSet<Post> posts { get; set; }
    }
}
