using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ML_lab1_Generarea_setului_de_date
{
    class PointGenerator
    {
        const int MAX = 300;
        const int MIN = -300;

        Zone zone1 = new Zone((50, 50), (20, 20), Color.Red);
        List<Zone> zones = new List<Zone>();
        Random r = new Random();
        List<(int X, int Y, Zone zone)> points = new List<(int, int, Zone zone)>();

        public PointGenerator()
        {
            zones.Add(zone1);
        }

        public List<(int X, int Y, Zone zone)> generate(int pointCount)
        {

            int zoneIndex = 0;
            Zone zone = null;

            for (int i = 0; i < pointCount; i++)
            {
                //choose random zone
                zoneIndex = r.Next(0, zones.Count - 1);
                zone = zones[zoneIndex];
                //generate a point
                points.Add((generateCoordinate(zone), generateCoordinate(zone, "Y"), zone));
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
                var middle = zone.Centre.x;
                var sigma = zone.Sigma.x;
                if (axis.ToLower() == "y")
                {
                    middle = zone.Centre.y;
                    sigma = zone.Sigma.y;
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
