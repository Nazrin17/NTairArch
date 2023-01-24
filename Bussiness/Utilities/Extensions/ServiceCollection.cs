using Bilet1.Context;
using Bussiness.Services.Abstract;
using Bussiness.Services.Concrete;
using Core.Entities.Concrete;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Utilities.Extensions
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddBusinessConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostService, PostManager>();
            services.AddDbContext<TaskDbContext>(op =>
            {
                op.UseSqlServer(configuration.GetConnectionString("default"));

            });
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddIdentity<AppUser, IdentityRole>(op =>
            {
                op.Password.RequireDigit = true;
                op.Password.RequireLowercase = true;
                op.Password.RequireNonAlphanumeric = true;
                op.Password.RequireUppercase = true;
                op.Password.RequiredLength = 6;
                op.Password.RequiredUniqueChars = 1;
                op.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                op.Lockout.MaxFailedAccessAttempts = 5;
                op.Lockout.AllowedForNewUsers = true;
            }).AddEntityFrameworkStores<TaskDbContext>();
            services.AddControllers().AddFluentValidation(
    op =>
    {
        op.ImplicitlyValidateChildProperties = true;
        op.ImplicitlyValidateRootCollectionElements = true;
        op.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    });
            ;
            return services;
        }
    }
}
