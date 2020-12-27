using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiPage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPage1Next_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void btnPage2Pre_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void btnPage2Next_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void btnPage3Pre_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;            
        }

        private void btnPage3Next_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel2.Visible = false;
        }
    }
}
