using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class WeatherCondition
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public string Date { get; set; }
        public string MinimumTemperature { get; set; }
        public string MaximumTemperature { get; set; }
        public string Percipation { get; set; }
        public string Humidity { get; set; }
        public string WindSpeed { get; set; }
    }
}
