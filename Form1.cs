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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            (new PointsDrawer(e)).draw(generatedPoints);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
