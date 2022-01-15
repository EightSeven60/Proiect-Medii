using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class ProdusModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nume { get; set; }
        [Required]
        public int Gramaj { get; set; }
        [Required]
        public int Cantitate { get; set; }
        [Required]
        public string Unitate_masura { get; set; }
    }
    public class ProdusDbContext : DbContext
    {
        public DbSet<ProdusModel> Produse { get; set; }
    }
}