using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetAluminium.Models
{
   public  class car
    {
        [Key]
        public int ID { get; set; }
        public string Make { get; set;}
        public string Model { get; set; }
        public int Year { get; set; }

    }
}
