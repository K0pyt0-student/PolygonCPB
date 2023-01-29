using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonCPB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Refresh();
        }

        List<Vertex> points = new List<Vertex>();
        bool wasAnyPointTouched = false;
        Shapes shape = Shapes.Circle;
        private void AddPoint(int mX, int mY, int r)
        {
            switch (shape)
            {
                case Shapes.Circle: points.Add(new Circle(mX, mY, r)); break;
                case Shapes.Square: points.Add(new Square(mX, mY, r)); break;
                case Shapes.Triangle: points.Add(new Triangle(mX, mY, r)); break;
                default: points.Add(new Circle(mX, mY, r)); break;
            }

        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            int hitnum = -1;
            foreach (Vertex point in points)
            {
                if (e.Button == MouseButtons.Left && point.IsTouched(e.X, e.Y))
                {
                    point.Carried = true;
                    wasAnyPointTouched = true;
                }
                else if (point.IsTouched(e.X, e.Y))
                {
                    hitnum = points.IndexOf(point);
                    wasAnyPointTouched = true;
                }
            }
            if (!wasAnyPointTouched)
            {
                AddPoint(e.X, e.Y, 10);
                Refresh();
                //PointsCounter.Text = points.Count.ToString();
            }
            if (hitnum != -1)
            {
                points.RemoveAt(hitnum);
                Refresh();
            }
            wasAnyPointTouched = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            for(int i = 0; i < points.Count; i++)
            {
                if (e.Button == MouseButtons.Left && points[i].Carried)
                {
                    points[i].Move(e.X, e.Y);
                    Refresh();
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (Vertex point in points) point.Carried = false;
        }

        private void circleToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            PointsCounter.Text = "C";
            if (circleToolStripMenuItem.Checked) shape = Shapes.Circle;
        }

        private void squareToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            PointsCounter.Text = "S";
            if (squareToolStripMenuItem.Checked) shape = Shapes.Square;
        }

        private void triangleToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            PointsCounter.Text = "T";
            if (triangleToolStripMenuItem.Checked) shape = Shapes.Triangle;
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PointsCounter.Text = "C";
            shape = Shapes.Circle;
        }

        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PointsCounter.Text = "S";
            shape = Shapes.Square;
        }

        private void triangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PointsCounter.Text = "T";
            shape = Shapes.Triangle;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            if (points.Count >= 3) CreateShell_bJ(e.Graphics);
            //else
            foreach (Vertex point in points) point.Draw(e.Graphics);
        }
    }
}
