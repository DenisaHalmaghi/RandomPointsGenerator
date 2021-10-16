using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ML_lab1_Generarea_setului_de_date
{
    class Zone
    {
        (int x, int y) _centre;
        (int x, int y) _sigma;
        Color _color;

        public Zone((int, int) centre, (int, int) sigma, Color color)
        {
            _centre = centre;
            _sigma = sigma;
            _color = color;
        }

        public Color Color { get => _color; }
        public (int x, int y) Sigma { get => _sigma; }
        public (int x, int y) Centre { get => _centre; }
    }
}
