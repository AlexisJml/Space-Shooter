﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Shooter
{
    public partial class Form1 : Form
    {
        PictureBox[] stars;
        int backgroundspeed;
        int playerspeed;
        Random rnd;

        public Form1()
        {
            InitializeComponent();
        }

        /*       BackGround Animation           */
        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundspeed = 4;
            playerspeed = 4;
            stars = new PictureBox[15];
            rnd = new Random();

            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new PictureBox();
                stars[i].BorderStyle = BorderStyle.None;
                stars[i].Location = new Point(rnd.Next(20, 580), rnd.Next(-10, 400));

                if(i%2 == 1)
                {
                    stars[i].Size = new Size(2, 2);
                    stars[i].BackColor = Color.Wheat;
                }
                else
                {
                    stars[i].Size = new Size(3, 3);
                    stars[i].BackColor = Color.DarkGray;
                }

                this.Controls.Add(stars[i]);
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            for(int  i = 0;i < stars.Length / 2; i++)
            {
                stars[i].Top += backgroundspeed;

                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }

            for (int i = stars.Length / 2; i < stars.Length; i++)
            {
                stars[i].Top -= backgroundspeed - 2;

                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }
        }
        /*////////////////////////////////////////////////////////////////*/

        private void LeftMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Left > 10)
            {
                Player.Left -= playerspeed;
            }
        }

        private void RightMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Right < 580)
            {
                Player.Left += playerspeed;
            }
        }

        private void UpMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top > 10)
            {
                Player.Top -= playerspeed;
            }
        }

        private void DownMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top < 400)
            {
                Player.Top += playerspeed;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                RightMoveTimer.Start();
            }
            if(e.KeyCode == Keys.Left || e.KeyCode == Keys.Q)
            {
                LeftMoveTimer.Start();
            }
            if(e.KeyCode == Keys.Up || e.KeyCode == Keys.Z)
            {
                UpMoveTimer.Start();
            }
            if(e.KeyCode == Keys.Down || e.KeyCode == Keys.S) 
            {
                DownMoveTimer.Start(); 
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
         RightMoveTimer.Stop();
         LeftMoveTimer.Stop();
         UpMoveTimer.Stop();
         DownMoveTimer.Stop();
        }
    }
}
