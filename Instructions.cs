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
    public partial class Instructions : Form
    {
        private Image backGround;
        private Rectangle rec;

        public Instructions()
        {
            InitializeComponent();
            try
            {
                backGround = Bitmap.FromFile(@"images\Instructions.png");
                rec = new Rectangle(54, 458, 155, 46);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show("not found" + e);
            }

           
        }
        private void FormMouseDown(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(e.X + " " + e.Y);
            if (rec.Contains(e.X, e.Y))
            {
                startMenu sm = new startMenu();
                this.Hide();
                sm.ShowDialog();
                this.Close();

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
