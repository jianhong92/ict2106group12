using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using group12web.Models;

namespace group12web.DAL
{
    public class group12Context : DbContext
    {
        public group12Context()
            : base("group12db")
        {

        }
        public DbSet<Weather> Weathers { get; set; }

        public DbSet<TrafficAccident> TrafficAccidents { get; set; }
    }
    
}