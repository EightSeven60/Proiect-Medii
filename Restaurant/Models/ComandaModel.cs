using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class ComandaModel
    {
        [Key]
        public int Id { get; set; }
        public int Nrmeniuri { get; set; }
        public int MeniuId { get; set; }


    }
    public class ComandaDbContext : DbContext
    {
        public DbSet<ComandaModel> Comenzi { get; set; }
    }
    //public 
}