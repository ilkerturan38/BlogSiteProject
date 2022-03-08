using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ConCrete
{
    public class SubscribeMail
    {
        [Key]
        public int mailID { get; set; }

        [StringLength(50,ErrorMessage ="Maksimum 50 Karakter girebilirsiniz.")]
        public string email { get; set; }
    }
}
