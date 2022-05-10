using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccess
{
    public class DBHelper
    {
        private static string constring = ConfigurationManager.ConnectionStrings ["WeatherForecast"].ConnectionString;
        //==================================================================================================================================================================================================
        #region ExecuteScalarCommand()
        internal static DataTable ExecuteScalarCommand(string commandName, CommandType cmdType)
        {
            DataTable table = null;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = commandName;

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            table = new DataTable();
                            da.Fill(table);
                        }
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();

                    }
                }
            }
            return table;
        }
        #endregion ExecuteScalarCommand()
        //==================================================================================================================================================================================================
        #region ExecuteParamerizedSelectCommand()
        internal static DataTable ExecuteParamerizedSelectCommand(string commandName, CommandType cmdType,
            SqlParameter[] param)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = commandName;
                    cmd.Parameters.AddRange(param);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(table);
                        }
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }
            }
            return table;
        }
        #endregion ExecuteParamerizedSelectCommand()
        //==================================================================================================================================================================================================
        #region ExecuteNonQuery()
        internal static bool ExecuteNonQuery(string commandName, CommandType cmdType,
            SqlParameter[] pars)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = commandName;
                    cmd.Parameters.AddRange(pars);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }
            }
            return result > 0;
        }
        #endregion ExecuteNonQuery()
        //==================================================================================================================================================================================================
        #region ExecuteSelectCommand()
        internal static DataTable ExecuteSelectCommand(string commandName, CommandType cmdType)
        {
            DataTable table = null;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = commandName;


                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            table = new DataTable();
                            da.Fill(table);
                        }
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }
            }
            return table;
        }
        #endregion ExecuteSelectCommand()
        //==================================================================================================================================================================================================

    }
}

