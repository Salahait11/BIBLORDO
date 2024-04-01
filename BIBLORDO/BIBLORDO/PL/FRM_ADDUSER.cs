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
    public partial class FRM_ADDUSER : Form
    {
        public int ID;
        public FRM_ADDUSER()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txt_timer.Text = DateTime.Now.ToString();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txt_name.Text == "" || txt_username.Text == "" || txt_password.Text == "" || txt_prem.Text == "")
            {
                PL.FRM_ERRORINSERT FERROR = new PL.FRM_ERRORINSERT();
                FERROR.ShowDialog();
            }
            else
            {
                if (ID == 0)
                {

                    //AJOUTE
                    BL.CLS_USERS BLUSER = new BL.CLS_USERS();
                    BLUSER.Insert(txt_name.Text, txt_username.Text, txt_password.Text, txt_prem.Text, "FALSE");
                    PL.FRM_DADD FADD = new PL.FRM_DADD();
                    FADD.Show();
                    this.Close();
                }
                else
                {
                    //modifier
                    BL.CLS_USERS BLUSERS = new BL.CLS_USERS();
                    BLUSERS.Update(txt_name.Text, txt_username.Text, txt_password.Text, txt_prem.Text, ID);
                    PL.FRM_DEDIT FEDIT = new PL.FRM_DEDIT();
                    FEDIT.Show();
                    this.Close();
                }
            }
        }
    }
}
