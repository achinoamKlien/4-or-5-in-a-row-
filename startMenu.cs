using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FourInRow
{
    public partial class startMenu : Form
    {
        private Image backGround;
        private const int N = 3; //מס לחצנים
        private Rectangle[] recArr;

        public startMenu()
        {
            InitializeComponent();
            try
            {
                backGround = Bitmap.FromFile(@"images\backGround.png");
                recArr = new Rectangle[N];
                recArr[0] = new Rectangle(314, 217, 181, 35);
                recArr[1] = new Rectangle(314, 283, 181, 35);
                recArr[2] = new Rectangle(314, 352, 181, 35);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show("not found" + e);
            }

        }

        private void FormMouseDown(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(e.X + " " + e.Y);
            int i = 0;  
            bool found = false;
            for (i = 0; i < N && !found; )
            {
                if (recArr[i].Contains(e.X, e.Y))
                {
                    found = true;
                }
                else
                {
                    i++;
                }
            }
            switch (i)
            {
                case 0:
                    GameScreenForm gsf = new GameScreenForm();
                    this.Hide();
                    gsf.ShowDialog();
                    this.Close();
                    //MessageBox.Show("start");
                    break;
                case 1:
                    Instructions ins = new Instructions();
                    this.Hide();
                    ins.ShowDialog();
                    this.Close();
                    //MessageBox.Show("ins");
                    break;
                case 2:
                    if (MessageBox.Show("Exit", "Do you sure you want to exit?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Application.Exit();
                    }
                    //MessageBox.Show("Exit");
                    break;
                default:
                    break;

            }
        }

        private void FormPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.TranslateTransform(-7, 0);
            g.DrawImage(backGround, 0, 0, 800, 533);
        }
    }
}
