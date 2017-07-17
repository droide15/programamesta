using System;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using LumenWorks.Framework.IO.Csv;
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
                
                OdbcCommand MyCommand =
                  new OdbcCommand("TRUNCATE TABLE sat_catalogos",
                                  connection);
                MyCommand.ExecuteNonQuery();

                FileInfo archivo = new FileInfo(Server.MapPath(".") + @"\sat_catalogos.csv");

                using (CsvReader csv = new CsvReader(new StreamReader(archivo.FullName), true))
                {
                    int fieldCount;
                    string ms_campos;
                    string ms_valores;
                    List<String> valores = new List<string>();

                    fieldCount = csv.FieldCount;
                    ms_campos = string.Join(",", csv.GetFieldHeaders());
                    while (csv.ReadNextRecord())
                    {
                        if (string.IsNullOrEmpty(csv[0]))
                            continue;
                        valores.Clear();
                        for (int i = 0; i < fieldCount; i++)
                            valores.Add("\"" + csv[i] + "\"");
                        ms_valores = string.Join(",", valores.ToArray());

                        MyCommand.CommandText = "INSERT INTO sat_catalogos VALUES(" + ms_valores + ")";
                        MyCommand.ExecuteNonQuery();
                    }
                }

                connection.Close();

                Reini_msg.Text = "La tabla de catalogos ha sido reiniciada a su estado original";
            }
        }
        catch (Exception ex)
        {
            Reini_msg.Text = "An error occured: " + ex.Message;
        }
    }
}