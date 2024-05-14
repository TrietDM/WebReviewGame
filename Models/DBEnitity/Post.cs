using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebReviewGame.Models.DBEnitity
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime Date {get; set; }

    }
}
