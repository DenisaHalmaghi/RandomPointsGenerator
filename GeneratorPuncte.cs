using System;
using System.Collections.Generic;
using System.Text;

namespace ML_lab1_Generarea_setului_de_date
{
    class GeneratorPuncte
    {
        const int MAX = 300;
        const int MIN = -300;

        Zone zone1 = new Zone((50, 100));
        List<Zone> zones = new List<Zone>();
        Random r = new Random();
        List<(int X, int Y)> points = new List<(int, int)>();

        public GeneratorPuncte()
        {
            zones.Add(zone1);
        }

        public List<(int X, int Y)> generate(int pointCount)
        {

            int zoneIndex = 0;
            Zone zone = null;

            for (int i = 0; i < pointCount; i++)
            {
                //choose random zone
                zoneIndex = r.Next(0, zones.Count - 1);
                zone = zones[zoneIndex];
                //generate a point
                points.Add((generateCoordinate(zone), generateCoordinate(zone, "Y")));
            }

            return points;
        }

        protected int generateCoordinate(Zone zone, string axis = "X")
        {
            int coordinate;
            double probability;
            double threshold;
            do
            {
                coordinate = r.Next(MIN, MAX);
                var middle = zone.middle().X;
                var sigma = zone.sigma().X;
                if (axis.ToLower() == "y")
                {
                    middle = zone.middle().Y;
                    sigma = zone.sigma().Y;
                }
                probability = gauss(coordinate, middle, sigma);
                threshold = r.NextDouble();
            } while (probability <= threshold);

            return coordinate;

        }

        protected double gauss(int x, int m, int sigma)
        {
            double power = -Math.Pow(m - x, 2) / (2 * Math.Pow(sigma, 2));
            return Math.Pow(Math.E, power);
        }
    }
}
