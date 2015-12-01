using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace MySensei.Entities
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }

        [StringLength(255)]
        public string Text { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
