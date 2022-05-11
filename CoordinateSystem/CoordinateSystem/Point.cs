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

        public string Name { get; set; }
        public double PointX { get; set; }
        public double PointY { get; set; }
    }
}
