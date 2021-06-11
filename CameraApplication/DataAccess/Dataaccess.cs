using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace CameraProject.DataAccess
{
    public class Dataaccess
    {
        private SqlConnection sqlConnection;
        public Dataaccess()
        {
            sqlConnection = new SqlConnection(@"Server=KHALED; Database=CAMERA_DB; Integrated Security=true");
        }
        public void OpenConnection()
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
        }
        public void CloseConnection()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        public DataTable SelectData(string storedProcedure,SqlParameter[] param)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType =CommandType.StoredProcedure;
            cmd.CommandText = storedProcedure;
            cmd.Connection = sqlConnection;
            if(param!=null)
            {
                cmd.Parameters.AddRange(param);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            da.Fill(data);
            return data;
        }
        public void ExecutedCommand(string storedProcedure,SqlParameter[] param)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = storedProcedure;
            cmd.Connection = sqlConnection;
            if(param!=null)
            {
                cmd.Parameters.AddRange(param);
            }
            cmd.ExecuteNonQuery();
        }
    }
}
