using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BIBLORDO.PL
{
    public partial class FRM_ADDSELL : Form
    {
        public int ID;
        public FRM_ADDSELL()
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
            BL.CLS_SELL BLSELL = new BL.CLS_SELL();
            //load data book
            DataTable dt1 = new DataTable();
            dt1 = BLSELL.LOADBOOKS();
            dataGridView2.DataSource = dt1;


            //load data students
            DataTable dt2 = new DataTable();
            dt2 = BLSELL.LOADST();
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
                    BL.CLS_SELL BLSELL = new BL.CLS_SELL();
                    BLSELL.Insert(Convert.ToString(dataGridView2.CurrentRow.Cells[1].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value), Convert.ToInt32(txt_price.Text), txt_date.Value);
                    PL.FRM_DADD FADD = new PL.FRM_DADD();
                    FADD.Show();
                    this.Close();
                }
                else
                {
                    //modifier
                    BL.CLS_SELL BLSELL = new BL.CLS_SELL();
                    BLSELL.Update(Convert.ToString(dataGridView2.CurrentRow.Cells[1].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value), Convert.ToInt32(txt_price.Text), txt_date.Value, ID);
                    PL.FRM_DEDIT FEDIT = new PL.FRM_DEDIT();
                    FEDIT.Show();
                    this.Close();
                }


            }
        }
    }
}
