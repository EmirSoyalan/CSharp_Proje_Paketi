using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ToolTip tip = new ToolTip();
        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Focus();
            textBox2.MaxLength = 1;
        }
        int harf, bosluk, harff;
        private void button1_Click(object sender, EventArgs e)
        {
            harff=0;
            label1.Text = ""; 
            if (!string.IsNullOrWhiteSpace(richTextBox1.Text) || !string.IsNullOrEmpty(textBox2.Text))
            {
                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    textBox2.Text = " ";

                }
                richTextBox1.Text.Trim();
                harf = 0;
                listBox1.Items.Clear();
                if (textBox2.Text == " ")
                {
                    for (int i = 0; i < richTextBox1.Text.Length; i++)
                    {
                        if (richTextBox1.Text.Substring(i, 1) == " ")
                        {
                            harf++;
                        }
                    }
                    if (harf == 0)
                    {
                        label1.Text = "Metinde hiç boşluk yok";
                    }
                    else
                        label1.Text = "Metinde " + harf + " tane boşluk var";
                }
                else
                {
                    bosluk = 0;
                    for (int i = 0; i < richTextBox1.Text.Length; i++)
                    {
                        char @char = char.Parse(richTextBox1.Text.Substring(i, 1));
                        if (@char == ' ')
                        {
                            bosluk++;
                            harf = 0;
                        }
                        else
                        {
                            harf++;
                        }
                        try
                        {
                            if (@char == char.Parse(textBox2.Text))
                            {
                                if (checkBox1.Checked)
                                {
                                    if (harf == 1)
                                    {
                                        listBox1.Items.Add((bosluk + 1) + ". kelimenin baş harfi ");
                                        harff++;
                                    }
                                }
                                else
                                {
                                    listBox1.Items.Add((bosluk + 1) + ". kelime, " + harf + ". harf");
                                    harff++;
                                }

                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                    if (checkBox1.Checked)
                    {
                        if (harff==0)
                        {
                            label1.Text = "Metinde " + textBox2.Text + " ile başlayan kelime yok";
                        }
                        else
                        {
                            label1.Text = "Metinde " + textBox2.Text + " ile başlayan " + harff + " kelime var";
                        }
                    }
                    else
                    {
                        if (harff == 0)
                        {
                            label1.Text = "Metinde hiç '" + textBox2.Text + "' harfi yok";
                        }
                        else
                        {
                            label1.Text = "Metinde " + harff + " tane '" + textBox2.Text + "' harfi var";
                        }
                    }
                   
                }
            }
            else
            {
                MessageBox.Show("Gerekli alanları doldurunuz.", "DİKKAT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            faktoriyel f = new faktoriyel();
            f.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("1");
            }
            if (string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                MessageBox.Show("2");
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("3");
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("4");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }
    }
}

