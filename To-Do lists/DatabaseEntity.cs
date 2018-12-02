using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ToDo
{
    public abstract class DatabaseEntity{
        protected abstract Column[] Columns { get; }
        protected abstract string TableName { get; }
        protected abstract Column PrimaryKey { get; }

        public delegate T ItemCreator<T>(SqlDataReader dr);
        private string GetColumnsCommaSeparated(bool withPrimaryKey, bool withAtSign = false)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Column col in Columns) {
                if (!withPrimaryKey && col.ColumnType == ColumnType.PRIMARY_KEY)
                    continue;
                if (withAtSign)
                    sb.Append("@");
                sb.Append(col.Name + ",");
            }
            if (Columns.Length > 0) sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
         public string SelectSql()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ");
            sb.Append(GetColumnsCommaSeparated(true));
            sb.Append(" FROM " + TableName);
            return sb.ToString();
        }
        public List<T> GetList<T>(ItemCreator<T> itemCreator)
        {
            List<T> item = new List<T>();
            using (SqlConnection conn = new SqlConnection(DBHelper.CONN_STRING)) {
                conn.Open();
                using (SqlCommand command = new SqlCommand(SelectSql(), conn)) {
                    using (SqlDataReader dr = command.ExecuteReader()) {
                        while (dr.Read()) {
                            T databaseEntity = itemCreator(dr);
                            item.Add(databaseEntity);
                        }
                    }
                }
            }
            return item;
        }
         public bool Delete(object PrimaryKeyToBeDeleted)
        {
            using (SqlConnection conn = new SqlConnection(DBHelper.CONN_STRING)) {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(DeleteSQL(), conn)) {
                    cmd.Parameters.AddWithValue("@" + PrimaryKey.Name, PrimaryKeyToBeDeleted);
                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        private string DeleteSQL()
        {
            StringBuilder sb = new StringBuilder();
            if (PrimaryKey == null) {
                throw new Exception("Cannot delete without Ticket Number.");
            }
            sb.Append("DELETE FROM " + TableName + "WHERE " + PrimaryKey + "=@" + PrimaryKey);
            return sb.ToString();
        }

        public string InsertSQL()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO" + TableName + " (");
            sb.Append(GetColumnsCommaSeparated(false) + ") VALUSE (");
            sb.Append(GetColumnsCommaSeparated(false, true) + ")");
            return sb.ToString();
        }

        public string Update(SqlParameter[] parameters)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE " + TableName);
            sb.Append("SET " + GetColumnsCommaSeparated(false) + ") VALUES (");
            sb.Append(GetColumnsCommaSeparated(false, true) + ")");
            return sb.ToString();
        }
        public static object ValidateUser(string UserName,string Password){
            using (SqlConnection conn = new SqlConnection(DBHelper.CONN_STRING)){
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT UserName,Pass FROM Users WHERE UserName = @UserName and Pass = @pass");
                sb.Append("SELECT user_id,title,done from taskes left join lists on taskes.list_id = lists.list_id right join Users on Users.users_id = lists.list_id where user_id =@UserName");
                using(SqlCommand command = new SqlCommand(sb.ToString(),conn)){
                    command.Parameters.AddWithValue("@UserName",UserName);
                    command.Parameters.AddWithValue("@Pass",Password);
                    conn.Open();
                    using(SqlDataReader dr = command.ExecuteReader()){
                        if(dr.Read()){
                            for(int i = 0; i <= 1000 ; i ++ ){
                            string title = dr.ToString();
                            return title;
                            }
                        }
                    }
                }return -1;
            }

        }   

    }
    
}