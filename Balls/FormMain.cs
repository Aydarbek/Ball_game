using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Balls
{
    public struct Ball
    {
        public int x;
        public int y;
        public int color;
    }

    public enum Item
    {
        none,
        ball,
        jump,
        next,
        path
    }
    public delegate void ShowItem(Ball ball, Item item);


    public partial class FormMain : Form
    {
        int max = 9;
        int size = 50;
        PictureBox[,] box;
        Game game;

        public enum Item
        {
            none,
            ball,
            jump,
            next,
            path
        }

        public FormMain()
        {
            InitializeComponent();
            CreateBoxes();
            game = new Game(max, );
            timer.Enabled = true;
        }



        public void CreateBoxes()
        {
            box = new PictureBox[max, max];
            for (int x = 0; x < max; x ++)
                for (int y = 0; y < max; y++)
                {
                    box[x, y] = new PictureBox();
                    panel.Controls.Add(box[x, y]);
                    box[x, y].BorderStyle = BorderStyle.FixedSingle;
                    box[x, y].Location = new Point(x*size, y*size);
                    box[x, y].Size = new Size(size, size);
                    box[x, y].Click += new System.EventHandler(this.ClickBox);
                    box[x, y].Image = Properties.Resources.empty;
                    box[x, y].SizeMode = PictureBoxSizeMode.Zoom;
                    box[x, y].Tag = new Point(x, y);
                }
            panel.Size = new Size (max * size + 2, max * size + 2);
        }

        private void ClickBox(object sender, EventArgs e)
        {
            Point xy = (Point)((PictureBox)sender).Tag;
            MessageBox.Show(xy.X.ToString() + " " + xy.Y.ToString());
        }

        private Bitmap imgBall (int nr)
        {
            switch (nr)
            {
               case 1: return Properties.Resources._1n;
               case 2: return Properties.Resources._2n;
               case 3: return Properties.Resources._3n;
               case 4: return Properties.Resources._4n;
               case 5: return Properties.Resources._5n;
               case 6: return Properties.Resources._6n;
            }
            return null;
        }

        private Bitmap imgJump(int nr)
        {
            switch (nr)
            {
                case 1: return Properties.Resources._1b;
                case 2: return Properties.Resources._2b;
                case 3: return Properties.Resources._3b;
                case 4: return Properties.Resources._4b;
                case 5: return Properties.Resources._5b;
                case 6: return Properties.Resources._6b;
            }
            return null;
        }

        private Bitmap imgNext(int nr)
        {
            switch (nr)
            {
                case 1: return Properties.Resources._1s; 
                case 2: return Properties.Resources._2s; 
                case 3: return Properties.Resources._3s; 
                case 4: return Properties.Resources._4s; 
                case 5: return Properties.Resources._5s; 
                case 6: return Properties.Resources._6s; 
            }
            return null;
        }

        private void ShowItem (Ball ball, Item item)
        {
            Image img;

            switch (item)
            {
                case Item.none: img = Properties.Resources.empty; break;
                case Item.ball: img = imgBall(ball.color); break;
                case Item.next: img = imgNext(ball.color); break;
                case Item.jump: img = imgJump(ball.color); break;
                case Item.path: img = Properties.Resources.path; break;
                default: img = Properties.Resources.empty; break;

            }

            box[ball.x, ball.y].Image = img;

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            game.Step();
        }
    }
}
