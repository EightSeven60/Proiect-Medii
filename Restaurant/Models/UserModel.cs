using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30,ErrorMessage ="Nume de utilizator prea lung")]
        public string Username { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="Parola prea lunga")]
        public string Password { get; set; }
        [Required]
        [MaxLength(10,ErrorMessage ="Numar de telefon invalid")]
        public string Nrtel { get; set; }
    }
    public class UserDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
    }
}