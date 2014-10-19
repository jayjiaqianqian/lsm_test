using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LSM
{
   
    class Grid
    {
        public int zhdnum;
        public double value;
        public Grid(int x)
        {
            zhdnum = x;
        }
    }

    class Gcompare : IComparer<Grid>
    {
        public Gcompare()
        {
        }
        public int Compare(Grid x, Grid y)
        {
            return y.value.CompareTo(x.value);
        }
    }
   
}
