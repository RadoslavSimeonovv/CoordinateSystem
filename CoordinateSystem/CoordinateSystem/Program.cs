using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

            var points = new List<Point>();
            using (FileStream stream = File.Open(Environment.CurrentDirectory + "/points.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    var count = 1;
                    while (!reader.EndOfStream)
                    {
                        var point = reader.ReadLine().Split(",");
                        points.Add(new Point($"Point{count}", Convert.ToDouble(point[1]), Convert.ToDouble(point[2])));
                        count++;
                    }
                }
            }

            foreach (var p in points)
            {
                p.ShowQuadrant();
                p.CalculateDistanceFromCenter();
            }

            var max = points.OrderByDescending(x => x.DistanceFromCenter).First();
            Console.WriteLine($"Point {max.Name} is furthest from the center with {max.DistanceFromCenter} distance");
        }
    }
}
