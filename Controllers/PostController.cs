using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebReviewGame.DataAccessLayer;
using WebReviewGame.Models;
using WebReviewGame.Models.DBEnitity;

namespace WebReviewGame.Controllers
{
        [Authorize]
    public class PostController : Controller
    {
        private readonly PostDbContext _context;
        public PostController(PostDbContext dbContext)  
        {
            _context = dbContext;
        }   
        [HttpGet]
        public IActionResult Index()
        {
            var post = _context.posts.ToList();
            List<PostViewModel> pvm = new List<PostViewModel>();
            if (post != null)
            {
                foreach(var p in post) 
                {
                    var PostViewModel = new PostViewModel()
                    {
                        PostId = p.PostId,
                        Title = p.Title,
                        Description = p.Description,
                        Date = p.Date,
                    };
                    pvm.Add(PostViewModel);
                }
                return View(pvm);
            }
            return View(pvm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PostViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Tạo một biến DateTime mới để lưu ngày tạo mới của bài viết
                var currentDate = DateTime.Now;

                var newPost = new Post()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Date = currentDate // Gán ngày tạo mới của bài viết
                };

                _context.posts.Add(newPost);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var post = _context.posts.Find(id);
            if (post == null)
            {
                return NotFound(); 
            }

            var postViewModel = new PostViewModel()
            {
                PostId = post.PostId,
                Title = post.Title,
                Description = post.Description,
                Date = post.Date 
            };

            return View(postViewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, PostViewModel model)
        {
            if (id != model.PostId)
            {
                return NotFound(); 
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var postToUpdate = _context.posts.Find(id);
                    if (postToUpdate == null)
                    {
                        return NotFound();
                    }

                    postToUpdate.Title = model.Title;
                    postToUpdate.Description = model.Description;

                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return StatusCode(500);
                }
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var postToDelete = _context.posts.Find(id);
                if (postToDelete == null)
                {
                    return NotFound();
                }

                _context.posts.Remove(postToDelete);
                _context.SaveChanges();

                TempData["DeleteSuccessMessage"] = "Post deleted successfully.";

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return StatusCode(500); 
            }
        }


    }
}

