using MySensei.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySensei.Models
{
    public class SearchCourseViewModel
    {
        public string Query { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }

    public class ViewCourseViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Image")]
        public byte[] ImageUrl { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
    }

    public class CreateCourseViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Image")]
        public HttpPostedFileBase ImageUpload { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
    }

    
}