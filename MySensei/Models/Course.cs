using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace MySensei.Models
{
    public class Course
    {
        public Course()
        {
            Tags = new HashSet<Tag>();
            Users = new HashSet<User>();
        }

        [Key]
        public int CourseID { get; set; }

        [StringLength(255)]
        public string Titlte { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        public string Location { get; set; }

        [StringLength(255)]
        public string Picture { get; set; }

        [StringLength(20)]
        public string Price { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
