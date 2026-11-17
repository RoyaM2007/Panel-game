using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Panel_game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random r = new Random();
        Random g = new Random();
        Random b = new Random();

        Random xL = new Random();
        Random yL = new Random();
        int count = 0;

        
        List<Panel> paneller = new List<Panel>();

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = @"C:\Users\Lenovo\OneDrive\Desktop\img\bomba.png";
            pictureBox1.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            count++;
            label2.Text = count.ToString();

            Panel kvadrat = new Panel();
            kvadrat.Size = new Size(60, 60);
            kvadrat.Location = new Point(xL.Next(0, 700), yL.Next(0, 280));
            kvadrat.BackColor = Color.FromArgb(r.Next(0, 256), g.Next(0, 256), b.Next(0, 256));

            this.Controls.Add(kvadrat);
            paneller.Add(kvadrat);

            pictureBox1.BringToFront();

            
            if (kvadrat.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                MessageBox.Show("Bombaya toxundu\nToplam Xal: " + count, "Məğlubiyyət", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Sifirla();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(xL.Next(0, 700), yL.Next(0, 280));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        
        private void Sifirla()
        {
            foreach (Panel p in paneller)
            {
                this.Controls.Remove(p);
                p.Dispose();
            }
            paneller.Clear();

            count = 0;
            label2.Text = "0";
            pictureBox1.Location = new Point(xL.Next(0, 700), yL.Next(0, 280));
            pictureBox1.BringToFront();
        }
    }
}
