using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilderMemory
{
    public partial class Form1 : Form
    {
        int zaehler;
        int AnzPaare;
        int Richtige;
        int AnzVersuche;
        int HintergrundIndex;
        int[] Verteilung = new int[8];
        Button b = new Button();
        Image[] Hintergrund = {Image.FromFile(@"h1.png"),
            Image.FromFile(@"h2.png"),
            Image.FromFile(@"h3.jpg")};

        Image[] Bilder = {Image.FromFile(@"1.png"),
            Image.FromFile(@"2.png"),
            Image.FromFile(@"3.png"),
            Image.FromFile(@"4.png")};

        public Form1()
        {
            InitializeComponent();
        }

        private void vergleiche(Button x)
        {
            if (x.Image == b.Image)
            {
                Richtige++;
                x.Enabled = !Enabled;
                b.Enabled = !Enabled;
                AnzPaare--;
            }
            else
            {
                MessageBox.Show("FALSCH");
                x.Image = Hintergrund[HintergrundIndex];
                b.Image = Hintergrund[HintergrundIndex];                           
            }
            zaehler = 0;
            AnzVersuche++;
        }

        private void startGame(int auswahl)
        {
            
            zaehler = 0;
            AnzPaare = 4;
            Richtige = 0;
            AnzVersuche = 0;
            
            label3.Text = AnzVersuche.ToString();
            label4.Text = Richtige.ToString();
            label6.Text = AnzPaare.ToString();

            foreach (Button c in tableLayoutPanel1.Controls)
            {
                c.Enabled = Enabled;
                c.Image = Hintergrund[auswahl];
            }            
            tableLayoutPanel1.Visible = true;
            label7.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
        }
        
        private void click(Button button, Image bild)
        {
            button.Image = bild;
            zaehler++;
            if (zaehler == 2) vergleiche(button);
            else b = button;

            label3.Text = AnzVersuche.ToString();
            label4.Text = Richtige.ToString();
            label6.Text = AnzPaare.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = true; 

            pictureBox1.Image = Hintergrund[0];
            pictureBox2.Image = Hintergrund[1];
            pictureBox3.Image = Hintergrund[2];

            tableLayoutPanel1.Visible = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            randomPic();
        }

        private void buttonNeuesSpiel_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            click(button1, Bilder[Verteilung[0]]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            click(button2, Bilder[Verteilung[1]]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            click(button3, Bilder[Verteilung[2]]);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            click(button4, Bilder[Verteilung[3]]);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            click(button5, Bilder[Verteilung[4]]);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            click(button6, Bilder[Verteilung[5]]);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            click(button7, Bilder[Verteilung[6]]);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            click(button8, Bilder[Verteilung[7]]);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            clickPicbox(0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            clickPicbox(1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            clickPicbox(2);
        }               

        private void randomPic()
        {
            Verteilung = new int[8];
            int anz = 0;
            int zahl;
            Random rnd = new Random();
            for (int i = 0; i < 8; i++)
            {
                zahl = rnd.Next(1, 5);
                foreach (int j in Verteilung)
                {
                    if (zahl == j) anz++;
                }
                if (anz >= 2) i = i - 1;
                else Verteilung[i] = zahl;
                anz = 0;
            }

            for(int i=0;i<8;i++)
            {
                Verteilung[i] = Verteilung[i] - 1;
            }
        }

        private void clickPicbox(int hintergrund)
        {
            startGame(hintergrund);
            HintergrundIndex = hintergrund;

            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = false;
        }
    }
}
