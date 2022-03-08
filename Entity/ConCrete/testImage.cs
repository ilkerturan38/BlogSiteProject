using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ConCrete
{
    public class testImage
    {
        [Key]
        public int ID { get; set; }
        public string MyProperty { get; set; }
    }
}
