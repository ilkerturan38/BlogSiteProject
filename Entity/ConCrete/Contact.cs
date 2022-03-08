using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ConCrete
{  
    public class Contact
    {
        [Key]
        public int contactID { get; set; }

        [DisplayName("AdSoyad")]
        [Required, StringLength(40, ErrorMessage = "Maksimum Karakter Girişine Ulaştınız..")]
        public string NameSurname { get; set; }

        [DisplayName("Mail")]
        [Required]
        public string email { get; set; }

        [DisplayName("Konu")]
        [Required, StringLength(50, ErrorMessage = "Maksimum Karakter Girişine Ulaştınız..")]
        public string subject { get; set; }

        [DisplayName("Mesaj")]
        [Required, StringLength(100, ErrorMessage = "Maksimum Karakter Girişine Ulaştınız..")]
        public string message { get; set; }

        public DateTime messageDate { get; set; }
    }
}
