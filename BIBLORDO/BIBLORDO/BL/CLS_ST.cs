using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace BIBLORDO.BL
{
    internal class CLS_ST
    {
        DAL.CLS_DAL DAL = new BIBLORDO.DAL.CLS_DAL();
        //load
        public DataTable LOAD()
        {
            SqlParameter[] pr = null;
            DataTable dt = new DataTable();
            dt = DAL.read("PR_LOADST", pr);
            return dt;
        }
        public void Insert(string NAME, string ADRESSE, string PHONE, string EMAIL, string SCHOOL, string FILIERE, MemoryStream COVER)
        {
            SqlParameter[] pr = new SqlParameter[7];
            pr[0] = new SqlParameter("NAME", NAME);
            pr[1] = new SqlParameter("ADRESSE", ADRESSE);
            pr[2] = new SqlParameter("PHONE", PHONE);
            pr[3] = new SqlParameter("EMAIL", EMAIL);
            pr[4] = new SqlParameter("SCHOOl", SCHOOL);
            pr[5] = new SqlParameter("FILIERE", FILIERE);
            pr[6] = new SqlParameter("COVER", COVER.ToArray());
            DAL.open();
            DAL.Excute("PR_INSERTST", pr);
            DAL.close();
        }
        public DataTable LOADEDIT(int ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("ID", ID);
            DataTable dt = new DataTable();
            dt = DAL.read("PR_SELECTEDITST", pr);
            return dt;
        }

        public void Update(string NAME, string ADRESSE, string PHONE, string EMAIL, string SCHOOL, string FILIERE, MemoryStream COVER, int ID)
        {
            SqlParameter[] pr = new SqlParameter[8];
            pr[0] = new SqlParameter("NAME", NAME);
            pr[1] = new SqlParameter("ADRESSE", ADRESSE);
            pr[2] = new SqlParameter("PHONE", PHONE);
            pr[3] = new SqlParameter("EMAIL", EMAIL);
            pr[4] = new SqlParameter("SCHOOl", SCHOOL);
            pr[5] = new SqlParameter("FILIERE", FILIERE);
            pr[6] = new SqlParameter("COVER", COVER.ToArray());
            pr[7] = new SqlParameter("ID", ID);
            DAL.open();
            DAL.Excute("PR_EDITST", pr);
            DAL.close();
        }
        public void Delete(int ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("ID", ID);
            DAL.open();
            DAL.Excute("P_DELETEST", pr);
            DAL.close();
        }
        public DataTable SEARCH(string search)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("SEARCH", search);
            DataTable dt = new DataTable();
            dt = DAL.read("PR_SEARCHST", pr);
            return dt;
        }
    }
}
