using System;
using System.Collections.Generic;
using System.IO;

namespace ML_lab1_Generarea_setului_de_date
{
    class FileWriter
    {
        protected string filePath = "";
        public FileWriter(string path)
        {
            string[] paths = { Environment.CurrentDirectory, @"..\..\..\", path };
            filePath = Path.GetFullPath(Path.Combine(paths));
        }
        public void writePoints(List<(int X, int Y, Zone zone)> points)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var point in points)
                {
                    writer.WriteLine($"{point.X} {point.Y}");
                }
            }
        }
    }
}