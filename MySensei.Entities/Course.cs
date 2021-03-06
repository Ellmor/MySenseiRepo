using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MySensei.Entities
{
    public class Course
    {
        public Course()
        {
            Tags = new HashSet<Tag>();
            Participants = new HashSet<User>();
            Owners = new HashSet<User>();
        }

        [Key]
        public int CourseID { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        public string Location { get; set; }

       
        public byte[] Picture { get; set; }

        [StringLength(20)]
        public string Price { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<User> Participants { get; set; }
        public virtual ICollection<User> Owners { get; set; }
    }
}
