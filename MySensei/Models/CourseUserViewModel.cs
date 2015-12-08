using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySensei.Models
{
    public class FtCourseViewModel
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

    public class FtTeacherViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Full Name")]
        public string name { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Image")]
        public byte[] ImageUrl { get; set; }

    }
    public class CUViewModel
    {
        public int userId { set; get; }
        public Boolean isTeacher { set; get; }
        public Boolean isStudent { set; get; }

        public FtCourseViewModel CourseInView { get; set; }
    }

    public class CourseUserViewModel
    {
        public List<FtCourseViewModel> FtCourseViewModel { get; set; }
        public List<FtTeacherViewModel> FtTeacherViewModel { get; set; }
        public void addFTCourse (FtCourseViewModel ftCmodel)
        {
            FtCourseViewModel.Add(ftCmodel);
        }
        public void addFTTeacher(FtTeacherViewModel ftTmodel)
        {
            FtTeacherViewModel.Add(ftTmodel);
        }

        public CourseUserViewModel()
        {

            FtCourseViewModel = new List<FtCourseViewModel>();
            FtTeacherViewModel = new List<FtTeacherViewModel>();
        }
    }

   
}