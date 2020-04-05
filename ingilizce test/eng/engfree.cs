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
    public partial class engfree : Form
    {
        public engfree()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Türkilizce.accdb");
        int soruadeti, x=0, y,süretoplam=1,sürepersoru,zaman;
        int başlasayaç;
        int doğru, yanlış;
        Random rnd = new Random();
        ErrorProvider error = new ErrorProvider();
        List<int> liste = new List<int>();
        List<int> SÜRE = new List<int>();
        void tekrarsızsayıüret()
        {
            kelimesay();
            for (int i = 0; i < soruadeti; i++)
            {
                y = rnd.Next(1, (soruadeti + 1));
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
        void kelimesay()
        {
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("select * from engtoturk", baglanti);
            OleDbDataReader oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                soruadeti++;
            }
            baglanti.Close();
        }
        void kelimegetir()
        {
            kelimesay();
            baglanti.Open();
            x++;
            if (x >= soruadeti)
            {
                if (MessageBox.Show("Başka kelime kalmadı, aynı kelimelerle tekrar devam etmek ister misiniz?", "OYUN BİTTİ!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    baglanti.Close();
                    x = 0;
                    liste.Clear();
                    tekrarsızsayıüret();
                    kelimegetir();
                }
                else
                {
                    menü asd = new menü();
                    asd.Show();
                    Hide();
                }
            }
            else
            {
                OleDbCommand cmd = new OleDbCommand("select * from engtoturk where SoruID=" + liste[x] + "", baglanti);
                OleDbDataReader oku = cmd.ExecuteReader();
                while (oku.Read())
                {
                    textBox1.Text = oku["ingilizce"].ToString();
                }
                baglanti.Close();
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            zaman++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            süretoplam++;
            lblsüre.Text = süretoplam.ToString();
        }

        private void engfree_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            if ((doğru + yanlış) == 0)
            {
                MessageBox.Show("Hiç soru çözülmemiş", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                timer1.Stop();
                foreach (int sayı in SÜRE)
                {
                    sürepersoru += sayı;
                }
                sürepersoru /= SÜRE.Count;
                MessageBox.Show("DOĞRU SAYISI: " + doğru + "\nYANLIŞ SAYISI: " + yanlış + "\nÇÖZÜLEN TOPLAM SORU: " + (doğru + yanlış) + "\nTOPLAM SÜRE: " + süretoplam + "\nKELİME BAŞINA SÜRE: " + sürepersoru + "\n\n\nSKOR: " + (doğru - yanlış));
                menü m = new menü();
                m.Show();
                Hide();
            }
            doğru = 0;
            yanlış = 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            checkfirsttext = true;
            zaman = 0;
            timer1.Start();
            timer2.Start();
            pictureBox1.Enabled = false;
            başlasayaç++;
            if (başlasayaç > 0)
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + @"\eng resources\sıradaki buton edited.jpg");
            }
            textBox1.Clear();
            textBox2.Clear();
            kelimegetir();
            cevapla.Enabled = true;
            textBox2.Enabled = true;
            textBox1.Enabled = true;
            button1.Enabled = true;
        }
        bool checkfirsttext=false;
        private void cevapla_Click_1(object sender, EventArgs e)
        {
            if (checkfirsttext == true)
            {
                if (textBox2.Text == "")
                {
                    error.SetError(textBox2, "alanı doldurunuz");
                }
                else
                {
                    error.Clear();
                    cevapla.Enabled = false;
                    baglanti.Open();
                    OleDbCommand cmd = new OleDbCommand("select * from engtoturk where SoruID=" + liste[x].ToString() + "", baglanti);
                    OleDbDataReader oku = cmd.ExecuteReader();
                    while (oku.Read())
                    {
                        if (textBox2.Text == oku["türkçe"].ToString())
                        {
                            doğru++;
                            MessageBox.Show("DOĞRU BİLDİNİZ");
                            SÜRE.Add(zaman);
                        }
                        else
                        {
                            yanlış++;
                            MessageBox.Show("YANLIŞ CEVAP\nDoğru Cevap: " + oku["türkçe"].ToString() + "\nSizin Cevabınız: " + textBox2.Text + "");
                            SÜRE.Add(zaman);
                        }
                    }
                    baglanti.Close();
                    pictureBox1.Enabled = true;
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }        
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Mod değiştirmek istediğinize emin misiniz? Kaydedilmemiş verileriniz silinecek.", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (result == DialogResult.Yes)
            {
                engfree2 asd = new engfree2();
                asd.Show();
                Hide();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Geri dönmek istediğinize emin misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                menü m = new menü();
                m.Show();
                Hide();
            }
        }
        private void engfree_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(Application.StartupPath + @"\eng resources\basla buton.gif");
            tekrarsızsayıüret();
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
