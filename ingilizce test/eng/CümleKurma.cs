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
    public partial class CümleKurma : Form
    {
        public CümleKurma()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Türkilizce.accdb");
        int soruadeti, x, y,kelimeadetpersoru;
        int başlasayaç;
        int doğru, yanlış;
        Random rnd = new Random();
        ErrorProvider error = new ErrorProvider();
        List<int> liste = new List<int>();
        void labelsıfırla()
        {
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
        }

        private void CümleKurma_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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
                x = rnd.Next(0, soruadeti);
                if (liste.IndexOf(x) == -1)
                {
                    liste.Add(x);
                }
                else
                {
                    i--;
                }
            }

        }
        void kelimesay()
        {
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("select * from CümleBirleştir where SoruID=", baglanti);
            OleDbDataReader oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                soruadeti++;
            }
            baglanti.Close();
        }
        void sorugetir()
        {
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("select * from Cümlebirleştir where SoruID=" + liste[x] + "", baglanti);
            OleDbDataReader oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                label1.Text = oku["Kelime1"].ToString() + "/ ";
                label2.Text = oku["Kelime2"].ToString() + "/ ";
                label3.Text = oku["Kelime3"].ToString() + "/";
                if (label3.Text == "/")
                {
                    label3.Text = "";
                }
                label4.Text = oku["Kelime4"].ToString() + "/ ";
                if (label4.Text == "/")
                {
                    label4.Text = "";
                }
                label5.Text = oku["Kelime5"].ToString() + "/";
                if (label5.Text == "/")
                {
                    label5.Text = "";
                }
                label6.Text = oku["Kelime6"].ToString() + "/";
                if (label6.Text == "/")
                {
                    label6.Text = "";
                }
                label7.Text = oku["Kelime7"].ToString() + "/";
                if (label7.Text == "/")
                {
                    label7.Text = "";
                }
                label8.Text = oku["Kelime8"].ToString() + "/";
                if (label8.Text == "/")
                {
                    label8.Text = "";
                }
                label9.Text = oku["Kelime9"].ToString() + "/";
                if (label9.Text == "/")
                {
                    label9.Text = "";
                }
                label10.Text = oku["Kelime10"].ToString();
            }
            baglanti.Close();
        }
        private void CümleKurma_Load(object sender, EventArgs e)
        {
            labelsıfırla();
            tekrarsızsayıüret();
            sorugetir();
        }
    }
}
