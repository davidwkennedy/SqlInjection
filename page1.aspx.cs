using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Injection
{
    public partial class page1 : System.Web.UI.Page
    {
        private SqlConnection sqlConnection = new SqlConnection();

        protected void Page_Load(object sender, EventArgs e)
        {

            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["localhost"].ConnectionString;
            sqlConnection.Open();
            var dataset = new DataSet();
            var dataset2 = new DataSet();
            var sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            
            sqlCommand.CommandText = "SELECT DISTINCT(State) FROM [dbo].[NationalFile] ORDER BY [State]";
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
                dataAdapter.Fill(dataset);
            foreach (DataRow dr in dataset.Tables[0].Rows)
                cbxState.Items.Add(new ListItem(dr[0].ToString(), dr[0].ToString()));

            sqlCommand.CommandText = "SELECT DISTINCT(Type) FROM [dbo].[NationalFile] ORDER BY [Type]";
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
                dataAdapter.Fill(dataset2);
            foreach (DataRow dr in dataset2.Tables[0].Rows)
                cbxFeature.Items.Add(new ListItem(dr[0].ToString(), dr[0].ToString()));

            sqlConnection.Close();
        }

        public void btnSearch_Click(object sender, EventArgs e)
        {
            pnlResults.Visible = true;
            sqlConnection.Open();
            var sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = "SELECT [Name], [primary_lat_dms], [Prim_Long_DMS], [prim_lat_dec],[prim_long_dec] FROM [dbo].[NationalFile] WHERE " +
            "[state] = '" + cbxState.SelectedValue + "' AND [County] = '" + cbxCounty.SelectedValue + "' " +
            "AND [type] = '" + cbxFeature.SelectedValue + "' ORDER BY [Name]";

            var dataset = new DataSet();
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
                dataAdapter.Fill(dataset);

            rptResults.DataSource = dataset;
            rptResults.DataBind();
            sqlConnection.Close();
        }
    }
}