using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime;

namespace space_game_MT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            player();
            enemy();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        void enemy()
        {
            Random rnd1 = new Random();
            Random rnd2 = new Random();
            pictureBox2.Left = 550;
            pictureBox3.Left = 550;
            pictureBox2.Top = rnd1.Next(40, 250);
            pictureBox3.Top = ((rnd2.Next(40, 250)*3)/2);
        }

        void player()
        {
            pictureBox4.Visible = false;
        }

        void move(int speed)
        {
            if (pictureBox1.Left <= 0)
            {
                pictureBox1.Left = 1;
            }
            else { pictureBox1.Left -= 1; }

            if (pictureBox1.Left >= 450)
            {
                pictureBox1.Left = 449;
            }


            if (pictureBox1.Top <= 0)
            {
                pictureBox1.Top = 1;
            }


            if (pictureBox1.Top >= 230)
            {
                pictureBox1.Top = 229;
            }
            pictureBox2.Left -= 2;
            pictureBox3.Left -= 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            move(1);
        }

        private void pictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                pictureBox1.Top -= 10;
            }
            if (e.KeyCode == Keys.Right)
            {
                pictureBox1.Left += 10;
            }
            if (e.KeyCode == Keys.Left)
            {
                pictureBox1.Left -= 10;
            }
            if (e.KeyCode == Keys.Down)
            {
                pictureBox1.Top += 10;
            }
        }
    }
}
