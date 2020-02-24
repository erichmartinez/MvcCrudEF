using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace MvcCrudEF.Models
{
    public class PersonModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
    public class PersonModelContext : DbContext
    {
        public DbSet<PersonModel> PersonModelDB { get; set; }
    }
}