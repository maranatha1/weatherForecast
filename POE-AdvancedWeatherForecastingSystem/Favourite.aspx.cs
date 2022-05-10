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
    public partial class Favourite : System.Web.UI.Page
    {
        WeatherUpdateDBAccess weatherUpdateDBAccess = new WeatherUpdateDBAccess();
        WeatherCondition weatherCondition = new WeatherCondition();
        WeatherUpdateBL WeatherUpdateBL = new WeatherUpdateBL();
        string connectionString = ConfigurationManager.ConnectionStrings["WeatherForecast"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            bindCityGrid();
            if (!IsPostBack)
            {
                
                string QueryString = "select * from City order by CityName asc";

                SqlConnection myConnection = new SqlConnection(connectionString);
                SqlDataAdapter myCommand = new SqlDataAdapter(QueryString, myConnection);
                DataSet ds = new DataSet();
                myCommand.Fill(ds, "Cities");

                
                selectCities.DataSource = ds;
                selectCities.DataTextField = "CityName";
                selectCities.DataValueField = "CityName";
                selectCities.DataBind();

                selectCities.Items.Insert(0, new ListItem("--Select Cities--", "0"));
            }
        }

        private void bindgrid()
        {
            try
            {
                DataTable dataTable = new DataTable();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("  Select c.CityName, c.[Date], c.MinimumTemperature, c.MaximumTemperature, c.Percipitation, c.Humidity, c.WindSpeed from FavCity as fv, City as c where  fv.FavCity = c.CityName", conn);
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

        void bindCityGrid()
        {
            try
            {
                DataTable dataTable = new DataTable();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(" Select FavCity From FavCity order by FavCity asc", conn);
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);

                }
                if (dataTable.Rows.Count > 0)
                {

                    dgvCity.DataSource = dataTable;
                    dgvCity.DataBind();
                }
                else
                {

                    dataTable.Rows.Add(dataTable.NewRow());
                    dgvCity.DataSource = dataTable;
                    dgvCity.DataBind();
                    dgvCity.Rows[0].Cells.Clear();
                    dgvCity.Rows[0].Cells.Add(new TableCell());
                    dgvCity.Rows[0].Cells[0].ColumnSpan = dataTable.Columns.Count;
                    dgvCity.Rows[0].Cells[0].Text = "No Data Found ..!";
                    dgvCity.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void btnAddToFav_Click(object sender, EventArgs e)
        {
            if(selectCities.SelectedIndex > 0)
            {
                //check if favourite city already exist
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand checkFavCity = new SqlCommand("SELECT COUNT(*) FROM FavCity WHERE (FavCity = @FavCity)", conn);
                    checkFavCity.Parameters.AddWithValue("@FavCity", selectCities.Value);
                    conn.Open();
                    int CityExist = (int)checkFavCity.ExecuteScalar();
                    conn.Close();

                    if (CityExist > 0)
                    {
                        Response.Write("<script language=javascript>alert('City already added in favourite city list');</script>");
                    }
                    else
                    { 
                        SqlCommand cmd = new SqlCommand("insert into FavCity (FavCity) values (@FavCity)", conn);
                        cmd.Parameters.AddWithValue("@FavCity", selectCities.Value);
                        conn.Open();
                        int i = cmd.ExecuteNonQuery();
                        conn.Close();                        
                        bindCityGrid();
                    }
                }                
            }
            else
            {
                Response.Write("<script language=javascript>alert('Please select city');</script>");
            }            
        }

        protected void tbCityName_Click(object sender, EventArgs e)
        {
            bindgrid();
        }
    }
}