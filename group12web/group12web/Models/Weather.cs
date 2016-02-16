using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace group12web.Models
{
    public class Weather
    {
        public int Id { get; set; }
        public string Station { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public decimal Rainfall { get; set; }
    }
}