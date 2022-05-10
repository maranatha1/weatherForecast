using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using DataAccess;

namespace POE_AdvancedWeatherForecastingSystem
{
    public partial class Weather : System.Web.UI.Page
    {
        WeatherUpdateDBAccess weatherUpdateDBAccess = new WeatherUpdateDBAccess();
        WeatherCondition weatherCondition = new WeatherCondition();
        WeatherUpdateBL WeatherUpdateBL = new WeatherUpdateBL();
        string connectionString = ConfigurationManager.ConnectionStrings["WeatherForecast"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                bindgrid();
            }
           
        }
        public void ClearFields()
        {
            //clear textboxes
            tbCityName.Text = "";
            tbDate.Text = "";
            tbMinTemp.Text = "";
            tbMaxTemp.Text = "";
            tbPercipation.Text = "";
            tbHumidity.Text = "";
            tbWindSpeed.Text = "";
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

        protected void btnAddWeather_Click(object sender, EventArgs e)
        {
            try
            {
                if(tbCityName.Text !="" && tbDate.Text != "" && tbMinTemp.Text!="" && tbMaxTemp.Text !="" && tbPercipation.Text!="" && tbHumidity.Text!="" && tbWindSpeed.Text !="")
                {
                    //Assign textbox fields
                    weatherCondition.CityName = tbCityName.Text;
                    weatherCondition.Date = tbDate.Text;
                    weatherCondition.MinimumTemperature = tbMinTemp.Text;
                    weatherCondition.MaximumTemperature  = tbMaxTemp.Text;
                    weatherCondition.Percipation = tbPercipation.Text;
                    weatherCondition.Humidity = tbHumidity.Text;
                    weatherCondition.WindSpeed = tbWindSpeed.Text;

                    if (WeatherUpdateBL.InsertWeatherUpdate(weatherCondition) == true)
                    {
                        bindgrid();
                        Response.Write("<script language=javascript>alert('Weather Update Added successfully');</script>");
                    }
                    else
                    {
                        Response.Write("<script language=javascript>alert('Weather Update not added');</script>");
                    }
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Make sure all fields are filled');</script>");
                }

                ClearFields();
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }


        protected void dgvWeatherUpdate_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO PhoneBook (FirstName,LastName,Contact,Email) VALUES (@FirstName,@LastName,@Contact,@Email)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@FirstName", (dgvWeatherUpdate.FooterRow.FindControl("txtFirstNameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@LastName", (dgvWeatherUpdate.FooterRow.FindControl("txtLastNameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Contact", (dgvWeatherUpdate.FooterRow.FindControl("txtContactFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Email", (dgvWeatherUpdate.FooterRow.FindControl("txtEmailFooter") as TextBox).Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        //PopulateGridview();
                        lblSuccessMessage.Text = "Successfully Added New Row Added";
                        lblErrorMessage.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void dgvWeatherUpdate_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvWeatherUpdate.EditIndex = e.NewEditIndex;
            bindgrid();
        }

        protected void dgvWeatherUpdate_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgvWeatherUpdate.EditIndex = -1;
            bindgrid();
        }

        protected void dgvWeatherUpdate_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (WeatherUpdateBL.UpdateWeatherDetails(weatherCondition) == true)
            {
                bindgrid();
                Response.Write("<script language=javascript>alert('Weather details updated successfully');</script>");
            }
            else
            {
                Response.Write("<script language=javascript>alert('Weather Update not added');</script>");
            }            
        }

        protected void dgvWeatherUpdate_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM PhoneBook WHERE PhoneBookID = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(dgvWeatherUpdate.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    bindgrid();
                    lblSuccessMessage.Text = "Selected successfully deleted";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }
    } 
}