using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;

namespace POE_AdvancedWeatherForecastingSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
           

            try
            {
                string cs = ConfigurationManager.ConnectionStrings["WeatherForecast"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("Select * from [User] where User_Email= '"+tbEmail.Text+"' and User_Password='"+tbPassword.Text+"'", conn);
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if(dt.Rows.Count != 0)
                    {
                        Session["User_Email"] = tbEmail.Text;
                        if (tbEmail.Text == "admin@weatherforecast.co.za" && tbPassword.Text == "password1234")
                        {
                           
                            Response.Redirect("AdminHome.aspx");
                        }
                        else
                        {                            
                            Response.Redirect("GeneralUser.aspx");
                        }

                    }
                    else
                    {
                        Response.Write("<script language=javascript>alert('Incorrect Password or Username');</script>");
                    }

                }
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}