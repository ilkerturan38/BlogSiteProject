using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ConCrete
{
    public class Category
    {
        [Key]
        public int categoryID { get; set; }

        [StringLength(50)]
        public string categoryName { get; set; }

        [StringLength(500)]
        public string categoryDescription { get; set; }

        public ICollection<Blog> blogs { get; set; } // Bir Category'e ait birden fazla Blog kaydı olabilir.

        public bool categoryStatus { get; set; }

    }
}
