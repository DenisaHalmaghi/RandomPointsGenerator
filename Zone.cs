using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ML_lab1_Generarea_setului_de_date
{
    class Zone
    {
        (int min, int max) limits;
        public Zone((int min, int max) limits)
        {
            this.limits = limits;
        }

        public (int X, int Y) middle()
        {
            int middle = (limits.max - limits.min) / 2;
            return (middle, middle);
        }

        public (int X, int Y) sigma()
        {
            var middle = this.middle();
            return (limits.max - middle.X, limits.max - middle.Y);
        }
    }
}
