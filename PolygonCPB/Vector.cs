using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonCPB
{
    internal class Vector
    {
        private float x, y;

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

        public Vector(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
