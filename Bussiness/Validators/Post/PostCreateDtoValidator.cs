using Entites.Dtos.PostDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Validators.Post
{
    public class PostCreateDtoValidator:AbstractValidator<PostCreateDto>
    {

        public PostCreateDtoValidator()
        {
            RuleFor(p=>p.Title).NotEmpty().NotNull().MinimumLength(5).MaximumLength(30).WithMessage("Please check information");
            RuleFor(p=>p.Description).NotEmpty().NotNull().MinimumLength(10).MaximumLength(50);
            RuleFor(p=>p.formFile).NotEmpty().NotNull();
        }
    }
}
