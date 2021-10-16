using System;
using System.Collections.Generic;
using System.Text;

namespace ML_lab1_Generarea_setului_de_date
{
    class CartesianToScreenCoordinates
    {
        public int Ox(int x)
        {
            return Constants.MAX + x;
        }

        public int Oy(int y)
        {
            return Constants.MAX - y;
        }
    }
}
