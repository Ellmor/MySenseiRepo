using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySensei.Models
{
    public class SearchCourseViewModel
    {
        public string Query { get; set; }
    }

    public class ViewCourseViewModel
    {
        public int Id { get; set; }
    }

    public class CreateCourseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}