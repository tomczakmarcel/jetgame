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
        public int bulletcount = 0;
        public int killcount = 0;
        public int speedy = 0;
        public Form1()
        {
            InitializeComponent();
            player();
            enemy();
            killcounter();
    }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        void death()
        {
            killcount = 0;
            diedscreen.Visible = true;
            explosion.Location = pictureBox1.Location;
            explosion.Visible = true;
            pictureBox1.Visible = false;
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            restartbox.Visible = true;
            quitbox.Visible = true;
        }

        void enemy()
        {
            Random rnd1 = new Random();
            
            pictureBox2.Left = 550;
            
            pictureBox2.Top = rnd1.Next(70, 230);
            
        }

        void killcounter()
        {
            points.Text = Convert.ToString(killcount);
        }

        void enemy1()
        {
            Random rnd2 = new Random();
            pictureBox3.Left = 550;
            pictureBox3.Top = rnd2.Next(70, 230);
        }

        public void player()
        {
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
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
            speedy = (killcount / 15);
            Console.WriteLine(speedy);
            pictureBox2.Left -= (2+speedy);
            pictureBox3.Left -= (1+speedy);

            if (pictureBox2.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                enemy();
                killcount++;
                killcounter();
            }
            if (pictureBox2.Bounds.IntersectsWith(pictureBox5.Bounds))
            {
                enemy();
                killcount++;
                killcounter();
            }
            if (pictureBox3.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                enemy1();
                killcount++;
                killcounter();
            }
            if (pictureBox3.Bounds.IntersectsWith(pictureBox5.Bounds))
            {
                enemy1();
                killcount++;
                killcounter();
            }
            if (pictureBox2.Left<=0)
            {
                enemy();
            }
            if (pictureBox3.Left <= 0)
            {
                enemy1();
            }
            if (pictureBox2.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                death();
            }
            if (pictureBox2.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                death();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            move(1);
        }

        private void pictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        public void Form1_KeyDown(object sender, KeyEventArgs e)
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
            if (e.KeyCode == Keys.Space)
            {
                if (timer2.Enabled == true && timer3.Enabled == true) 
                {
                    pictureBox6.Visible = true;
                    if (pictureBox4.Left >= 400)
                    {
                        timer2.Enabled = false;
                        timer3.Enabled = false;
                        pictureBox4.Visible = false;
                        pictureBox5.Visible = false;
                        bulletcount = 0;
                    }
                }
                else 
                {
                    pictureBox6.Visible = false;
                    bulletcount++;
                if (bulletcount == 1)
                {
                    pictureBox4.Location = pictureBox1.Location;
                    timer2.Enabled = true;
                }
                else if (bulletcount == 2)
                {
                    pictureBox5.Location = pictureBox1.Location;
                    timer3.Enabled = true;
                    bulletcount = 0;
                }
                }
            }
        }

        public void timer2_Tick(object sender, EventArgs e)
        {
                pictureBox4.Visible = true;
                pictureBox4.Left += 10;
        }

        public void timer3_Tick(object sender, EventArgs e)
        {
                pictureBox5.Visible = true;
                pictureBox5.Left += 15;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void quitbox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void restartbox_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
