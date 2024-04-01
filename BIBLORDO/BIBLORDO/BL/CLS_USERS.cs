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
    internal class CLS_USERS
    {
        DAL.CLS_DAL DAL = new BIBLORDO.DAL.CLS_DAL();
        //load
        public DataTable LOAD()
        {
            SqlParameter[] pr = null;
            DataTable dt = new DataTable();
            dt = DAL.read("PR_LOADUSER", pr);
            return dt;
        }
        //INSERT DATA
        public void Insert(string CNAME, string CUSERNAME, string CPASSWORD, string CPREM, string CSTATE)
        {
            SqlParameter[] pr = new SqlParameter[5];
            pr[0] = new SqlParameter("CNAME", CNAME);
            pr[1] = new SqlParameter("CUSERNAME", CUSERNAME);
            pr[2] = new SqlParameter("CPASSWORD", CPASSWORD);
            pr[3] = new SqlParameter("CPREM", CPREM);
            pr[4] = new SqlParameter("CSTATE", CSTATE);
            DAL.open();
            DAL.Excute("PR_INSERTUSER", pr);
            DAL.close();
        }
        public DataTable LOADEDIT(int ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("ID", ID);
            DataTable dt = new DataTable();
            dt = DAL.read("PR_SELECTEDITUSERS", pr);
            return dt;
        }
        //UPDATE DATA
        public void Update(string CNAME, string CUSERNAME, string CPASSWORD, string CPREM, int ID)
        {
            SqlParameter[] pr = new SqlParameter[5];
            pr[0] = new SqlParameter("CNAME", CNAME);
            pr[1] = new SqlParameter("CUSERNAME", CUSERNAME);
            pr[2] = new SqlParameter("CPASSWORD", CPASSWORD);
            pr[3] = new SqlParameter("CPREM", CPREM);
            pr[4] = new SqlParameter("ID", ID);
            DAL.open();
            DAL.Excute("PR_UPDATETUSER", pr);
            DAL.close();
        }
        public void Delete(int ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("ID", ID);
            DAL.open();
            DAL.Excute("PR_USERSDELETE", pr);
            DAL.close();
        }
        //logout
        public void Logout()
        {
            SqlParameter[] pr = null;
            DAL.open();
            DAL.Excute("PR_LOGOUT", pr);
            DAL.close();
        }
        //load FOR LOGIN
        public DataTable LOGIN(string CUSERNAME, string CPASSWORD)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("CUSERNAME", CUSERNAME);
            pr[1] = new SqlParameter("CPASSWORD", CPASSWORD);
            DataTable dt = new DataTable();
            dt = DAL.read("PR_LOGIN", pr);
            return dt;
        }
        //update data for login
        public void UpdateLogin(string CUSERNAME, string CPASSWORD)
        {
            SqlParameter[] pr = new SqlParameter[2];
            pr[0] = new SqlParameter("CUSERNAME", CUSERNAME);
            pr[1] = new SqlParameter("CPASSWORD", CPASSWORD);
            DAL.open();
            DAL.Excute("PR_UPDATELOGIN", pr);
            DAL.close();
        }
        //load for check start
        public DataTable STARTLOAD()
        {
            SqlParameter[] pr = null;
            DataTable dt = new DataTable();
            dt = DAL.read("PR_START", pr);
            return dt;
        }

    }
}

