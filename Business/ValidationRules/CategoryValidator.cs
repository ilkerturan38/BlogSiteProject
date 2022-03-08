using Entity.ConCrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.categoryName).NotEmpty().WithMessage("Kategori Adı boş geçilemez..");
            RuleFor(x => x.categoryDescription).NotEmpty().WithMessage("Açıklama kısmı boş geçilemez..");
            RuleFor(x => x.categoryName).MinimumLength(5).WithMessage("Lütfen az 5 karakterlik Kategori Adı giriniz..");
            RuleFor(x => x.categoryName).MaximumLength(50).WithMessage("Maksimum Karakter girişine ulaştınız,En fazla 50 karakter girebilirsiniz..");
            RuleFor(x => x.categoryDescription).MinimumLength(50).WithMessage("Lütfen az 50 karakterlik İçerik giriniz..");
            RuleFor(x => x.categoryDescription).MaximumLength(500).WithMessage("Maksimum Karakter girişine ulaştınız,En fazla 500 karakter girebilirsiniz..");
        }
    }
}
