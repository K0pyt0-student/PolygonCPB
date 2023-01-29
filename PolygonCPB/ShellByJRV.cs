using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonCPB
{
    public partial class Form1
    {
        private void CreateShell_bJ(Graphics g)
        {
            Vertex strP = FindFirstPoint();
            Vertex p0 = strP;
            Vertex p1 = FindNextPoint(new Vector(1, 0), p0);
            g.DrawLine(new Pen(Brushes.Black), p0.X, p0.Y, p1.X, p1.Y);
            Vector v0;
            while (p1 != strP)
            {
                v0 = new Vector(p1.X - p0.X, p1.Y - p0.Y);
                p0 = p1;

                p1 = FindNextPoint(v0, p0);
                g.DrawLine(new Pen(Brushes.Black), p0.X, p0.Y, p1.X, p1.Y);
            }
            //Vertex p1 = FindSecondPoint(p0);
        }

        private Vertex FindFirstPoint()
        {
            float min = 0.0f;
            List<Vertex> firstPs = new List<Vertex>();
            firstPs.Add(new Circle(0, 0, 0));
            foreach (Vertex p in points)
            {
                if (p.Y > min)
                {
                    min = p.Y;
                    firstPs[firstPs.Count - 1] = p;
                }
                else if (p.Y == min) firstPs.Add(p);
            }
            if (firstPs.Count == 1) { return firstPs[0]; }
            else
            {
                float maxX = 0.0f;
                Vertex firstP = null;
                foreach(Vertex p in points) 
                {
                    if (p.X > maxX)
                    {
                        maxX = p.X;
                        firstP = p;
                    }
                }
                return firstP;
            }
        }
        /*private Vertex FindSecondPoint(Vertex p0) 
        {
            Vertex p1 = null;
            float maxCtg = 0;
            foreach(Vertex p in points)
            {
                if ((p.X - p0.X) / (p.Y - p0.Y) > maxCtg)
                {
                    maxCtg = (p.X - p0.X) / (p.Y - p0.Y);
                    p1 = p;
                }
            }
            return p1;
        }*/
        private Vertex FindNextPoint(Vector v0, Vertex p0)  
        {
            float maxCos = 0.0f;
            Vertex p1 = new Circle(100, 100, 10);
            Vector v1;
            foreach(Vertex p in points)
            {
                v1 = new Vector(p.X - p0.X, p.Y - p0.Y);
                if (Cos(v0, v1) > maxCos)
                {
                    maxCos = Cos(v0, v1);
                    p1 = p;
                }
            }
            return p1;
        }

        
        private float Cos(Vector v0, Vector v1)
        {
            return Prod(v0, v1) / (Len(v0) + Len(v1));
        }

        private float Len(Vector v)
        {
            return (float)Math.Sqrt(v.X * v.X + v.Y * v.Y);
        }

        private float Prod(Vector v0, Vector v1)
        {
            return v0.X * v1.X + v0.Y * v1.Y;
        }
    }
}
