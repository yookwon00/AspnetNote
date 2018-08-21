using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetNote.Models
{
    public class User
    {
        [Key]
        public int UserNo { get; set; }

        [Required(ErrorMessage ="User Name enter")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="User Id enter")]
        public string UserId { get; set; }
      
        [Required(ErrorMessage ="UserPassword enter")]
        public string UserPassword{ get; set; }
    }
}
