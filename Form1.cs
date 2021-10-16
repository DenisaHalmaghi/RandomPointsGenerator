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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var generator = new PointGenerator();
            var points = generator.generate(4000);
            (new FileWriter("puncte.txt")).writePoints(points);
            //show on screen -> new class
        }
    }
}
