using DataAccessLayer.Abstractions;
using EntityLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class UserValidation : AbstractValidator<User>
    {        
        public UserValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad bölməsi boş keçilə bilməz");

            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad bölməsi boş keçilə bilməz");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email bölməsi boş keçilə bilməz");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifrə bölməsi boş keçilə bilməz");
        }
    }
}
