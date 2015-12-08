using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySensei.Entities
{
    public class User
    {
        public User()
        {
            TakenCourses = new HashSet<Course>();
            OfferedCourses = new HashSet<Course>();
        }

        [Key]
        public int UserId { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(100)]
        public string Fullname { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

               public byte[] ProfilePicture { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public string AspNetUserId { get; set; }

        public virtual ICollection<Course> TakenCourses { get; set; }

        public virtual ICollection<Course> OfferedCourses { get; set; }
    }
}
