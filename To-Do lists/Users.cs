using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    public class Users
    {
        public int user_id { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        public DateTime Date_of_birth { get; set; }
        public DateTime Created_at { get; set; }
        public int List_id { get; set; }

        public static string ValidateUser(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.CONN_STRING)) {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT UserName,Pass FROM Users WHERE UserName = @UserName and Pass = @pass ");
                sb.Append("SELECT title FROM taskes left join lists on lists.list_id = taskes.list_id inner join Users on lists.user_id = Users.users_id where Users.UserName = @UserName ");
                using (SqlCommand command = new SqlCommand(sb.ToString(), conn)) {
                    command.Parameters.AddWithValue("@UserName", username);
                    command.Parameters.AddWithValue("@Pass", password);
                    conn.Open();
                    using (SqlDataReader dr = command.ExecuteReader()) {
                        if (dr.Read()) {
                            //if datareader = true retern titles/tasks fo the users...
                            for (int i=0; i <= 100; i++){
                                 "test";
                            }
                        }
                    }
                }
                return "something went wrong please try again later";
            }

        }
    }
}