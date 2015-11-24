using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySensei.Entities
{
    public class User
    {
        public int UserID { get; set; }
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }
    }
}
