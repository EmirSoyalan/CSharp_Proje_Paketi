using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eng
{
    public partial class menü : Form
    {
        public menü()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            çevirigeçişform frm = new çevirigeçişform();
            frm.Show();
            Hide();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            kelimedizme yaz = new kelimedizme();
            yaz.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
         
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
