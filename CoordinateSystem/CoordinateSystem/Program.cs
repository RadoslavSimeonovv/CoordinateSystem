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
            var numberOfPoints = 0;
            Console.WriteLine("Enter the number of points:");
            while (!int.TryParse(Console.ReadLine(), out numberOfPoints))
            {
                Console.WriteLine("Enter a valid integer number");
            }

            try
            {
                var i = 1;
                string path = Path.Combine(Environment.CurrentDirectory, "points.txt");
                using (TextWriter tw = new StreamWriter(path))
                {
                    while (i <= numberOfPoints)
                    {
                        var pointX = 0.0;
                        var pointY = 0.0;
                        Console.WriteLine($"Enter point{i} X:");
                        while (!double.TryParse(Console.ReadLine(), out pointX))
                        {
                            Console.WriteLine("Invalid format, please input again!");
                        };
                        Console.WriteLine($"Enter point{i} Y:");
                        while (!double.TryParse(Console.ReadLine(), out pointY))
                        {
                            Console.WriteLine("Invalid format, please input again!");
                        };
                        tw.WriteLine(string.Format("{0},{1}", pointX, pointY));
                        i++;
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
                Console.WriteLine("Finishing input\n");
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
                        points.Add(new Point($"Point{count}", Convert.ToDouble(point[0]), Convert.ToDouble(point[1])));
                        count++;
                    }
                }
            }

            foreach (var p in points)
            {
                p.ShowQuadrant();
                p.CalculateDistanceFromCenter();
            }

            var maxDistance = points.Max(y => y.DistanceFromCenter);
            var furthestPoints = points.Where(x => x.DistanceFromCenter == maxDistance).ToList();

            Console.WriteLine($"The furthest points from the center are {String.Join(", ", furthestPoints.Select(x => x.Name))} with {furthestPoints[0].DistanceFromCenter} distance");
        }
    }
}
