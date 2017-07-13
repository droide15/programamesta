using System;
using System.Data ;
using System.Data.SqlClient ;
using System.Configuration; 

public partial class _Default : System.Web.UI.Page
{
	protected void Button1_Click(object sender, EventArgs e)
	{
		string connectionString = ConfigurationManager.ConnectionStrings["SQLDbConnection"].ToString();
		SqlConnection connection = new SqlConnection(connectionString);
		connection.Open();
		Label1.Text = "Connected to Database Server !!";
		connection.Close();
	}
}