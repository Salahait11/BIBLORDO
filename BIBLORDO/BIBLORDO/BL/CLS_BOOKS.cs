using NUnit.Framework;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace BIBLORDO.BL
{
    
    internal class CLS_BOOKS
    {
        
        DAL.CLS_DAL DAL = new BIBLORDO.DAL.CLS_DAL();
        //load
        public DataTable LOAD()
        {
            SqlParameter[] pr = null;
            DataTable dt = new DataTable();
            dt = DAL.read("PR_LOADBOOKS", pr);
            return dt;
        }
        //combobox cat
        public DataTable LOADCAT()
        {
            DataTable dt = new DataTable();
            try
            {
                // Appeler la méthode read de DAL pour exécuter la procédure stockée et récupérer les données de catégorie
                dt = DAL.read("PR_LOADCATCOMBO", null); // Pas de paramètres requis pour cette procédure stockée
            }
            catch (Exception ex)
            {
                // Gérer les exceptions
                Console.WriteLine("Erreur lors du chargement des catégories : " + ex.Message);
            }
            return dt;
        }
        //INSERT DATA
        public void Insert(string TITLE, string AUTEUR, string CAT, string PRICE, string BDATE, int RATE, MemoryStream COVER)
        {
            SqlParameter[] pr = new SqlParameter[7];
            pr[0] = new SqlParameter("TITLE", TITLE);
            pr[1] = new SqlParameter("AUTEUR", AUTEUR);
            pr[2] = new SqlParameter("CAT", CAT);
            pr[3] = new SqlParameter("PRICE", PRICE);
            pr[4] = new SqlParameter("BDATE", BDATE);
            pr[5] = new SqlParameter("RATE", RATE);
            pr[6] = new SqlParameter("COVER", COVER.ToArray());
            DAL.open();
            DAL.Excute("PR_INSERTBOOKS", pr);
            DAL.close();
        }
        //load data for edit
        public DataTable LOADEDIT(int ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("ID", ID);
            DataTable dt = new DataTable();
            dt = DAL.read("PR_SELECTEDIT", pr);
            return dt;
        }
        public void Update(string TITLE, string AUTEUR, string CAT, string PRICE, string BDATE, int RATE, MemoryStream COVER, int ID)
        {
            SqlParameter[] pr = new SqlParameter[8];
            pr[0] = new SqlParameter("TITLE", TITLE);
            pr[1] = new SqlParameter("AUTEUR", AUTEUR);
            pr[2] = new SqlParameter("CAT", CAT);
            pr[3] = new SqlParameter("PRICE", PRICE);
            pr[4] = new SqlParameter("BDATE", BDATE);
            pr[5] = new SqlParameter("RATE", RATE);
            pr[6] = new SqlParameter("COVER", COVER.ToArray());
            pr[7] = new SqlParameter("ID", ID);
            DAL.open();
            DAL.Excute("PR_EDITBOOKS", pr);
            DAL.close();
        }
        public void Delete(int ID)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("ID", ID);
            DAL.open();
            DAL.Excute("P_DELETEBOOKS", pr);
            DAL.close();
        }
        public DataTable SEARCH(string search)
        {
            SqlParameter[] pr = new SqlParameter[1];
            pr[0] = new SqlParameter("SEARCH", search);
            DataTable dt = new DataTable();
            dt = DAL.read("P_BOOKSSEARCH", pr);
            return dt;
        }
    }
}
