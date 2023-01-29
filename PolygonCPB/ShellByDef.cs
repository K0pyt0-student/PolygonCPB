using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonCPB
{
    public partial class Form1
    {
        private void CreateShell_bD(Graphics g)
        {
            for (int i = 0; i < points.Count - 1; i++)
            {
                for (int j = i + 1; j < points.Count; j++)
                {
                    if (CheckIfBorder(i, j, g))
                    {
                        g.DrawLine(new Pen(Brushes.Black), points[i].X, points[i].Y, points[j].X, points[j].Y);
                        points[i].Draw(g);
                        points[j].Draw(g);
                        points[i].IsShell = true;
                        points[j].IsShell = true;
                    }
                }
            }
            for (int i = 0; i < points.Count; i++)
            {
                if (!points[i].IsShell)
                {
                    points.RemoveAt(i);
                    i--;
                }
                else points[i].IsShell = false;
            }

        }

        private bool CheckIfBorder(int i, int j, Graphics g)
        {
            if (points[i].X == points[j].X) return CheckIfBorderUpright(points[i].X, i, j);

            float k = (points[j].Y - points[i].Y) / (points[j].X - points[i].X);
            float b = points[i].Y - points[i].X * k;
            //g.DrawLine(new Pen(Brushes.LightBlue), 0, b, 10000, 10000 * k + b);

            List<Vertex> pointsForChecking = new List<Vertex>(points);
            pointsForChecking.RemoveAt(i);
            pointsForChecking.RemoveAt(j - 1);
            for (int l = 0; l < pointsForChecking.Count - 1; l++)
            {
                if (CheckIfUpperThanLine(k, b, pointsForChecking[l]) != CheckIfUpperThanLine(k, b, pointsForChecking[l + 1])) return false;
            }
            return true;
        }

        private bool CheckIfBorderUpright(float x, int i, int j)
        {
            List<Vertex> pointsForChecking = new List<Vertex>(points);
            pointsForChecking.RemoveAt(i);
            pointsForChecking.RemoveAt(j - 1);
            for (int l = 1; l < pointsForChecking.Count; l++)
            {
                if (CheckIfLeftLine(x, pointsForChecking[l]) != CheckIfLeftLine(x, pointsForChecking[l - 1])) return false;
            }
            return true;
        }

        private bool CheckIfUpperThanLine(float k, float b, Vertex point)
        {
            if (point.X * k + b < point.Y) return false;
            else return true;
        }

        private bool CheckIfLeftLine(float x, Vertex point)
        {
            if (point.X < x) return true;
            else return false;
        }

    }
}
