using System;
using System.Collections.Generic;
using System.IO;

namespace CoordinateSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pointsList = new List<Point>() { new Point("Point1", 1, 2), new Point("Point2", 0, 5), new Point("Point3", -3.4, 5), new Point("Point4", 2, -12.5), new Point("Point5", 2.3, 0) };

            try
            {
                string path = Path.Combine(Environment.CurrentDirectory, "points.txt");
                using (TextWriter tw = new StreamWriter(path))
                {
                    foreach (var point in pointsList)
                    {
                        tw.WriteLine(string.Format("{0},{1},{2}", point.Name, point.PointX, point.PointY));
                    }
                    tw.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            //var x = CalculateDistanceFromCenter("Point1", 3, 2);

            //Console.WriteLine(x);
        }

        static double CalculateDistanceFromCenter(string name, double x, double y)
        {
            double centerX = 0;
            double centerY = 0;

            return Math.Pow((x - centerX), 2) + Math.Pow((y - centerY), 2);
        }

        static void ShowQuadrant(string name, double x, double y)
        {
            if (x == 0)
            {
                Console.WriteLine($"{name} is on the x axis.");
            }
            else if (y == 0)
            {
                Console.WriteLine($"{name} is on the y axis.");
            }
            else if (x > 0 && y > 0)
            {
                Console.WriteLine($"{name} is in 1st quadrant.");
            }
            else if (x > 0 && y < 0)
            {
                Console.WriteLine($"{name} is in 4th quadrant.");
            }
            else if (y > 0 && x < 0)
            {
                Console.WriteLine($"{name} is in 2nd quadrant.");
            }
            else if (y < 0 && x < 0)
            {
                Console.WriteLine($"{name} is in 3rd quadrant.");
            }
        }
    }
}
