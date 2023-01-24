using Entites.Concrete.Models;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bilet1.Context
{
    public class TaskDbContext:IdentityDbContext<AppUser>
    {
        public TaskDbContext(DbContextOptions options) : base(options) {}
        public DbSet<Post> Posts { get; set; }
        //public DbSet<RecentSec> RecSection { get; set; }  
    }
}
