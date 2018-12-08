using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal;

namespace ToDo
{
    public class Users
    {
        public string UserName { get; set; }
        public string Pass { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public char Gender { get; set; }
        public DateTime Date_of_birth { get; set; }


        public static object ValidateUser(string UserName, string password)
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.CONN_STRING)) {
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

        public static object Ticket(string UserName)
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.CONN_STRING)) {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("spGetAllTasksForUser", conn)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", SqlDbType.VarChar).Value = UserName;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            string task = "";
                            for (int i = 0; i < 100; i++) {
                                task = dr.GetString(i);
                            }

                            return task;
                        }

                        return null;
                    }
                }
            }
        }


        internal static bool Register(string userName, string pass, string fName, string lName, char gender, DateTime date_of_birth)
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.CONN_STRING)) {
                StringBuilder sb = new StringBuilder();
                sb.Append(
                    "insert INTO USERS (UserName,Pass,FirstName,LastName,gender,date_of_birth) values('@UaerName', '@Pass', '@Fname', '@LName', '@gender', '@Date_of_birth';");
                using (SqlCommand cmd = new SqlCommand(sb.ToString())) {
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    cmd.Parameters.AddWithValue("@Pass", pass);
                    cmd.Parameters.AddWithValue("@Fname", fName);
                    cmd.Parameters.AddWithValue("@Lname", lName);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@Date_of_birth", date_of_birth);
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader()) {
                        if (!dr.Read()) return false;
                        return true;


                    };
                };
            };
        }
    }
}
