using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIBLORDO.PL
{
    public partial class FRM_LOGIN : Form
    {
        public FRM_LOGIN()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                BL.CLS_USERS CLSUSERS = new BL.CLS_USERS();
                DataTable dt = new DataTable();
                dt = CLSUSERS.LOGIN(txt_username.Text, txt_password.Text);
                if (dt.Rows.Count > 0)
                {
                    CLSUSERS.UpdateLogin(txt_username.Text, txt_password.Text);
                    PL.FRM_MAIN MAIN = new PL.FRM_MAIN();
                    object lbname = dt.Rows[0]["CNAME"];
                    object lbprem = dt.Rows[0]["CPREM"];
                    MAIN.lbname.Text= lbname.ToString();
                    MAIN.lbprem.Text = lbprem.ToString();
                    MAIN.Show();
                    this.Close();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("ERREUR DANS LES INFORMATIONS D'INSCRIPTION");
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
