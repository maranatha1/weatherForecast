using BusinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POE_AdvancedWeatherForecastingSystem
{
    public partial class GeneralUser : System.Web.UI.Page
    {
        WeatherUpdateDBAccess weatherUpdateDBAccess = new WeatherUpdateDBAccess();
        WeatherCondition weatherCondition = new WeatherCondition();
        WeatherUpdateBL WeatherUpdateBL = new WeatherUpdateBL();
        string connectionString = ConfigurationManager.ConnectionStrings["WeatherForecast"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            bindgrid();
        }
        private void bindgrid()
        {
            try
            {
                DataTable dataTable = new DataTable();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("Select CityName, [Date], MinimumTemperature, MaximumTemperature, Percipitation, Humidity, WindSpeed  from City", conn);
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);

                }
                if (dataTable.Rows.Count > 0)
                {

                    dgvWeatherUpdate.DataSource = dataTable;
                    dgvWeatherUpdate.DataBind();
                }
                else
                {
                    dataTable.Rows.Add(dataTable.NewRow());
                    dgvWeatherUpdate.DataSource = dataTable;
                    dgvWeatherUpdate.DataBind();
                    dgvWeatherUpdate.Rows[0].Cells.Clear();
                    dgvWeatherUpdate.Rows[0].Cells.Add(new TableCell());
                    dgvWeatherUpdate.Rows[0].Cells[0].ColumnSpan = dataTable.Columns.Count;
                    dgvWeatherUpdate.Rows[0].Cells[0].Text = "No Data Found ..!";
                    dgvWeatherUpdate.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}