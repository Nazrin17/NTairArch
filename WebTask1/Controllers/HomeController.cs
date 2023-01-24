using Bussiness.Services.Abstract;
using Entites.Dtos.PostDto;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebTask1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;

        public HomeController(IPostService postService )
        {
            _postService = postService;
        }

        public async Task< IActionResult> Index()
        {
            List<PostGetDto> posts = await _postService.GetAllAsync();
            return View(posts);
        }


    }
}