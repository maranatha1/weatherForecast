using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessLogic
{
    public class WeatherUpdateBL
    {
        public WeatherUpdateDBAccess weatherUpdateDBAccess = null;

        public WeatherUpdateBL()
        {
            weatherUpdateDBAccess = new WeatherUpdateDBAccess();
        }
        public bool InsertWeatherUpdate(WeatherCondition weather)
        {
            try
            {
                return weatherUpdateDBAccess.InsertWeather(weather);
            }catch
            {
                throw;
            }
        }
        public bool UpdateWeatherDetails(WeatherCondition weather)
        {
            try
            {
                return weatherUpdateDBAccess.UpdateWeather(weather);
            } catch
            {
                throw;
            }
        }
    }
}
