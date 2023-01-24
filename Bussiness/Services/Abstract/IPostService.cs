using Entites.Dtos.PostDto;
using Entites.Dtos.PostDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Services.Abstract
{
    public interface IPostService
    {
        Task<List<PostGetDto>> GetAllAsync();
        Task CreateAsync(PostCreateDto createDto);
        Task UpdateAsync(PostUpdateDto updateDto);
        Task DeleteAsync(int id);
        
        
    }
}
