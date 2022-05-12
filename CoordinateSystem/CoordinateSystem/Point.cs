using System;

namespace CoordinateSystem
{
    public class Point
    {
        public Point(string name, double x, double y)
        {
            this.Name = name;
            this.PointX = x;
            this.PointY = y;
        }

        public string Name { get; private set; }
        public double PointX { get; private set; }
        public double PointY { get; private set; }
        public double DistanceFromCenter { get; private set; }

        public void SetDistance(double distance)
        {
            this.DistanceFromCenter = distance;
        }

        public void ShowQuadrant()
        {
            if (this.PointX == 0)
            {
                Console.WriteLine($"{this.Name} is on the x axis.");
            }
            else if (this.PointY == 0)
            {
                Console.WriteLine($"{this.Name} is on the y axis.");
            }
            else if (this.PointX > 0 && this.PointY > 0)
            {
                Console.WriteLine($"{this.Name} is in the 1st quadrant.");
            }
            else if (this.PointX > 0 && this.PointY < 0)
            {
                Console.WriteLine($"{this.Name} is in the 4th quadrant.");
            }
            else if (this.PointY > 0 && this.PointX < 0)
            {
                Console.WriteLine($"{this.Name} is in the 2nd quadrant.");
            }
            else if (this.PointY < 0 && this.PointX < 0)
            {
                Console.WriteLine($"{this.Name} is in the 3rd quadrant.");
            }
        }

        public void CalculateDistanceFromCenter()
        {
            double centerX = 0;
            double centerY = 0;

            SetDistance(Math.Pow((this.PointX - centerX), 2) + Math.Pow((this.PointY - centerY), 2));
        }
    }
}
