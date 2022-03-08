using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ConCrete
{
    public class About
    {
        [Key]
        public int aboutID { get; set; }

        [DisplayName("Hakkımızda İçerik Kısmı 1")]
        [Required, StringLength(500, ErrorMessage = "Maksimum Karakter Girişine Ulaştınız..")]
        public string Content1 { get; set; }

        [DisplayName("Hakkımızda İçerik Kısmı 2")]
        [Required, StringLength(500, ErrorMessage = "Maksimum Karakter Girişine Ulaştınız..")]
        public string Content2 { get; set; }

        [Required, StringLength(150, ErrorMessage = "Maksimum Karakter Girişine Ulaştınız..")]
        public string ImageURL1 { get; set; }

        [Required, StringLength(150, ErrorMessage = "Maksimum Karakter Girişine Ulaştınız..")]
        public string ImageURL2 { get; set; }
    }
}
