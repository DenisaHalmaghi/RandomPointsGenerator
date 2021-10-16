using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ML_lab1_Generarea_setului_de_date
{
    public partial class Form1 : Form
    {
        List<(int X, int Y, Zone zone)> generatedPoints;
        public Form1()
        {
            InitializeComponent();
            var generator = new PointGenerator();
            generatedPoints = generator.generate(4000);
            (new FileWriter("puncte.txt")).writePoints(generatedPoints);
        }



        private void Form1_Load(object sender, EventArgs e)
        {

            // (new PointsDrawer(panel1)).draw(generatedPoints);
            //show on screen -> new class
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            (new PointsDrawer(e)).draw(generatedPoints);
            //e.Graphics.FillRectangle(new SolidBrush(Color.Blue), 50 * 2, 50 * 2, 2, 2);
        }
    }
}
