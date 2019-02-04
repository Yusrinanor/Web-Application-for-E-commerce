using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ad_ViewAllOrders : System.Web.UI.Page
{
    private SqlConnection connection;
    private SqlCommand command;

    protected void Page_Load(object sender, EventArgs e)
    {
        
            if (Session["UserName"] == null)
            {
            Response.Redirect("Ad_Log.aspx");
        }

    }

    protected void btnUpdate_Click1(object sender, EventArgs e)
    {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            string connectionString = ConfigurationManager.ConnectionStrings["WAPPDBEntitiesConnectionString"].ToString(); // Makes connectionString 

            connection = new SqlConnection(connectionString);
            command = new SqlCommand("", connection);

            // Used for Checking database Row by row to check if ID exists //
            command.Connection = connection;
            string query = "UPDATE transaction1 SET DeliveryStatus = @DeliveryStatus WHERE tranid = @tranid ";
            SqlCommand cmd = new SqlCommand(query, connection);
            string Fulfilled = "Fulfilled";
            cmd.Parameters.AddWithValue("@tranid", txtDeliveryID.Text.ToString());
            cmd.Parameters.AddWithValue("@DeliveryStatus", Fulfilled);
            cmd.Connection.Open(); // Open Connection to the database (refer to connection declaration above) //

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
            finally
            {
                Response.Redirect("../Staff WEBPAGES/managecustomerorder.aspx");

            }

        }
        else
        {

        }
    }
}
