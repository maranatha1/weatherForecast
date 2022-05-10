using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class WeatherUpdateDBAccess
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WeatherForecast"].ConnectionString);
        public bool InsertWeather(WeatherCondition weather)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
               new SqlParameter("@CityName",weather.CityName),
               new SqlParameter("@Date",weather.Date),
               new SqlParameter("@MinimumTemperature",weather.MinimumTemperature),
               new SqlParameter("@MaximumTemperature",weather.MaximumTemperature),
               new SqlParameter("@Percipitation",weather.Percipation),
               new SqlParameter("@Humidity", weather.Humidity),
               new SqlParameter("@WindSpeed",weather.WindSpeed)

            };
            return DBHelper.ExecuteNonQuery("sp_InsertWeather", CommandType.StoredProcedure, parameters);
        }

        public bool UpdateWeather(WeatherCondition weather)
        {
            SqlParameter[] parameters = new SqlParameter[]
           {
               new SqlParameter("@CityName",weather.CityName),
               new SqlParameter("@Date",weather.Date),
               new SqlParameter("@MinimumTemperature",weather.MinimumTemperature),
               new SqlParameter("@MaximumTemperature",weather.MaximumTemperature),
               new SqlParameter("@Percipitation",weather.Percipation),
               new SqlParameter("@Humidity", weather.Humidity),
               new SqlParameter("@WindSpeed",weather.WindSpeed)

           };
            return DBHelper.ExecuteNonQuery("sp_UpdateWeather", CommandType.StoredProcedure, parameters);
        }
    }
}
