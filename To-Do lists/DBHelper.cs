using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using ToDo.wwwroot;

namespace ToDo
{
    public class DBHelper
    {
        public static string CONN_STRING =
            "Data Source=DESKTOP-O8IU0PQ\\sqlexpress;Initial Catalog=Todo;User ID=sa;Password=Q1w2q1w2";



        public static object ValidateUser(string UserName, string password)
        {
            using (SqlConnection conn = new SqlConnection(CONN_STRING)) {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT UserName,Pass FROM Users WHERE UserName = @UserName and Pass = @pass ");
                using (SqlCommand command = new SqlCommand(sb.ToString(), conn)) {
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Pass", password);
                    conn.Open();
                    using (SqlDataReader dr = command.ExecuteReader()) {
                        return dr.Read() ? (object)Ticket(UserName) : -1;
                    }
                }
            }
        }

        internal static bool Register(string userName, string pass, string fName, string lName, char gender, DateTime date_of_birth)
        {
            throw new NotImplementedException();
        }

        public static List<ListAndTasks> Ticket(string UserName)
        {
            using (SqlConnection conn = new SqlConnection(CONN_STRING))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT title FROM tasks left join users on users.users_id = tasks.user_id where Users.UserName = @UserName", conn))
                {
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        List<ListAndTasks> tickets = new List<ListAndTasks>();
                        while (dr.Read())
                        {
                            ListAndTasks ticket = new ListAndTasks(dr.GetString(0));
                            tickets.Add(ticket);
                            
                        }
                        
                        return tickets;
                    }
                }
            }
        }

        public static bool AddNewTask(string UserName, string TodoText)
        {
            using (SqlConnection conn = new SqlConnection(CONN_STRING))
            {
                conn.Open();
                
                using (SqlCommand cmd = new SqlCommand("insert into Tasks (title,status,user_id) values ('@title',0,@user_id)", conn))
                {
                    cmd.Parameters.AddWithValue("@title", TodoText);
                    cmd.Parameters.AddWithValue("@user_id", GetUserId(UserName));
                    using (SqlDataReader dr = cmd.ExecuteReader())
                        return dr.Read();
                }
            }
        }
        public static int GetUserId(string UserName)
        {
            using (SqlConnection conn = new SqlConnection(CONN_STRING)) {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Select users_id from Users where UserName = @UserName", conn)) {
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        return dr.GetInt32(0);
                    }

                }
            }
        }
    }
}
