using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace BIBLORDO.BL
{
    internal class CLS_EMP
    {
        DAL.CLS_DAL DAL = new BIBLORDO.DAL.CLS_DAL();
        //load
        public DataTable LOAD()
        {
            SqlParameter[] pr = null;
            DataTable dt = new DataTable();
            dt = DAL.read("PR_LOADEMP", pr);
            return dt;
        }
        public DataTable LOADBOOKS()
        {
            SqlParameter[] pr = null;
            DataTable dt = new DataTable();
            dt = DAL.read("PR_LOADBOOKFSELL", pr);
            return dt;
        }

        public DataTable LOADST()
        {
            SqlParameter[] pr = null;
            DataTable dt = new DataTable();
            dt = DAL.read("PR_LOADSTFSELL", pr);
            return dt;
        }
        public void Insert(string BNAME, string BTITLE, DateTime BDATE1, DateTime BDATE2, int PRICE)
        {
            SqlParameter[] pr = new SqlParameter[5];
            pr[0] = new SqlParameter("BNAME", BNAME);
            pr[1] = new SqlParameter("BTITLE", BTITLE);
            pr[2] = new SqlParameter("BDATE1", BDATE1);
            pr[3] = new SqlParameter("BDATE2", BDATE2);
            pr[4] = new SqlParameter("PRICE", PRICE);
            DAL.open();
            DAL.Excute("PR_INSERTEMP", pr);
            DAL.close();
        }
        public DataTable LOADEDIT(int ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("ID", ID);
            DataTable dt = new DataTable();
            dt = DAL.read("PR_SELECTEDITEMP", pr);
            return dt;
        }

        public void Update(string BNAME, string BTITLE, DateTime BDATE1, DateTime BDATE2, int PRICE, int ID)
        {
            SqlParameter[] pr = new SqlParameter[6];
            pr[0] = new SqlParameter("BNAME", BNAME);
            pr[1] = new SqlParameter("BTITLE", BTITLE);
            pr[2] = new SqlParameter("BDATE1", BDATE1);
            pr[3] = new SqlParameter("BDATE2", BDATE2);
            pr[4] = new SqlParameter("PRICE", PRICE);
            pr[5] = new SqlParameter("ID", ID);
            DAL.open();
            DAL.Excute("PR_EDITEMP", pr);
            DAL.close();
        }
        public void Delete(int ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("ID", ID);
            DAL.open();
            DAL.Excute("PR_EMPDELETE", pr);
            DAL.close();
        }
        public DataTable SEARCH(string search)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("SEARCH", search);
            DataTable dt = new DataTable();
            dt = DAL.read("P_EMPSEARCH", pr);
            return dt;
        }
    }
}
