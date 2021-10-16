using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ML_lab1_Generarea_setului_de_date
{
    class PointsDrawer
    {
        CartesianToScreenCoordinates converter = new CartesianToScreenCoordinates();
        PaintEventArgs canvas;

        public PointsDrawer(PaintEventArgs control)
        {
            this.canvas = control;
        }
        public void draw(List<(int X, int Y, Zone zone)> points)
        {
            canvas.Graphics.FillRectangle(new SolidBrush(Color.Blue), 50, 50, 10, 10);

            foreach (var point in points)
            {
                var brush = new SolidBrush(point.zone.Color);
                canvas.Graphics.FillRectangle(brush, converter.Ox(point.X), converter.Oy(point.Y), 1, 1);
            }
        }
    }
}