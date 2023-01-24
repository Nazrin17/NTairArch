using AutoMapper;
using Bilet1.Context;
using Entites.Dtos.PostDto;
using Entites.Concrete.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;
using Bussiness.Services.Abstract;

namespace Bilet1.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IWebHostEnvironment _env;
        public PostController(IPostService postService, IWebHostEnvironment env)
        {
            _postService = postService;
            _env = env;
        }

        public  async Task<IActionResult> Index()
        {
           List<PostGetDto> getDtos= await _postService.GetAllAsync();
            return View(getDtos);

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostCreateDto createDto)
        {
            await _postService.CreateAsync(createDto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            List<PostGetDto> exposts =await _postService.GetAllAsync();
            PostGetDto expost=exposts.Find(p=>p.Id==id);
            PostUpdateDto updateDto = new PostUpdateDto { getDto = expost };
            return View(updateDto);

        }
        [HttpPost]
        public async Task<IActionResult> Update(PostUpdateDto updateDto)
        {
           await _postService.UpdateAsync(updateDto);
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Delete(int id)
        {
          await _postService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
