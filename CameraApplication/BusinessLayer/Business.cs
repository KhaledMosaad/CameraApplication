using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CameraProject.DataAccess;

namespace CameraProject.BusinessLayer
{
    class Business
    {
        /// <summary>
        /// Get All Images for Someone
        /// </summary>
        /// <param name="id"></param>
        /// <returns> return DataTable that filled by the data from database </returns>
        public DataTable GetImages(int id)
        {
            Dataaccess da = new Dataaccess();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = id;
            DataTable dt = new DataTable();
            dt=da.SelectData("GetImages", param);
            return dt;
        }
        /// <summary>
        /// store image on database for later usage
        /// </summary>
        /// <param name="id"></param>
        /// <param name="image"></param>
        /// <param name="dateTime"></param>
        public void AddImage (int id,byte[] image,string dateTime,string ImageName)
        {
            Dataaccess da = new Dataaccess();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = id;
            param[1] = new SqlParameter("@Image", SqlDbType.Image);
            param[1].Value = image;
            param[2] = new SqlParameter("@DateTime", SqlDbType.VarChar);
            param[2].Value = dateTime;
            param[3] = new SqlParameter("@ImageName", SqlDbType.VarChar);
            param[3].Value = ImageName;
            da.OpenConnection();
            da.ExecutedCommand("AddImage", param);
            da.CloseConnection();
        }
        public void AddPerson(string fistName, string processorid)
        {
            Dataaccess da = new Dataaccess();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@FirstName", SqlDbType.VarChar,22);
            param[0].Value = fistName;
            param[1] = new SqlParameter("@ProcessorID", SqlDbType.VarChar);
            param[1].Value = processorid;
            da.OpenConnection();
            da.ExecutedCommand("AddPerson", param);
            da.CloseConnection();
        }
        public DataTable SelectPersonID(string processorId)
        {
            Dataaccess da = new Dataaccess();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ProcessorID", SqlDbType.VarChar);
            param[0].Value = processorId;
            DataTable dt = new DataTable();
            dt=da.SelectData("SelectPersonID", param);
            return dt;
        }
        public DataTable SelectAllImage(int id)
        {
            Dataaccess da = new Dataaccess();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = id;
            DataTable dt = new DataTable();
            dt = da.SelectData("SelectAllImage", param);
            return dt;
        }
        public void DeleteImage(int personid,string dt)
        {
            Dataaccess da = new Dataaccess();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@PersonID", SqlDbType.Int);
            param[0].Value = personid;
            param[1] = new SqlParameter("@Date", SqlDbType.VarChar);
            param[1].Value = dt;
            da.OpenConnection();
            da.ExecutedCommand("DeleteImage", param);
            da.CloseConnection();
        }
    }
}
