using System.Data;
using System.Data.SqlClient;

namespace BIBLORDO.BL
{
    internal class CLS_CAT
    {
        DAL.CLS_DAL DAL = new BIBLORDO.DAL.CLS_DAL();
        //load
        public DataTable LOAD()
        {
            SqlParameter[] pr = null;
            DataTable dt = new DataTable();
            dt = DAL.read("PR_LOAD_CAT", pr);
            return dt;
        }
        //search
        public DataTable SEARCH(string search)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("SEARCH", search);
            DataTable dt = new DataTable();
            dt = DAL.read("P_CATSEARCH", pr);
            return dt;
        }
        public void Insert(string CAT_NAME)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("CAT_NAME", CAT_NAME);
            DAL.open();
            DAL.Excute("P_ADDCAT", pr);
            DAL.close();
        }
        public void Update(string CAT_NAME, int ID)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("CAT_NAME", CAT_NAME);
            pr[1] = new SqlParameter("ID", ID);
            DAL.open();
            DAL.Excute("P_EDITCAT", pr);
            DAL.close();
        }
        public void Delete(int ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("ID", ID);
            DAL.open();
            DAL.Excute("P_DELETECAT", pr);
            DAL.close();
        }
    }
}
