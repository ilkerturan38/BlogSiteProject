using Entity.ConCrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class BlogValidator:AbstractValidator<Blog> // AbstractValidator'dan miras alındı. (Proje içerisinde hazır,biz oluşturmadık)
    {
        public BlogValidator() // Contructor Metot oluşturuldu.
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Blog Başlığı boş geçilemez..");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Blog İçeriği boş geçilemez..");
            RuleFor(x => x.ImageURL).NotEmpty().WithMessage("Blog Resmi boş geçilemez..");
            //RuleFor(x => x.authorID).NotEmpty().WithMessage("Blog Resmi boş geçilemez..");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Blog Tarihi boş geçilemez..");
            RuleFor(x => x.Title).MinimumLength(50).WithMessage("Lütfen az 50 karakterlik Blog Başlık Adı giriniz..");
            RuleFor(x => x.Title).MaximumLength(250).WithMessage("Maksimum Karakter girişine ulaştınız,Lütfen en fazla 250 karakter giriniz..");
        }
    }
}
