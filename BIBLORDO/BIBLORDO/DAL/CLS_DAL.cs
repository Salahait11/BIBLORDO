using System;
using System.Data;
using System.Data.SqlClient;

namespace BIBLORDO.DAL
{
    internal class CLS_DAL
    {
        SqlConnection con = new SqlConnection();
        public CLS_DAL()
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DBBIBLORD.mdf;Integrated Security=True");

        }
        public void open()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
        }
        public void close()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();

            }
        }
        public DataTable read(String store, SqlParameter[] pr)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;
            if (pr != null)
            {
                cmd.Parameters.AddRange(pr);

            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void Excute(String store, SqlParameter[] pr)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = store;
            if (pr != null)
            {
                cmd.Parameters.AddRange(pr);

            }
            cmd.ExecuteNonQuery();
        }

    }
}
