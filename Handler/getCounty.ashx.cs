using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Injection.Handler
{
    public class getCounty : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var stringResponse = "[";
            var stringInputState = HttpContext.Current.Request.QueryString["s"].ToString();

            var dataset = new DataSet();
            var sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["localhost"].ConnectionString;
            sqlConnection.Open();
            var sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "SELECT DISTINCT [County] FROM [dbo].[NationalFile] WHERE [State] = '" + stringInputState + "' ORDER BY [County]";

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
                dataAdapter.Fill(dataset);


            foreach (DataRow row in dataset.Tables[0].Rows)
            {
                stringResponse += "{\"value\":\"" + row[0].ToString() + "\"," + 
                    "\"text\":\"" +  row[0].ToString() + "\"},";
            }

            stringResponse = stringResponse.Substring(0, stringResponse.Length-1);
            stringResponse += "]";
            context.Response.Write(stringResponse);

        }

        public bool IsReusable
        { get { return false; } }
    }
}