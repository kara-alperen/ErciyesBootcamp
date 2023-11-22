using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SQLitePCL;
using TravelBlog.Data.Abstract;
using TravelBlog.Data.Concrete;
using TravelBlog.Data.Concrete.EfCore;
using TravelBlog.Entitiy;
using TravelBlog.Models;

namespace TravelBlog.Controllers
{
    public class PostsController : Controller{
        private IPostRepository _postRepository;
        private ICommentRepository _commentRepository;
        

        public PostsController(IPostRepository postRepository,ICommentRepository commentRepository){
            _postRepository = postRepository;
            _commentRepository = commentRepository;
            
        }
            
        

        public async Task<IActionResult> Index(string tag){

            var posts = _postRepository.Posts;
            if(!string.IsNullOrEmpty(tag)){
                posts = posts.Where(x=>x.Tags.Any(t=>t.Url == tag));
            }

            return View(
                new PostsViewModel{Posts = await posts.ToListAsync()});
        }

        public async Task<IActionResult> Details(string url){
           return View(await _postRepository
                       .Posts
                       .Include(x=>x.User)
                       .Include(x=>x.Tags)
                       .ThenInclude(x=>x.Comments)
                       .ThenInclude(x=>x.User)
                       .FirstOrDefaultAsync(p=>p.Url == url)); 
        }

        public IActionResult AddComment(int PostId, string Text, string Url)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var username= User.FindFirstValue(ClaimTypes.Name);
            var avatar= User.FindFirstValue(ClaimTypes.UserData);
            var entitiy = new Comment{
                PostID = PostId,
                Text = Text,
                PublishedOn = DateTime.Now,
                UserId = int.Parse(userId ?? "")
            };
            _commentRepository.CreatePost(entitiy);

            return Json(new {
                username,
                Text,
                entitiy.PublishedOn,
                entitiy.User.Image,
                avatar
            });
            
        }
        [Authorize]
        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(PostCreateViewModel model){
            if(ModelState.IsValid){

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _postRepository.CreatePost(
                    new Post{
                        Title = model.Title,
                        Content = model.Content,
                        Url = model.Url,
                        UserId = int.Parse(userId ?? ""),
                        PublishedOn = DateTime.Now,
                        Image = "1.jpg",
                        IsActive = false
                    }
                );
                return RedirectToAction("Index");
            }

            return View();
        }
        [Authorize]
        public async Task<IActionResult> List(){
            var userId =int.Parse( User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "");
            var role = User.FindFirstValue(ClaimTypes.Role);

            var posts = _postRepository.Posts;

            if(string.IsNullOrEmpty(role)){
                posts = posts.Where(i=>i.UserId == userId);
            }
            return View(await posts.ToListAsync());
        }
         [Authorize]
        public IActionResult Edit(int? id){
            if(id == null){
                return NotFound();
            }
            var post = _postRepository.Posts.FirstOrDefault(i=>i.PostId == id);
            if(post == null){
                return NotFound();
            }
            return View(new PostCreateViewModel{
                PostId = post.PostId,
                Title = post.Title,
                Description = post.Description,
                Content = post.Content,
                Url = post.Url,
                IsActive = post.IsActive
            });
        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit(PostCreateViewModel model){

            if(ModelState.IsValid){
                var entityUpdate = new Post{
                    PostId = model.PostId,
                    Title = model.Title,
                    Description = model.Description,
                    Content = model.Content,
                    Url = model.Url
                };
                if(User.FindFirstValue(ClaimTypes.Role)=="admin"){
                    entityUpdate.IsActive = model.IsActive;
                }
                _postRepository.EditPost(entityUpdate);
                return RedirectToAction("List");
            }
            return View(model);
        }

    }
}
