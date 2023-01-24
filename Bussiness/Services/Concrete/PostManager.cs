using AutoMapper;
using Entites.Dtos.PostDto;
using Bussiness.Services.Abstract;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstract;
using Entites.Concrete.Models;
using Entites.Dtos.PostDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;


namespace Bussiness.Services.Concrete
{
    internal class PostManager : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;


        public PostManager(IPostRepository postRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _env = env;
        }

        public async Task CreateAsync(PostCreateDto createDto)
        {
            Post post = _mapper.Map<Post>(createDto);
            string imagename = Guid.NewGuid() + createDto.formFile.FileName;
            string pathh = Path.Combine(_env.WebRootPath, "assets/images", imagename);
            using (FileStream file = new FileStream(pathh, FileMode.Create))
            {
                createDto.formFile.CopyTo(file);
            };
            post.Image = imagename;
            await _postRepository.CreateAsync(post);
            await _postRepository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            List<Post> post = await _postRepository.GetAllAsync(p=>p.Id==id);
            if (post == null)
            {
                throw new NotFoundException("Product not found");
            }
            _postRepository.Delete(post.FirstOrDefault());
            await _postRepository.SaveAsync();

        }

        public async Task<List<PostGetDto>> GetAllAsync()
        {
            List<Post> post = await _postRepository.GetAllAsync();
            if (post == null)
            {
                throw new NotFoundException("Product not found");
            }
            List<PostGetDto> posts=_mapper.Map<List<PostGetDto>>(post);
            return posts;
        }

        public async Task UpdateAsync(PostUpdateDto updateDto)
        {
            List<Post> posts = await _postRepository.GetAllAsync();
            Post post = posts.Find(p => p.Id == updateDto.getDto.Id);
            if (post == null)
            {
                throw new NotFoundException("Product not found");
            }

            //post=_mapper.Map<Post>(updateDto.createDto);
            post.Title = updateDto.createDto.Title;
            post.Description=updateDto.createDto.Description;
            if (updateDto.createDto.formFile != null)
            {
                string imagename = Guid.NewGuid() + updateDto.createDto.formFile.FileName;
                string pathh = Path.Combine(_env.WebRootPath, "assets/images", imagename);
                using (FileStream file = new FileStream(pathh, FileMode.Create))
                {
                    updateDto.createDto.formFile.CopyTo(file);
                };
                post.Image = imagename;
            };
            _postRepository.Update(post);
            await _postRepository.SaveAsync();
        }
    }
}
