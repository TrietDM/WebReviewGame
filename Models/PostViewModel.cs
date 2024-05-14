using System.ComponentModel;

namespace WebReviewGame.Models
{
    public class PostViewModel
    {
        public int PostId { get; set; }
        [DisplayName("Title")]
        public string? Title { get; set; }
        [DisplayName("Description")]

        public string? Description { get; set; }
        [DisplayName("Date")]
    
        public DateTime Date { get; set; }
    }
}
