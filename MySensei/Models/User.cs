using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace MySensei.Models
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
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string ProfilePicture { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public int? AspNetUserId { get; set; }

        public virtual ICollection<Course> TakenCourses { get; set; }

        public virtual ICollection<Course> OfferedCourses { get; set; }
    }
}
