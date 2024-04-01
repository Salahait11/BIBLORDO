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
    public partial class FRM_START : Form
    {
        public FRM_START()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BL.CLS_USERS CLSUSERS = new BL.CLS_USERS();
            DataTable dt = new DataTable();
            dt = CLSUSERS.STARTLOAD();
            if (dt.Rows.Count>0)
            {
                PL.FRM_MAIN MAIN = new PL.FRM_MAIN();
                object lbname = dt.Rows[0]["CNAME"];
                object lbprem = dt.Rows[0]["CPREM"];
                MAIN.lbname.Text = lbname.ToString();
                MAIN.lbprem.Text = lbprem.ToString();
                MAIN.Show();
                this.Hide();
                timer1.Enabled= false;
            }
            else
            {
                PL.FRM_LOGIN LOGIN = new PL.FRM_LOGIN();
                LOGIN.Show();
                this.Hide();
                timer1.Enabled = false;
            }
        }
    }
}
