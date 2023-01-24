using Bilet1.Context;
using Core.DataAccess.Concrete;
using DataAccess.Repositories.Abstract;
using Entites.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete
{
    public class PostRepository : RepositoryBase<Post, TaskDbContext>, IPostRepository
    {
        public PostRepository(TaskDbContext context) : base(context)
        {
        }
    }
}
