using System;
using System.Windows.Forms;

namespace BIBLORDO.PL
{
    public partial class FRM_DDELETE : Form
    {
        public FRM_DDELETE()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
