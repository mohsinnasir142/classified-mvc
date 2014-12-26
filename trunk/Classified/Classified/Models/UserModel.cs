
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Classified.Models
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string ProfilePic { get; set; }
        public DateTime DateEdited { get; set; }
        public string Other { get; set; }
    }
    //public class ProfileContext : DbContext
    //{
    //    public ProfileContext()
    //        : base("DefaultConnection")
    //    {
    //    }
    //    [Table("personal-info")]
    //    public DbSet<UserModel> userModel { get; set; }
    //}
}