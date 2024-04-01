using System;
using System.Windows.Forms;

namespace BIBLORDO.PL
{
    public partial class FRM_ADDCAT : Form
    {
        public int ID;
        public FRM_ADDCAT()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txt_catname.Text == "")
            {
                PL.FRM_ERRORINSERT FERROR = new PL.FRM_ERRORINSERT();
                FERROR.Show();
                this.Close();
            }
            else
            {
                if (ID == 0)
                {
                    //AJOUTE
                    BL.CLS_CAT BLCAT = new BL.CLS_CAT();
                    BLCAT.Insert(txt_catname.Text);
                    PL.FRM_DADD FADD = new PL.FRM_DADD();
                    FADD.Show();
                    this.Close();
                }
                else
                {
                    //modifier
                    BL.CLS_CAT BLCAT = new BL.CLS_CAT();
                    BLCAT.Update(txt_catname.Text, ID);
                    PL.FRM_DEDIT FEDIT = new PL.FRM_DEDIT();
                    FEDIT.Show();
                    this.Close();
                }


            }

        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
