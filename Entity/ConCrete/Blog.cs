using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ConCrete
{
    public class Blog
    {
        [Key]
        public int blogID { get; set; }


        [StringLength(250)]
        public string Title { get; set; }

        public string ImageURL { get; set; }

      
        public DateTime Date { get; set; }

        public string Content { get; set; }

        public int blogRating { get; set; }

        [Required(ErrorMessage = "authorID boş geçilemez.")]
        public int authorID { get; set; }
        public virtual Author Author { get; set; } // Bir Blog Yazısı,Yalnızca Bir Yazara ait olabilir.

        [Required(ErrorMessage ="categoryID boş geçilemez.")]
        public int categoryID { get; set; }
        public virtual Category category { get; set; } // Bir Blog yalnızca bir Category'e ait olabilir.

        public ICollection<Comment> Comments { get; set; }
    }
}
