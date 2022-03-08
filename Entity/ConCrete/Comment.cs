using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ConCrete
{
    public class Comment
    {
        [Key]
        public int commentID { get; set; }

        [DisplayName("AdSoyad")]
        [Required, StringLength(40, ErrorMessage = "Maksimum Karakter Girişine Ulaştınız..")]
        public string NameSurname { get; set; }

        [DisplayName("Mail Adresi")]
        [Required]
        public string email  { get; set; }

        [DisplayName("Yorum İçeriği")]
        [Required, StringLength(500, ErrorMessage = "Maksimum Karakter Girişine Ulaştınız..")]
        public string commentText { get; set; }

        [DisplayName("Yorum Yapılan Tarih")]
        [Required]
        public DateTime CommentDate { get; set; }
        public bool commentStatus { get; set; }
        public int BlogRating { get; set; }
        public int? blogID { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
