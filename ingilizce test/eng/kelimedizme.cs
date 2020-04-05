using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace eng
{
    public partial class kelimedizme : Form
    {
        public kelimedizme()
        {
            InitializeComponent();
            pictureBox12.Controls.Add(pictureBox11);
            pictureBox11.BackColor = Color.Transparent;
        }
        #region HAREKET
        bool clicked;
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                clicked = true;
            }
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicked)
            {
                Point p = new Point();//in form coordinates
                p.X = e.X + label1.Left;
                p.Y = e.Y + label1.Top;
                label1.Left = p.X;
                label1.Top = p.Y;
            }
        }


        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                clicked = true;
            }
        }
        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicked)
            {
                Point p = new Point();//in form coordinates
                p.X = e.X + label2.Left;
                p.Y = e.Y + label2.Top;
                label2.Left = p.X;
                label2.Top = p.Y;
            }
        }
        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicked)
            {
                Point p = new Point();//in form coordinates
                p.X = e.X + label3.Left;
                p.Y = e.Y + label3.Top;
                label3.Left = p.X;
                label3.Top = p.Y;
            }
        }
        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                clicked = true;
            }
        }
        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                clicked = true;
            }
        }

        private void label5_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                clicked = true;
            }
        }

        private void label4_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicked)
            {
                Point p = new Point();//in form coordinates
                p.X = e.X + label4.Left;
                p.Y = e.Y + label4.Top;
                label4.Left = p.X;
                label4.Top = p.Y;
            }
        }
        private void label5_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicked)
            {
                Point p = new Point();//in form coordinates
                p.X = e.X + label5.Left;
                p.Y = e.Y + label5.Top;
                label5.Left = p.X;
                label5.Top = p.Y;
            }
        }
        private void label6_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                clicked = true;
            }
        }

        private void label6_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicked)
            {
                Point p = new Point();//in form coordinates
                p.X = e.X + label6.Left;
                p.Y = e.Y + label6.Top;
                label6.Left = p.X;
                label6.Top = p.Y;
            }
        }
        private void label7_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                clicked = true;
            }
        }

        private void label7_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicked)
            {
                Point p = new Point();//in form coordinates
                p.X = e.X + label7.Left;
                p.Y = e.Y + label7.Top;
                label7.Left = p.X;
                label7.Top = p.Y;
            }
        }
        private void label8_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicked)
            {
                Point p = new Point();//in form coordinates
                p.X = e.X + label8.Left;
                p.Y = e.Y + label8.Top;
                label8.Left = p.X;
                label8.Top = p.Y;
            }

        }
        private void label9_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                clicked = true;
            }
        }
        private void label8_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                clicked = true;
            }
        }
        private void label9_MouseMove(object sender, MouseEventArgs e)
        {
            if (clicked)
            {
                Point p = new Point();//in form coordinates
                p.X = e.X + label9.Left;
                p.Y = e.Y + label9.Top;
                label9.Left = p.X;
                label9.Top = p.Y;
            }
        }
        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            clicked = false;

        }
        private void label2_MouseUp(object sender, MouseEventArgs e)
        {
            clicked = false;
        }
        private void label3_MouseUp(object sender, MouseEventArgs e)
        {
            clicked = false;
        }
        private void label4_MouseUp(object sender, MouseEventArgs e)
        {
            clicked = false;
        }
        private void label5_MouseUp(object sender, MouseEventArgs e)
        {
            clicked = false;
        }
        private void label6_MouseUp(object sender, MouseEventArgs e)
        {
            clicked = false;
        }
        private void label7_MouseUp(object sender, MouseEventArgs e)
        {
            clicked = false;
        }
        private void label8_MouseUp(object sender, MouseEventArgs e)
        {
            clicked = false;
        }
        private void label9_MouseUp(object sender, MouseEventArgs e)
        {
            clicked = false;
        }
        #endregion
        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Türkilizce.accdb");
        int soruadeti, y, currentid;
        int doğru, yanlış;
        int locX1, locX2, locX3, locX4, locX5, locX6, locX7, locX8, locX9;
        Random rnd = new Random();
        ErrorProvider error = new ErrorProvider();
        List<int> liste = new List<int>();
        //X 200-600
        //Y 67-173
        private void kelimedizme_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        bool ilkbasış=true;
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Geri dönmek istediğinize emin misiniz?","",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                menü m = new menü();
                m.Show();
                Hide();
            }
        }
        int zaman=0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            zaman++;
            label10.Text = zaman.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kelimeleri kurallı sırasına göre imleç ile sürükleyerek boş kutulara koymaya çalışın.");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer1.Start();
            if (!ilkbasış)
            {
                boşkontrol();
                kontrol();
            }
            else
            {
                label1.Show();
                label2.Show();
                label3.Show();
                label4.Show();
                label5.Show();
                label6.Show();
                label7.Show();
                label8.Show();
                label9.Show();
                yenisorugetir();
                button1.Text = "CEVAPLA";
                ilkbasış = false;
            }       
        }

        
        void kontrol()
        {
            if (pictureBox1.Left <= label1.Right && pictureBox1.Right >= label1.Left && pictureBox1.Top <= label1.Bottom && pictureBox1.Bottom >= label1.Top && pictureBox2.Left <= label2.Right && pictureBox2.Right >= label2.Left && pictureBox2.Top <= label2.Bottom && pictureBox2.Bottom >= label2.Top && pictureBox3.Left <= label3.Right && pictureBox3.Right >= label3.Left && pictureBox3.Top <= label3.Bottom && pictureBox3.Bottom >= label3.Top && pictureBox4.Left <= label4.Right && pictureBox4.Right >= label4.Left && pictureBox4.Top <= label4.Bottom && pictureBox4.Bottom >= label4.Top && pictureBox5.Left <= label5.Right && pictureBox5.Right >= label5.Left && pictureBox5.Top <= label5.Bottom && pictureBox5.Bottom >= label5.Top && pictureBox6.Left <= label6.Right && pictureBox6.Right >= label6.Left && pictureBox6.Top <= label6.Bottom && pictureBox6.Bottom >= label6.Top && pictureBox7.Left <= label7.Right && pictureBox7.Right >= label7.Left && pictureBox7.Top <= label7.Bottom && pictureBox7.Bottom >= label7.Top && pictureBox8.Left <= label8.Right && pictureBox8.Right >= label8.Left && pictureBox8.Top <= label8.Bottom && pictureBox8.Bottom >= label8.Top && pictureBox9.Left <= label9.Right && pictureBox9.Right >= label9.Left && pictureBox9.Top <= label9.Bottom && pictureBox9.Bottom >= label9.Top)
            {
                MessageBox.Show("DOĞRU BİLDİNİZ!");
                doğru++;
                lbldoğru.Text = doğru.ToString() ;
            }
            else
            {
                baglanti.Open();
                OleDbCommand cmd = new OleDbCommand("select * from CümleBirleştir where SoruID=" + liste[currentid] + "", baglanti);
                OleDbDataReader oku = cmd.ExecuteReader();
                while (oku.Read())
                {
                    MessageBox.Show("Maalesef yanlış cevap, doğrusu şuydu:\n\n" + oku[1] + " " + oku[2] + " " + oku[3] + " " + oku[4] + " " + oku[5] + " " + oku[6] + " " + oku[7] + " " + oku[8] + " " + oku[9]);
                }
                baglanti.Close();
                yanlış++;
                lblyanlış.Text = yanlış.ToString();
            }
            labelboşalt();
            yenisorugetir();
            labeldiz();
        }
        void labeldizeski()
        {
            locX1 = 70;
            label1.Location = new Point(locX1, 48);
            locX2 = label1.Right + 20;
            label2.Location = new Point(locX2, label1.Location.Y);
            locX3 = label2.Right + 20;
            label3.Location = new Point(locX3, label1.Location.Y);
            locX4 = label3.Right + 20;
            label4.Location = new Point(locX4, label1.Location.Y);
            locX5 = label4.Right + 20;
            label5.Location = new Point(locX5, label1.Location.Y);
            locX6 = label5.Right + 20;
            label6.Location = new Point(locX6, label1.Location.Y);
            locX7 = label6.Right + 20;
            label7.Location = new Point(locX7, label1.Location.Y);
            locX8 = label7.Right + 20;
            label8.Location = new Point(locX8, label1.Location.Y);
            locX9 = label8.Right + 20;
            label9.Location = new Point(locX9, label1.Location.Y);
        }//yanyana
        void labeldiz()
        {
            label1.Location = new Point(rnd.Next(200, 600), rnd.Next(67, 173));
            label2.Location = new Point(rnd.Next(200, 600), rnd.Next(67, 173));
            label3.Location = new Point(rnd.Next(200, 600), rnd.Next(67, 173));
            label4.Location = new Point(rnd.Next(200, 600), rnd.Next(67, 173));
            label5.Location = new Point(rnd.Next(200, 600), rnd.Next(67, 173));
            label6.Location = new Point(rnd.Next(200, 600), rnd.Next(67, 173));
            label7.Location = new Point(rnd.Next(200, 600), rnd.Next(67, 173));
            label8.Location = new Point(rnd.Next(200, 600), rnd.Next(67, 173));
            label9.Location = new Point(rnd.Next(200, 600), rnd.Next(67, 173));
            boşkontrol();
        }//rastgele
        void labelboşalt()
        {
            label1.Text = null;
            label2.Text = null;
            label3.Text = null;
            label4.Text = null;
            label5.Text = null;
            label6.Text = null;
            label7.Text = null;
            label8.Text = null;
            label9.Text = null;
        }
        void boşkontrol()
        {
            if (label4.Text == "")
            {
                label4.Left = pictureBox4.Left;
                label4.Top = pictureBox4.Top;
                label5.Left = pictureBox5.Left;
                label5.Top = pictureBox5.Top;
                label6.Left = pictureBox6.Left;
                label6.Top = pictureBox6.Top;
                label7.Left = pictureBox7.Left;
                label7.Top = pictureBox7.Top;
                label8.Left = pictureBox8.Left;
                label8.Top = pictureBox8.Top;
                label9.Left = pictureBox9.Left;
                label9.Top = pictureBox9.Top;
            }
            if (label5.Text == "")
            {
                label5.Left = pictureBox5.Left;
                label5.Top = pictureBox5.Top;
                label6.Left = pictureBox6.Left;
                label6.Top = pictureBox6.Top;
                label7.Left = pictureBox7.Left;
                label7.Top = pictureBox7.Top;
                label8.Left = pictureBox8.Left;
                label8.Top = pictureBox8.Top;
                label9.Left = pictureBox9.Left;
                label9.Top = pictureBox9.Top;
            }
            if (label6.Text == "")
            {
                label6.Left = pictureBox6.Left;
                label6.Top = pictureBox6.Top;
                label7.Left = pictureBox7.Left;
                label7.Top = pictureBox7.Top;
                label8.Left = pictureBox8.Left;
                label8.Top = pictureBox8.Top;
                label9.Left = pictureBox9.Left;
                label9.Top = pictureBox9.Top;
            }
            if (label7.Text == "")
            {
                label7.Left = pictureBox7.Left;
                label7.Top = pictureBox7.Top;
                label8.Left = pictureBox8.Left;
                label8.Top = pictureBox8.Top;
                label9.Left = pictureBox9.Left;
                label9.Top = pictureBox9.Top;
            }
            if (label8.Text == "")
            {
                label8.Left = pictureBox8.Left;
                label8.Top = pictureBox8.Top;
                label9.Left = pictureBox9.Left;
                label9.Top = pictureBox9.Top;
            }
            if (label9.Text == "")
            {
                label9.Left = pictureBox9.Left;
                label9.Top = pictureBox9.Top;
            }
        }
        void tekrarsızsayıüret()
        {
            liste.Clear();
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("select * from CümleBirleştir", baglanti);
            OleDbDataReader oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                soruadeti++;
            }
            baglanti.Close();
            for (int i = 0; i < soruadeti; i++)
            {
                y = rnd.Next(0, soruadeti);
                if (liste.IndexOf(y) == -1)
                {
                    liste.Add(y);
                }
                else
                {
                    i--;
                }
            }
        }
        void yenisorugetir()
        {
            if (currentid == soruadeti-1)
            {
                DialogResult result = MessageBox.Show("Başka cümle kalmadı aynı cümlelerle tekrar etmek ister misiniz?", "BİTTİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    liste.Clear();
                    tekrarsızsayıüret();
                    labeldiz();
                    yenisorugetir();
                }
                else
                {
                    menü m = new menü();
                    
                    m.Show();
                    
                }
            }
            else
            {
                currentid++;
                baglanti.Open();
                OleDbCommand cmd = new OleDbCommand("select * from CümleBirleştir where SoruID=" + liste[currentid] + "", baglanti);
                OleDbDataReader oku = cmd.ExecuteReader();
                while (oku.Read())
                {
                    label1.Text = oku[1].ToString();
                    label2.Text = oku[2].ToString();
                    label3.Text = oku[3].ToString();
                    label4.Text = oku[4].ToString();
                    label5.Text = oku[5].ToString();
                    label6.Text = oku[6].ToString();
                    label7.Text = oku[7].ToString();
                    label8.Text = oku[8].ToString();
                    label9.Text = oku[9].ToString();
                }
                baglanti.Close();
            }
            
        }
        private void kelimedizme_Load(object sender, EventArgs e)
        {
            ToolTip tip = new ToolTip();
            tip.SetToolTip(button3, "Nasıl Oynanır?");
            button1.Text = "BAŞLA";
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            label8.Hide();
            label9.Hide();
            tekrarsızsayıüret();
            labeldiz();
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
    }
}
