using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo
{
    public class DBHelper
    {
        public static string CONN_STRING = "Data Source=DESKTOP-O8IU0PQ\\sqlexpress;Initial Catalog=Todo;User ID=sa;Password=Q1w2q1w2";
    }
    public static class Extensions
    {
        public static string GetStringOrNull(this SqlDataReader dr, int i)
        {
            if (dr.IsDBNull(i))
                return null;
            return dr.GetString(i);
        }
    }
}
