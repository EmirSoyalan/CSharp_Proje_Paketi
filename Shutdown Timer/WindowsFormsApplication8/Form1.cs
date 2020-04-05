using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace WindowsFormsApplication8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        long toplamzaman, kalanzaman;
        int hızsınırla;
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            label15.Text = timer1.Interval.ToString();
            groupBox2.Enabled = false;
            for (int i = 0; i < 60; i++)
            {
                cmbsaniye.Items.Add(i);
                cmbdakika.Items.Add(i);
            }
            for (int i = 0; i < 24; i++)
            {
                cmbsaat.Items.Add(i);
            }
        }
        void süreyaz()
        {
            if (cmbsaat.SelectedIndex.ToString() == "")
            {
                label6.Text = kalanzaman.ToString();
                label8.Text = (kalanzaman / 60).ToString();
                label10.Text = "0";
            }
            if (cmbdakika.SelectedIndex.ToString() == "" && cmbsaat.SelectedIndex.ToString() == "")
            {
                label6.Text = kalanzaman.ToString();
                label8.Text = "0";
                label10.Text = "0";
            }
            else
            {
                label6.Text = kalanzaman.ToString();
                label8.Text = (kalanzaman / 60).ToString();
                label10.Text = ((kalanzaman / 60) / 60).ToString();
            }
        }
        void temizle()
        {
            cmbdakika.Text = "";
            cmbsaat.Text = "";
            cmbsaniye.Text = "";
            label6.Text = "";
            label8.Text = "";
            label10.Text = "";
            label7.Text = "";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            kalanzaman--;
            süreyaz();
            if (kalanzaman == 0)
            {
                timer2.Start();
                timer1.Stop();
                MessageBox.Show("BİLGİSAYAR KAPATILIYOR");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            label13.Text = "Duraklatıldı";
            timer1.Stop();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(Application.StartupPath + @"\clock.gif");
            label13.Text = "Devam ediyor..";
            timer1.Start();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            label15.Text = timer1.Interval.ToString();
            DialogResult res = MessageBox.Show("İPTAL ETMEK İSTEDİĞİNİZE EMİN MİSİNİZ ?", "İPTAL ET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (res == DialogResult.Yes)
            {
                pictureBox1.Image = null;
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
                label13.Text = "İptal edildi";
                timer1.Stop();
                toplamzaman = 0;
                kalanzaman = 0;
                temizle();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            DialogResult res = MessageBox.Show("SAYAÇ BAŞTAN BAŞLATILSINMI?", "BAŞTAN BAŞLAT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (res == DialogResult.Yes)
            {
                timer1.Interval = 1000;
                label15.Text = timer1.Interval.ToString();
                kalanzaman = 0;
                toplamzaman = 0;
                label7.Text = DateTime.Now.ToString();
                if (cmbdakika.SelectedIndex == -1 && cmbsaat.SelectedIndex == -1)
                {
                    toplamzaman = (cmbsaniye.SelectedIndex);
                }
                else if (cmbsaat.SelectedIndex == -1)
                {
                    toplamzaman = (cmbsaniye.SelectedIndex) + (cmbdakika.SelectedIndex * 60);
                }
                else
                {
                    toplamzaman = (cmbsaniye.SelectedIndex) + (cmbdakika.SelectedIndex * 60) + ((cmbsaat.SelectedIndex * 60) * 60);
                }
                pictureBox1.Image = Image.FromFile(Application.StartupPath + @"\clock.gif");
                label13.Text = "Devam ediyor..";
                kalanzaman = toplamzaman;
                süreyaz();
                timer1.Start();
            }
        }
        int x = 10;
        private void timer2_Tick(object sender, EventArgs e)
        {
            x--;
            if (x <= 0)
            {
                x = 10;
                ProcessStartInfo startinfo = new ProcessStartInfo("shutdown.exe", "-s");
                Process.Start(startinfo);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
        
        private void button8_Click(object sender, EventArgs e)
        {
            button9.Enabled=true;
            hızsınırla++;
            if (hızsınırla!=3)
            {
                timer1.Interval /= 10;
                label15.Text = timer1.Interval.ToString();
            }
            else
            {
                button8.Enabled = false;
            }      
        }
        private void button9_Click(object sender, EventArgs e)
        {
            hızsınırla--;
            button8.Enabled = true;
            if (hızsınırla!=-3)
            {
                timer1.Interval *= 10;
                label15.Text = timer1.Interval.ToString();
            }
            else
            {
                button9.Enabled = false;
            }       
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button8.Enabled = true;
            button9.Enabled = true;
            timer1.Interval = 1000;
            label15.Text = timer1.Interval.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            groupBox2.Enabled = true;
            kalanzaman = 0;
            toplamzaman = 0;//saniye cinsinden
            if (cmbsaat.SelectedItem == null && cmbdakika.SelectedItem == null && cmbsaniye.SelectedItem == null)
            {
                MessageBox.Show("Bir süre giriniz");
            }
            else
            {
                groupBox1.Enabled = false;
                label7.Text = DateTime.Now.ToString();
                if (cmbdakika.SelectedIndex == -1 && cmbsaat.SelectedIndex == -1)
                {
                    toplamzaman = (cmbsaniye.SelectedIndex);
                }
                else if (cmbsaat.SelectedIndex == -1)
                {
                    toplamzaman = (cmbsaniye.SelectedIndex) + (cmbdakika.SelectedIndex * 60);
                }
                else
                {
                    toplamzaman = (cmbsaniye.SelectedIndex) + (cmbdakika.SelectedIndex * 60) + ((cmbsaat.SelectedIndex * 60) * 60);
                }
                pictureBox1.Image = Image.FromFile(Application.StartupPath + @"\clock.gif");
                label13.Text = "Devam ediyor..";
                kalanzaman = toplamzaman;
                süreyaz();
                timer1.Start();
                label19.Text = DateTime.Now.AddSeconds(kalanzaman).ToLongTimeString();
               //label19.Text = DateTime.Now.AddHours(int.Parse(label10.Text)).ToLongTimeString() + " " + DateTime.Now.AddMinutes(int.Parse(label8.Text)).ToLongTimeString()+" " + DateTime.Now.AddSeconds(int.Parse(label6.Text)).ToLongTimeString();
            }
        }
    }
}

