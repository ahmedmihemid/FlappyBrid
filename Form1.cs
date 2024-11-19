using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace FlappyBridGame
{
    public partial class Form1 : Form
    {

        bool GameMode = true;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

      
        private void Start()
        {


        }




     

        private void MovePipes()
        {
            pictureBox1.Left -= 13;
            pictureBox5.Left -= 13;
            pictureBox3.Left -= 13;
            pictureBox4.Left -= 13;

            if (pictureBox1.Left < -50)
            {
                score++;
                UpdateScore();
                pictureBox1.Left = 850;
                pictureBox1.Location = new Point(pictureBox1.Left, GetRandomSize(1));
            }

            if (pictureBox5.Left < -50)
            {
                score++;
                UpdateScore();
                pictureBox5.Left = 850;
                pictureBox5.Location = new Point(pictureBox5.Left, GetRandomSize(2));
            }


            if (pictureBox3.Left < -50)
            {
                score++;
                UpdateScore();
                pictureBox3.Left = 850;
                pictureBox3.Location = new Point(pictureBox3.Left, GetRandomSize(3));
            }

            if (pictureBox4.Left < -50)
            {
                score++;
                UpdateScore();
                pictureBox4.Left = 850;
                pictureBox4.Location = new Point(pictureBox4.Left, GetRandomSize(4));
            }


        }


        private bool isTouchPipeOrGround()
        {
         if( pictureBox6.Bounds.IntersectsWith(pictureBox1.Bounds) || pictureBox6.Bounds.IntersectsWith(pictureBox3.Bounds) || pictureBox6.Bounds.IntersectsWith(pictureBox4.Bounds)  || pictureBox6.Bounds.IntersectsWith(pictureBox5.Bounds)  || pictureBox6.Bounds.IntersectsWith(pictureBox2.Bounds))
            { return true; }
         return false;  
        }


        private bool MoveBird()
        {
            pictureBox6.Top += 5;
            pictureBox6.Image = Properties.Resources.NicePng_flappy_bird_pipe_png_1831944_removebg_preview;
            if (isTouchPipeOrGround()) { return false; }
            return true;
        }

        private int GetRandomSize(int picNo)
        {
            Random rand = new Random();
            int randSize;
            switch (picNo)
            {
                case 1: randSize = rand.Next(184, 249); break;
                case 2: randSize = rand.Next(184, 249); break;
                case 3: randSize = rand.Next(-106, -1); break;
                case 4: randSize = rand.Next(-106, -1); break;
                default : randSize = 0; break;
            }
            return randSize;
        }



        private void UpdateScore()
        {
            label1.Text = "Score " + score.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           


        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

            pictureBox6.Top -= 70;
            pictureBox6.Image = Properties.Resources.NicePng_flappy_bird_png_1515878_removebg_preview__1_;
           
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {


        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            MovePipes();
            GameMode = MoveBird();
       
            if (!GameMode)
            {
                timer2.Enabled = false;
                this.Close();
                UpdateScore();
            }
        }
    }
}
