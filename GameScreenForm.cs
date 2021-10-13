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
    public partial class GameScreenForm : Form
    {
        private Image backGround;
        private Rectangle rec;
        private SolidBrush brush;
        private Pen pen;
        private int xOffset=337;
        private int yOffset=138;
        private int rubricWidth=47;
        private int rubricHeight=36;
        private Bitmap ForIn = (Bitmap)Image.FromFile(@"Images\RED.png");
        private Bitmap ForIn2 = (Bitmap)Image.FromFile(@"Images\YELLOW.png");

        private int turn;

        private List<GraphicItemFourInRaw> ballsList;

        private FourInARowLogic logic;

        GraphicItemFourInRaw tool1;

        public GameScreenForm()
        {
            InitializeComponent();
            try
            {
                backGround = Bitmap.FromFile(@"images\board.png");
                rec = new Rectangle(14, 623, 195, 52);
                brush = new SolidBrush(Color.Red);
                pen = new Pen(brush);
                tool1 = new GraphicItemFourInRaw(Types.RED, 100, 200, ForIn);
                //tool1 = new GraphicItemFourInRaw(Types.YELLOW, 100, 200, ForIn2);
                turn = 0;
                logic = new FourInARowLogic(10, 9, 4);

                ballsList = new List<GraphicItemFourInRaw>();
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
            g.DrawImage(backGround, 0, 0, 1150, 710);
        }

        private void PicMouseDown(object sender, MouseEventArgs e)
        {
           // MessageBox.Show((e.X-xOffset)/rubricWidth + " " + (e.Y-yOffset)/rubricHeight);
            int col = (e.X-xOffset)/rubricWidth;
            int line = logic.LocateBall(col);
            if (line > -1)
            {
                if (turn % 2 == 0)
                {
                    ballsList.Add(new GraphicItemFourInRaw(Types.RED, 100, 200, ForIn));
                    ballsList.ElementAt(ballsList.Count - 1).SetLocation(col * rubricWidth + xOffset, line * rubricHeight + yOffset);
                    pictureBox1.Refresh();
                }
                else
                {
                    ballsList.Add(new GraphicItemFourInRaw(Types.YELLOW, 100, 200, ForIn2));
                    ballsList.ElementAt(ballsList.Count - 1).SetLocation(col * rubricWidth + xOffset, line * rubricHeight + yOffset);
                    pictureBox1.Refresh();
                }
                turn += 1;
            }
        }

        private void PicPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //g.DrawLine(pen, 338, 131, 338, 450);
            //for (int w = 337; w < 830; w += 47)
            //{
            //    g.DrawLine(pen, w, 138, w, 463);
            //}
            //for (int h = 138; h < 470; h += 36)
            //{
            //    g.DrawLine(pen, 337, h, 805, h);
            //}
            for (int i = 0; i < ballsList.Count; i++)
            {
                ballsList.ElementAt(i).Draw(g);
            }

        }
    }
}
