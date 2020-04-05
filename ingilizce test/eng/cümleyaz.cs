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
    public partial class cümleyaz : Form
    {
        public cümleyaz()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Türkilizce.accdb");
        int soruadeti, y, x, tursayısı;
        int doğru, yanlış;
        Random rnd = new Random();
        ErrorProvider error = new ErrorProvider();
        List<int> liste = new List<int>();
        List<int> SÜRE = new List<int>();
        //79 , 80 başlangıç
        //color1 = SystemColors.ControlLight;
        //color2 = SystemColors.AppWorkspace;
        //color3 = SystemColors.ControlDark;
        //color4 = SystemColors.ControlText;
        void tekrarsızsayıüret()
        {
            liste.Clear();
            cümlesay();
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
        void cümlesay()
        {
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("select * from CümleÇeviri", baglanti);
            OleDbDataReader oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                soruadeti++;
            }
            baglanti.Close();
        }
        void cümlegetirilk()
        {
            x++;
            if (liste.IndexOf(x) == -1 || liste.IndexOf(x+1) == -1 || liste.IndexOf(x+2) == -1 || liste.IndexOf(x+3) == -1)
            {
                MessageBox.Show("Sorular bitti");
            }
            else
            {
                baglanti.Open();
                OleDbCommand cmd = new OleDbCommand("select * from CümleÇeviri where SoruID=" + liste[x] + "", baglanti);
                OleDbDataReader oku = cmd.ExecuteReader();
                while (oku.Read())
                {
                    label1.Text = oku["İngilizce"].ToString();
                }
                baglanti.Close();
                baglanti.Open();
                OleDbCommand cmd2 = new OleDbCommand("select * from CümleÇeviri where SoruID=" + liste[x + 1] + "", baglanti);
                OleDbDataReader oku2 = cmd2.ExecuteReader();
                while (oku2.Read())
                {
                    label2.Text = oku2["İngilizce"].ToString();
                }
                baglanti.Close();
                baglanti.Open();
                OleDbCommand cmd3 = new OleDbCommand("select * from CümleÇeviri where SoruID=" + liste[x + 2] + "", baglanti);
                OleDbDataReader oku3 = cmd3.ExecuteReader();
                while (oku3.Read())
                {
                    label3.Text = oku3["İngilizce"].ToString();
                }
                baglanti.Close();
                baglanti.Open();
                OleDbCommand cmd4 = new OleDbCommand("select * from CümleÇeviri where SoruID=" + liste[x + 3] + "", baglanti);
                OleDbDataReader oku4 = cmd4.ExecuteReader();
                while (oku4.Read())
                {
                    label4.Text = oku4["İngilizce"].ToString();
                }
                baglanti.Close();

            }

        }
        void cümlegetir()
        {
            x++;
            if (tursayısı % 4 == 1)
            {
                baglanti.Open();
                OleDbCommand cmd = new OleDbCommand("select * from CümleÇeviri where SoruID=" + liste[x] + "", baglanti);
                OleDbDataReader oku = cmd.ExecuteReader();
                while (oku.Read())
                {
                    label1.Text = oku["İngilizce"].ToString();
                }
                baglanti.Close();
            }
            if (tursayısı % 4 == 2)
            {
 
                baglanti.Open();
                OleDbCommand cmd = new OleDbCommand("select * from CümleÇeviri where SoruID=" + liste[x+1] + "", baglanti);
                OleDbDataReader oku = cmd.ExecuteReader();
                while (oku.Read())
                {
                    label2.Text = oku["İngilizce"].ToString();
                }
                baglanti.Close();
            }
            if (tursayısı % 4 == 3)
            {

                baglanti.Open();
                OleDbCommand cmd = new OleDbCommand("select * from CümleÇeviri where SoruID=" + liste[x+2] + "", baglanti);
                OleDbDataReader oku = cmd.ExecuteReader();
                while (oku.Read())
                {
                    label3.Text = oku["İngilizce"].ToString();
                }
                baglanti.Close();

            }
            if (tursayısı % 4 == 0)
            {

                baglanti.Open();
                OleDbCommand cmd = new OleDbCommand("select * from CümleÇeviri where SoruID=" + liste[x+3] + "", baglanti);
                OleDbDataReader oku = cmd.ExecuteReader();
                while (oku.Read())
                {
                    label4.Text = oku["İngilizce"].ToString();
                }
                baglanti.Close();
            }
        }

        void cevapkontrol()
        {
            if (tursayısı % 4 == 1)
            {
                baglanti.Open();
                OleDbCommand cmd = new OleDbCommand("select * from CümleÇeviri where SoruID=" + liste[x] + "", baglanti);
                OleDbDataReader oku = cmd.ExecuteReader();
                while (oku.Read())
                {
                    MessageBox.Show(oku["Türkçe"].ToString());
                    if (textBox1.Text == oku["Türkçe"].ToString())
                    {
                        doğru++;
                    }
                    else
                    {
                        yanlış++;
                    }
                }
                baglanti.Close();
            }
            if (tursayısı % 4 == 2)
            {
                baglanti.Open();
                OleDbCommand cmd2 = new OleDbCommand("select * from CümleÇeviri where SoruID=" + liste[x + 1] + "", baglanti);
                OleDbDataReader oku2 = cmd2.ExecuteReader();
                while (oku2.Read())
                {
                    MessageBox.Show(oku2["Türkçe"].ToString());
                    if (textBox1.Text == oku2["Türkçe"].ToString())
                    {
                        doğru++;
                    }
                    else
                    {
                        yanlış++;
                    }
                }
                baglanti.Close();
            }
            if (tursayısı % 4 == 3)
            {
                baglanti.Open();
                OleDbCommand cmd3 = new OleDbCommand("select * from CümleÇeviri where SoruID=" + liste[x + 2] + "", baglanti);
                OleDbDataReader oku3 = cmd3.ExecuteReader();
                while (oku3.Read())
                {
                    MessageBox.Show(oku3["Türkçe"].ToString());
                    if (textBox1.Text == oku3["Türkçe"].ToString())
                    {
                        doğru++;
                    }
                    else
                    {
                        yanlış++;
                    }
                }
                baglanti.Close();
            }
            if (tursayısı % 4 == 0)
            {
                baglanti.Open();
                OleDbCommand cmd4 = new OleDbCommand("select * from CümleÇeviri where SoruID=" + liste[x + 3] + "", baglanti);
                OleDbDataReader oku4 = cmd4.ExecuteReader();
                while (oku4.Read())
                {
                    if (textBox1.Text == oku4["Türkçe"].ToString())
                    {
                        doğru++;
                    }
                    else
                    {
                        yanlış++;
                    }
                }
                baglanti.Close();
            }
            textBox1.Clear();
            lbldoğru.Text = doğru.ToString();
            lblyanlış.Text = yanlış.ToString();
        }
        #region Turlar
        void birincitur()
        {
            if (label2.Top <= 140)
            {
                label2.ForeColor = SystemColors.ControlText;
                label2.Top += 1;
                
            }
            if (label3.Top <= 120)
            {
                label3.ForeColor = SystemColors.ControlDarkDark;
                label3.Top += 1;
               
            }
            if (label4.Top <= 100)
            {
                label4.ForeColor = SystemColors.AppWorkspace;
                label4.Top += 1;

            }
            if (label4.Top==100)
            {
                timer1.Stop();
                cevapkontrol();
            }
            label1.ForeColor = SystemColors.ControlLight;
            label1.Location = new Point(79, 80);
        }
        void ikincitur()
        {

            if (label3.Top <= 140)
            {
                label3.ForeColor = SystemColors.ControlText;
                label3.Top += 1;
            }
            if (label4.Top <= 120)
            {
                label4.ForeColor = SystemColors.ControlDarkDark;
                label4.Top += 1;
            }
            if (label1.Top <= 100)
            {
                label1.ForeColor = SystemColors.AppWorkspace;
                label1.Top += 1;
            }
            if (label1.Top == 100)
            {
                timer1.Stop();
                cevapkontrol();
            }
            label2.ForeColor = SystemColors.ControlLight;
            label2.Location = new Point(79, 80);
        }
        void üçüncütur()
        {
            if (label4.Top <= 140)
            {
                label4.ForeColor = SystemColors.ControlText;
                label4.Top += 1;
            }
            if (label1.Top <= 120)
            {
                label1.ForeColor = SystemColors.ControlDarkDark;
                label1.Top += 1;
            }
            if (label2.Top <= 100)
            {
                label2.ForeColor = SystemColors.AppWorkspace;
                label2.Top += 1;
            }
            if (label2.Top == 100)
            {
                timer1.Stop();
                cevapkontrol();
            }
            label3.ForeColor = SystemColors.ControlLight;
            label3.Location = new Point(79, 80);
        }

        private void cümleyaz_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        void dördüncütur()
        {
            if (label1.Top <= 140)
            {
                label1.ForeColor = SystemColors.ControlText;
                label1.Top += 1;
            }
            if (label2.Top <= 120)
            {
                label2.ForeColor = SystemColors.ControlDarkDark;
                label2.Top += 1;
            }
            if (label3.Top <= 100)
            {
                label3.ForeColor = SystemColors.AppWorkspace;
                label3.Top += 1;
            }
            if (label3.Top == 100)
            {
                timer1.Stop();
                cevapkontrol();
            }
                label4.ForeColor = SystemColors.ControlLight;
                label4.Location = new Point(79, 80);
        }
        #endregion
   
        private void timer1_Tick(object sender, EventArgs e)
        {   
            if (tursayısı % 4 == 1)
            {
                birincitur();
            }
            if (tursayısı % 4 == 2)
            {
                ikincitur();
               
            }
            if (tursayısı % 4 == 3)
            {
                üçüncütur();
            
            }
            if (tursayısı % 4 == 0)
            {
                dördüncütur();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            menü m = new menü();
            m.Show();
            Close();
        }

        private void cümleyaz_Load(object sender, EventArgs e)
        {
            tekrarsızsayıüret();
            cümlegetirilk();
            label1.Location = new Point(79, 140);
            label2.Location = new Point(79, 120);
            label3.Location = new Point(79, 100);
            label4.Location = new Point(79, 80);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tursayısı++;
            timer1.Start();
            cümlegetirilk();    
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

