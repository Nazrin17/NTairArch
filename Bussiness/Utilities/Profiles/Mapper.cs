using AutoMapper;
using Entites.Dtos.PostDto;
using Entites.Concrete.Models;
using Entites.Dtos.PostDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Utilities.Profiles
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<PostCreateDto, Post>();
            CreateMap<Post, PostGetDto>();
        }
    }
}
