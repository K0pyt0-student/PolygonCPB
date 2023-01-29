using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonCPB
{
    enum Shapes { Circle, Square, Triangle }
    internal abstract class Vertex
    {
        protected float x;
        protected float y;
        protected int r;
        protected bool IsBeingCarried;
        protected bool IsThisShell;
        protected float shiftX;
        protected float shiftY;
        
        public float X
        {
            get { return x; }
            set { x = value; }
        }
        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public abstract void Draw(Graphics g);
        public abstract bool IsTouched(float MouseX, float MouseY);


        public virtual void Move(float mouseX, float mouseY)
        {
            x = mouseX - shiftX;
            y = mouseY - shiftY;
        }

        public Vertex()
        {
            x = 100;
            y = 100;
            r = 10;
            IsBeingCarried = false;
            IsThisShell = false;
        }

        public Vertex(float x, float y, int r)
        {
            this.x = x;
            this.y = y;
            this.r = r;
            IsBeingCarried = false;
            IsThisShell = false;
        }

        public bool Carried
        {
            get { return IsBeingCarried; }
            set { IsBeingCarried = value; }
        }
        public bool IsShell
        {
            get { return IsThisShell; }
            set { IsThisShell = value; }
        }
    }

    internal class Circle : Vertex
    {
        public Circle(float x, float y, int r) : base(x, y, r) { }

        public override void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Black);
            g.FillEllipse(brush, x - r, y - r, 2 * r, 2 * r);
        }

        public override bool IsTouched(float MouseX, float MouseY)
        {
            shiftX = MouseX - x;
            shiftY = MouseY - y;
            return shiftX * shiftX + shiftY * shiftY <= r * r;
        }
    }

    internal class Square : Vertex
    {
        public Square(int x, int y, int r) : base(x, y, r) { }

        public override void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Black);
            g.FillRectangle(brush, x - r, y - r, 2 * r, 2 * r);
        }

        public override bool IsTouched(float MouseX, float MouseY)
        {
            shiftX = MouseX - x;
            shiftY = MouseY - y;
            return Math.Abs(shiftX) <= r && Math.Abs(shiftY) <= r;
        }
    }

    internal class Triangle : Vertex
    {
        private PointF[] points = new PointF[3];
        public Triangle(float x, float y, int r) : base(x, y, r)
        {
            points[0] = new PointF(Convert.ToInt32(x - Math.Sqrt(3) * r), y + r);
            points[1] = new PointF(Convert.ToInt32(x + Math.Sqrt(3) * r), y + r);
            points[2] = new PointF(x, y - r);
        }

        public override void Move(float mouseX, float mouseY)
        {
            base.Move(mouseX, mouseY);
            points[0] = new PointF(Convert.ToInt32(x - Math.Sqrt(3) * r), y + r);
            points[1] = new PointF(Convert.ToInt32(x + Math.Sqrt(3) * r), y + r);
            points[2] = new PointF(x, y - r);
        }

        public override void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Black);
            g.FillPolygon(brush, points);
        }

        public override bool IsTouched(float MouseX, float MouseY)
        {
            shiftX = MouseX - x;
            shiftY = MouseY - y;
            return shiftY <= r && shiftY >= -2 / Math.Sqrt(3) * shiftX - r && shiftY >= 2 / Math.Sqrt(3) * shiftX - r;
        }
    }
}
