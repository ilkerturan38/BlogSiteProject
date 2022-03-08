using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ConCrete
{
    public class Admin
    {
        [Key]
        public int adminID { get; set; }

        [Required, StringLength(40, ErrorMessage = "Maksimum Karakter Girişine Ulaştınız..")]
        public string username { get; set; }
        
        [Required, StringLength(40, ErrorMessage = "Maksimum Karakter Girişine Ulaştınız..")]
        public string password { get; set; }

        [StringLength(1)]
        public string adminRole { get; set; }

        public bool adminStatus { get; set; }
    }
}
