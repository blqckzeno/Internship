using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;

namespace Internship.Hubs
{
    [HubName("InterHub")]
    public class InterHub : Hub
    {

        public static void Show()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<InterHub>();
            context.Clients.All.displayInternship();
        }
        [HubMethodName("MyNewMethodName")]
        public void MyNewMethodName(string name, string message)
        {
            Thread.Sleep(5000);
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CustomerConnection"].ConnectionString))
            {
                connection.Open();
                //call the broadcast message to upadate the clients.
                string sql = "INSERT INTO [notification] (description,email,message,mobile,name,state,sys_notif_date,owner_id) VALUES(@param2,@param3,@param4,@param5,@param6,@param7,@param8,@param9)";
                //using (SqlCommand cmd = new SqlCommand(sql, connection))
                //{
                //    cmd.Parameters.AddWithValue("@param2", "test");
                //    cmd.Parameters.AddWithValue("@param3", "test");
                //    cmd.Parameters.AddWithValue("@param4", "test");
                //    cmd.Parameters.AddWithValue("@param5", "test");
                //    cmd.Parameters.AddWithValue("@param6", "test");
                //    cmd.Parameters.AddWithValue("@param7", 111111);
                //    cmd.Parameters.AddWithValue("@param8", "1994/11/03");
                //    cmd.Parameters.AddWithValue("@param9", 1);


                //    cmd.ExecuteNonQuery();


                //}
            }
        }

    }
}