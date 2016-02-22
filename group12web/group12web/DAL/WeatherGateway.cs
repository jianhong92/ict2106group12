using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using group12web.Models;

namespace group12web.DAL
{
    public class WeatherGateway : DataGateway<Weather>
    {
        internal group12Context db = new group12Context();

        public IEnumerable<WeatherChart> Chart()
        {
            List<WeatherChart> weather = new List<WeatherChart>();

            List<Weather> weatherDB = db.Weathers.ToList();

            for (int i=0; i< weatherDB.Count; i++)
            {
                WeatherChart temp = new WeatherChart();

                temp.Station = weatherDB[i].Station;
                temp.Date = weatherDB[i].Date.ToShortDateString();
                temp.Rainfall = weatherDB[i].Rainfall;

                weather.Add(temp);
            }

            return weather.AsEnumerable();
        }
    }
}