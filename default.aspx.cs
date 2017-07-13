using System;
using System.Configuration;
using System.Data.Odbc;

public partial class _Default : System.Web.UI.Page
{
	protected void Reiniciar_Click(object sender, EventArgs e)
	{
        try
        {
            using (OdbcConnection connection = new OdbcConnection(ConfigurationManager.ConnectionStrings["MySQLConnStr"].ConnectionString))
            { // http://asp.net-tutorials.com/mysql/getting-started/
                connection.Open();
                /*using (OdbcCommand command = new OdbcCommand("SELECT name FROM test_users", connection))
                using (OdbcDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                        Response.Write(dr["name"].ToString() + "<br />");
                    dr.Close();
                }*/
                Reini_msg.Text = "Connected to Database Server !!";
                connection.Close();
            }
        }
        catch (Exception ex)
        {
            Reini_msg.Text = "An error occured: " + ex.Message;
        }
	}
}