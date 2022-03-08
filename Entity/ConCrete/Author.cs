using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ConCrete
{
    public class Author
    {
        [Key]
        public int authorID { get; set; }

        [Required,StringLength(50, ErrorMessage = "Maksimum Karakter Girişine Ulaştınız..")]
        public string authorNameSurname { get; set; }

        [Required]
        public string imageURL { get; set; }

        [DisplayName("Yazar Hakkında Uzun")]
        [Required, StringLength(500, ErrorMessage = "Maksimum Karakter Girişine Ulaştınız..")]
        public string about { get; set; }

        [DisplayName("Yazar Başlığı")]
        [StringLength(50)]
        public string authorTitle { get; set; }

        [DisplayName("Yazar Hakkında Kısa")]
        [StringLength(100)]
        public string authorShort { get; set; }


        [DisplayName("Yazar Mail")]
        [StringLength(100)]
        public string email { get; set; }


        [DisplayName("Yazar Şifre")]
        [StringLength(50)]
        public string password { get; set; }

        [DisplayName("Yazar Telefon")]
        [StringLength(12)]
        public string phoneNumber { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}
