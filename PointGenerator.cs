using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ML_lab1_Generarea_setului_de_date
{
    class PointGenerator
    {


        Zone zone1 = new Zone((50, 50), (20, 20), Color.Red);

        Zone zone2 = new Zone((-150, -150), (30, 30), Color.Blue);
        List<Zone> zones = new List<Zone>();
        Random r = new Random();
        List<(int X, int Y, Zone zone)> points = new List<(int, int, Zone zone)>();

        public PointGenerator()
        {
            zones.Add(zone1);
            zones.Add(zone2);
        }

        public List<(int X, int Y, Zone zone)> generate(int pointCount)
        {

            int zoneIndex = 0;
            Zone zone = null;

            for (int i = 0; i < pointCount; i++)
            {
                //choose random zone
                zoneIndex = r.Next(0, zones.Count);
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
                coordinate = r.Next(Constants.MIN, Constants.MAX);
                var m = zone.Centre.x;
                var sigma = zone.Sigma.x;
                if (axis.ToLower() == "y")
                {
                    m = zone.Centre.y;
                    sigma = zone.Sigma.y;
                }
                probability = gauss(coordinate, m, sigma);
                threshold = r.NextDouble();

            } while (probability <= threshold);

            return coordinate;

        }

        protected double gauss(int coordinate, int m, int sigma)
        {
            double power = Math.Pow(m - coordinate, 2) / (2 * Math.Pow(sigma, 2));
            return Math.Pow(Math.E, -power);
        }
    }
}
