using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using Languages;

namespace Restaurant.Models
{
    public class ComandaModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nrmeniuri", ResourceType = typeof(Resource))]
        public int Nrmeniuri { get; set; }
        public int MeniuId { get; set; }
        [Display(Name = "NumeMeniu", ResourceType = typeof(Resource))]
        public string NumeMeniu { get; set; }


    }
    
    //public 
}