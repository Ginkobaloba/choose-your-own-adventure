using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace googlemapintegration.Models
{
    public class Addresses
    {
            [Key]
            public int ID { get; set; }

            public string StreetName { get; set; }

            public string StreetNumber { get; set; }

            public string City { get; set; }

            public string State { get; set; }

            public string Zip { get; set; }

            public float? Lat { get; set; }

            public float? Lng { get; set; }
        }
    }