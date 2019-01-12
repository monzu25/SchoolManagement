using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerRecord
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            InsertForm inf = new InsertForm();
            inf.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ViewForm vf = new ViewForm();
            vf.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ViewForm vf = new ViewForm();
            vf.Show();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DataGridSearch gs = new DataGridSearch();
            gs.Show();
        }
    }
}
