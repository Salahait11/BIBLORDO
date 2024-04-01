using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BIBLORDO.PL
{
    public partial class FRM_ADDSTUDENTS : Form
    {
        public int ID;
        public FRM_ADDSTUDENTS()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            var result = OFD.ShowDialog();
            if (result == DialogResult.OK)
            {
                cover.Image = Image.FromFile(OFD.FileName);
            }
        }

        private void FRM_ADDBOOKS_Load(object sender, EventArgs e)
        {
           
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PL.FRM_ADDCAT FCAT = new FRM_ADDCAT();
            FCAT.btnadd.ButtonText = "AJOUTER";
            FCAT.ID = 0;
            FCAT.Show();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txt_name.Text == "" || txt_adresse.Text == "" || txt_phone.Text == "" || txt_email.Text == "")
            {
                PL.FRM_ERRORINSERT FERROR = new PL.FRM_ERRORINSERT();
                FERROR.ShowDialog();
            }
            else
            {
                if (ID == 0)
                {
                    MemoryStream ma = new MemoryStream();
                    cover.Image.Save(ma, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //AJOUTE
                    BL.CLS_ST BLST = new BL.CLS_ST();
                    BLST.Insert(txt_name.Text, txt_adresse.Text, txt_email.Text, txt_phone.Text, txt_school.Text, txt_filiere.Text, ma);
                    PL.FRM_DADD FADD = new PL.FRM_DADD();
                    FADD.Show();
                    this.Close();
                }
                else
                {
                    MemoryStream ma = new MemoryStream();
                    cover.Image.Save(ma, System.Drawing.Imaging.ImageFormat.Jpeg);
                    BL.CLS_ST BLST = new BL.CLS_ST();
                    BLST.Update(txt_name.Text, txt_adresse.Text, txt_email.Text, txt_phone.Text, txt_school.Text, txt_filiere.Text, ma, ID);
                    PL.FRM_DEDIT FEDIT = new PL.FRM_DEDIT();
                    FEDIT.Show();
                    this.Close();
                }


            }
        }
    }
}
