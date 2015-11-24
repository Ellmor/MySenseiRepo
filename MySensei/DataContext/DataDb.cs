using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MySensei.Entities;

namespace MySensei.DataContext
{
    public class DataDb:DbContext
    {
        public DataDb(): base("DefaultConnection")
        {

        }
        public DbSet<User> Users { get; set; }
    }
}