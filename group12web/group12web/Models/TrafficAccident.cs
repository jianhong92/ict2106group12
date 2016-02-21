using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace group12web.Models
{
    public class TrafficAccident
    {
        public int Id { get; set; }
        public string RoadName { get; set; }


        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public float Long { get; set; }
        public float Lat { get; set; }

        public string Description { get; set; }
    }
}