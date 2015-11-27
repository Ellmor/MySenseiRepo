using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace MySensei.Models
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
