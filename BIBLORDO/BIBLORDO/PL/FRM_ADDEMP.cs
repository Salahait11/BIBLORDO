using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BIBLORDO.PL
{
    public partial class FRM_ADDSEMP : Form
    {
        public int ID;
        public FRM_ADDSEMP()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void FRM_ADDBOOKS_Load(object sender, EventArgs e)
        {
            BL.CLS_EMP BLEMP = new BL.CLS_EMP();
            //load data book
            DataTable dt1 = new DataTable();
            dt1 = BLEMP.LOADBOOKS();
            dataGridView2.DataSource = dt1;


            //load data students
            DataTable dt2 = new DataTable();
            dt2 = BLEMP.LOADST();
            dataGridView1.DataSource = dt2;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txt_price.Text == "")
            {
                PL.FRM_ERRORINSERT FERROR = new PL.FRM_ERRORINSERT();
                FERROR.ShowDialog();
            }
            else
            {
                if (ID == 0)
                {

                    //AJOUTE
                    BL.CLS_EMP BLEMP = new BL.CLS_EMP();
                    BLEMP.Insert(Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value), Convert.ToString(dataGridView2.CurrentRow.Cells[1].Value), txt_date1.Value, txt_date2.Value, Convert.ToInt32(txt_price.Text));
                    PL.FRM_DADD FADD = new PL.FRM_DADD();
                    FADD.Show();
                    this.Close();
                }
                else
                {
                    //modifier
                    BL.CLS_EMP BLEMP = new BL.CLS_EMP();
                    BLEMP.Update(Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value), Convert.ToString(dataGridView2.CurrentRow.Cells[1].Value), txt_date1.Value, txt_date2.Value, Convert.ToInt32(txt_price.Text), ID);
                    PL.FRM_DEDIT FEDIT = new PL.FRM_DEDIT();
                    FEDIT.Show();
                    this.Close();
                }


            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
