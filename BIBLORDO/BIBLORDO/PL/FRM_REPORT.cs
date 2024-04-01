using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIBLORDO.PL
{
    public partial class FRM_REPORT : Form
    {
        BL.CLS_CAT BLCAT = new BL.CLS_CAT();
        BL.CLS_BOOKS BLBOOKS = new BL.CLS_BOOKS();
        BL.CLS_ST BLST = new BL.CLS_ST();
        BL.CLS_SELL BLSELL = new BL.CLS_SELL();
        BL.CLS_EMP BLEMP = new BL.CLS_EMP();
        BL.CLS_USERS BLUSER = new BL.CLS_USERS();
        public FRM_REPORT()
        {
            InitializeComponent();
        }

        private void FRM_REPORT_Load(object sender, EventArgs e)
        {
            PL.FRM_MAIN home = new PL.FRM_MAIN();
            lbname.Text= home.lbname.Text;
            lbperm.Text=home.lbprem.Text;
            lbdate.Text = DateTime.Now.ToString();

            //
            //CHECK NUMBER
            //BOOK
            try
            {
                DataTable dt = new DataTable();
                dt = BLBOOKS.LOAD();
                lbnbook.Text = dt.Rows.Count.ToString();
            }
            catch { }
            //STUDANT
            try
            {
                DataTable dt = new DataTable();
                dt = BLST.LOAD();
                lbst.Text = dt.Rows.Count.ToString();
            }
            catch { }
            //VENTES
            try
            {
                DataTable dt = new DataTable();
                dt = BLSELL.LOAD();
                lbvente.Text = dt.Rows.Count.ToString();
            }
            catch { }
            //EMPRUNT
            try
            {
                DataTable dt = new DataTable();
                dt = BLEMP.LOAD();
                lbemp.Text = dt.Rows.Count.ToString();
            }
            catch { }
            //CAT
            try
            {
                DataTable dt = new DataTable();
                dt = BLCAT.LOAD();
                lbcat.Text = dt.Rows.Count.ToString();
            }
            catch { }
            //USER
            try
            {
                DataTable dt = new DataTable();
                dt = BLUSER.LOAD();
                lbuser.Text = dt.Rows.Count.ToString();
            }
            catch { }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap img = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(img, new Rectangle(Point.Empty, panel1.Size));
            e.Graphics.DrawImage(img,0,0);
        }
    }
}
