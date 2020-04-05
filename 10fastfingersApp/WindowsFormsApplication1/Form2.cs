using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        ToolTip tip = new ToolTip();
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\database.accdb");
        List<int> KelimelerID = new List<int>();//veritabanındaki kelimeler burada tutulkacak
        Random rnd = new Random();
        double harfsayısı;
        int sıra=0,doğru,yanlış,harf;
        int toplamkelimesayısı;//form açıldığında veritabanındaki kelimleleri sayacak
        int kelimeID=0;//kelimeleri listeden alıp döndürürken kullanılacak, tek tek artacak değişken(adı x olacaktı kafa karıştırır diye değiştirdim)
        void tekrarsızsayı()
        {
            baglanti.Close();
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("select * from kelimeler",baglanti);
            OleDbDataReader oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                toplamkelimesayısı= int.Parse(oku["KelimeID"].ToString());
            }
            toplamkelimesayısı++; //anlamadığım bir sebepten dolayı 1 eksik sayıyor. (çözüm)
            baglanti.Close();
            for (int i = 0; i < toplamkelimesayısı; i++)
            {
                int a = rnd.Next(toplamkelimesayısı);
                if (KelimelerID.IndexOf(a) == -1)
                {
                    listBox1.Items.Add(a);
                    KelimelerID.Add(a);;
                }
                else
                {
                    i--;
                }
            }
        }//veritabanındaki kelimeleri sayıp tekrarsız rastgele bir listeye çağıracak
        string kelime;
        void kelimegetir()//programın temel fonksiyonlarından biri. textboxa 1 tane kelime getirecek
        {
            OleDbCommand cmd = new OleDbCommand("Select * from kelimeler where KelimeID=" + KelimelerID[kelimeID], baglanti);
            OleDbDataReader oku = cmd.ExecuteReader();
            while (oku.Read())
            {
               kelime = oku[1].ToString();
               textBox1.Text += oku[1] + " ";          
            }
            kelimeID++;
        }
        void ÇokluKelimeGetir(int kelimesayısı)
        {
            if (kelimesayısı<toplamkelimesayısı)
            {
                for (int i = 0; i <= kelimesayısı; i++)
                {
                    try
                    {
                        baglanti.Open();
                        if (KelimelerID.IndexOf(kelimeID) != -1)
                        {
                            kelimegetir();
                        }
                        else { break; }
                        baglanti.Close();
                    }
                    catch (Exception)
                    {
                        baglanti.Close();
                    }
                    
                }
                if (kelimesayısı!=0)
                {
                    string[] kelimeler = textBox1.Text.Split(' ');
                    listBox3.Items.AddRange(kelimeler);
                    listBox3.Items.RemoveAt(listBox3.Items.Count - 1);
                }
                else
                {
                    listBox3.Items.Add(kelime);
                }
            }         
        }
        void başasar()
        {
            sıra = 0;
            listBox3.Items.Clear();
            listBox2.Items.Clear();
            listBox1.Items.Clear();
            kelimeID = 0;
            toplamkelimesayısı = 0;
            KelimelerID.Clear();
            tekrarsızsayı();
            ÇokluKelimeGetir(10);
        }
        void reset()
        {
            harf = 0;
            harfsayısı = 0;
            başlatkontrol = false;
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            textBox1.Clear();
            textBox2.Clear();
            doğru = 0;
            yanlış = 0;
            label1.Text = "0";
            kelimeID = 0;
            KelimelerID.Clear();
            label3.Text = "0";
            toplamkelimesayısı = 0;
            sıra = 0;
            tekrarsızsayı();
            timer1.Stop();
            sayaç = 60;
            label8.Text = sayaç.ToString();
            checkBox1.Enabled = true;
        }
        void harfsay()
        {
            harf = 0;
            char[] karakterler = listBox3.Items[sıra].ToString().ToCharArray();
            foreach (char karakter in karakterler)
            {
                harf++;
            }
        }
        void altharfsay()//harf saymaya alternatif çözüm. (Daha iyi)
        {
            harf = 0;
            textBox1.Text.TrimStart();
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (!String.IsNullOrWhiteSpace(textBox1.Text.Substring(i,1)))
	            {
                    harf++;       
	            }
                else
                {
                    break;
                }
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            timer2.Start();
            tip.SetToolTip(checkBox1, "Kelimeler bittiğinde başa sarar");
            tip.SetToolTip(button2,"Animasyonu tekrar et");
            listBox1.Hide();
            listBox2.Hide();
            listBox3.Hide();
            tekrarsızsayı();
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox2.Text!=null)
            {
                if (e.KeyCode == Keys.Space && başlatkontrol)
                {
                    if (sıra == toplamkelimesayısı - 2 && checkBox1.Checked)
                    {
                        başasar();
                    }                
                    if (sıra != toplamkelimesayısı - 1)
                    {
                        SendKeys.Send("{backspace}");
                        textBox2.Text.Trim();
                        textBox1.Text = textBox1.Text.TrimStart();
                        // label6.Text = "Sıra: " + sıra + " Yazılan: " + textBox2.Text + " Doğru: " + listBox3.Items[sıra].ToString();
                        if (textBox2.Text.ToString() == (listBox3.Items[sıra]).ToString())
                        {
                            doğru++;
                            label1.Text = doğru.ToString();
                        }
                        else
                        {
                            yanlış++;
                            label3.Text = yanlış.ToString();
                        }
                        altharfsay();
                        textBox1.Text = textBox1.Text.Remove(0, harf).ToString();
                        sıra++;
                        textBox2.Clear();
                        textBox1.Text = textBox1.Text.TrimStart();
                        ÇokluKelimeGetir(0);//1 kelime getirir  
                    }
                    else
                    {
                        baglanti.Close();
                        MessageBox.Show("Kelimeler Bitti");
                        reset(); 
                        button1.Text = "Başla";
                        x++;
                    }
                } 
            }       
        }
        bool başlatkontrol=false;
        int x;
        private void button1_Click_1(object sender, EventArgs e)
        {
            x++;
            if (x % 2 == 1)//başlamış hali
            {
                timer1.Start();
                başlatkontrol = true;
                ÇokluKelimeGetir(10);
                textBox2.Text = "";
                checkBox1.Enabled = false;
                button1.Text = "Bitir";
            }
            else//standby
            {
                timer1.Stop();
                DialogResult result = MessageBox.Show("Bitirmek istediğinize emin misiniz?","Bitir",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    checkBox1.Enabled = true;
                    button1.Text = "Başla";
                    MessageBox.Show("Saniyede basılan kelime sayısı: " + (harfsayısı / sayaç) , "İSTATİKLER");
                    reset();
                    x++;
                }
                else
                {
                    timer1.Start();
                }
                
            }

        }
        double sayaç=60;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayaç--;
            label8.Text = sayaç.ToString();
            if (sayaç==0)
            {
                timer1.Stop();
                MessageBox.Show("Süre Doldu!","TimeUp",MessageBoxButtons.OK,MessageBoxIcon.Information);
                MessageBox.Show("Saniyede basılan kelime sayısı: " + (harfsayısı/60)+"\nDakikada yazılan kelime sayısı: "+(doğru+yanlış),"İSTATİKLER");
                reset();
                button1.Text = "Başla";
                x++;
            }
        }
        int y,d=0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            y++;
            switch (y)
            {
                case 1: label6.ForeColor = Color.Red; break;
                case 2: label7.ForeColor = Color.Blue; break;
                case 3: label10.ForeColor = Color.Magenta; break;
                case 4: label11.ForeColor = Color.Yellow; break;
                case 5: label12.ForeColor = Color.Aqua; break;
                case 6: label13.ForeColor = Color.MediumSeaGreen; break;
                case 7: label14.ForeColor = Color.Lime; break;
                case 8: label15.ForeColor = Color.Chocolate; break;
                case 9: label16.ForeColor = Color.Red; break;
                case 10: label17.ForeColor = Color.Olive; break;
                case 11: label18.ForeColor = Color.Turquoise; break;
                case 12: label19.ForeColor = Color.Blue; break;
                case 13: label20.ForeColor = Color.Magenta; break;
                case 14: label6.ForeColor = Color.Black; break;
                case 15: label7.ForeColor = Color.Black; break;
                case 16: label10.ForeColor = Color.Black; break;
                case 17: label11.ForeColor = Color.Black; break;
                case 18: label12.ForeColor = Color.Black; break;
                case 19: label13.ForeColor = Color.Black; break;
                case 20: label14.ForeColor = Color.Black; break;
                case 21: label15.ForeColor = Color.Black; break;
                case 22: label16.ForeColor = Color.Black; break;
                case 23: label17.ForeColor = Color.Black; break;
                case 24: label18.ForeColor = Color.Black; break;
                case 25: label19.ForeColor = Color.Black; break;
                case 26: label20.ForeColor = Color.Black; break;
                case 27:
                    label6.ForeColor = Color.Red;
                    label7.ForeColor = Color.Blue;
                    label10.ForeColor = Color.Magenta;
                    label11.ForeColor = Color.Yellow;
                    label12.ForeColor = Color.Aqua;
                    label13.ForeColor = Color.MediumSeaGreen;
                    label14.ForeColor = Color.Lime;
                    label15.ForeColor = Color.Chocolate;
                    label16.ForeColor = Color.Red;
                    label17.ForeColor = Color.Olive;
                    label18.ForeColor = Color.Turquoise;
                    label19.ForeColor = Color.Blue;
                    label20.ForeColor = Color.Magenta;
                    break;
                case 30:
                    label6.ForeColor = Color.Black;
                    label7.ForeColor = Color.Black;
                    label10.ForeColor = Color.Black;
                    label11.ForeColor = Color.Black;
                    label12.ForeColor = Color.Black;
                    label13.ForeColor = Color.Black;
                    label14.ForeColor = Color.Black;
                    label15.ForeColor = Color.Black;
                    label16.ForeColor = Color.Black;
                    label17.ForeColor = Color.Black;
                    label18.ForeColor = Color.Black;
                    label19.ForeColor = Color.Black;
                    label20.ForeColor = Color.Black;
                    break;
                case 33:
                    label6.ForeColor = Color.Red;
                    label7.ForeColor = Color.Blue;
                    label10.ForeColor = Color.Magenta;
                    label11.ForeColor = Color.Yellow;
                    label12.ForeColor = Color.Aqua;
                    label13.ForeColor = Color.MediumSeaGreen;
                    label14.ForeColor = Color.Lime;
                    label15.ForeColor = Color.Chocolate;
                    label16.ForeColor = Color.Red;
                    label17.ForeColor = Color.Olive;
                    label18.ForeColor = Color.Turquoise;
                    label19.ForeColor = Color.Blue;
                    label20.ForeColor = Color.Magenta;
                    break;
                case 36:
                    label6.ForeColor = Color.Black;
                    label7.ForeColor = Color.Black;
                    label10.ForeColor = Color.Black;
                    label11.ForeColor = Color.Black;
                    label12.ForeColor = Color.Black;
                    label13.ForeColor = Color.Black;
                    label14.ForeColor = Color.Black;
                    label15.ForeColor = Color.Black;
                    label16.ForeColor = Color.Black;
                    label17.ForeColor = Color.Black;
                    label18.ForeColor = Color.Black;
                    label19.ForeColor = Color.Black;
                    label20.ForeColor = Color.Black;
                    break;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Start();
            y = 0;       
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            harfsayısı++;
        }
    }
}
