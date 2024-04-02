using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loaiHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            srmloaihang frm = new srmloaihang();
            frm.Show();
            this.Hide();

        } 
    }
}
