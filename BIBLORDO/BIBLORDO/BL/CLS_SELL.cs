using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BIBLORDO.BL
{
    internal class CLS_SELL
    {
        DAL.CLS_DAL DAL = new BIBLORDO.DAL.CLS_DAL();
        //load DATA
        public DataTable LOAD()
        {
            SqlParameter[] pr = null;
            DataTable dt = new DataTable();
            dt = DAL.read("PR_LOADSELL", pr);
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
        public void Insert(string SNAME, string BTITLE, int PRICE, DateTime BDATE)
        {
            SqlParameter[] pr = new SqlParameter[4];
            pr[0] = new SqlParameter("SNAME", SNAME);
            pr[1] = new SqlParameter("BTITLE", BTITLE);
            pr[2] = new SqlParameter("PRICE", PRICE);
            pr[3] = new SqlParameter("BDATE", BDATE);
            DAL.open();
            DAL.Excute("PR_INSERTSELL", pr);
            DAL.close();
        }
        public DataTable LOADEDIT(int ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("ID", ID);
            DataTable dt = new DataTable();
            dt = DAL.read("PR_SELECTEDITSELL", pr);
            return dt;
        }

        public void Update(string SNAME, string BTITLE, int PRICE, DateTime BDATE, int ID)
        {
            SqlParameter[] pr = new SqlParameter[5];
            pr[0] = new SqlParameter("SNAME", SNAME);
            pr[1] = new SqlParameter("BTITLE", BTITLE);
            pr[2] = new SqlParameter("PRICE", PRICE);
            pr[3] = new SqlParameter("BDATE", BDATE);
            pr[4] = new SqlParameter("ID", ID);
            DAL.open();
            DAL.Excute("PR_UPDATETSELL", pr);
            DAL.close();
        }
        public void Delete(int ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("ID", ID);
            DAL.open();
            DAL.Excute("PR_SELLDELETE", pr);
            DAL.close();
        }
        public DataTable SEARCH(string search)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("SEARCH", search);
            DataTable dt = new DataTable();
            dt = DAL.read("P_SELLSEARCH", pr);
            return dt;
        }
    }
}
