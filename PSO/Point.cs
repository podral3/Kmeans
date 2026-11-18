using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO;

public record struct Point(int X, int Y)
{
    public static Point operator +(Point p1, Point p2)
    {
        return new Point(p1.X + p2.X, p1.Y + p2.Y);
    }
    public static Point operator -(Point p1, Point p2)
    {
        return new Point(p1.X - p2.X, p1.Y - p2.Y);
    }
    public static Point operator *(Point p1, int num)
    {
        return new Point(num * p1.X, num * p1.Y);
    }
    public static Point operator *(int num, Point p1)
    {
        return new Point(num * p1.X, num * p1.Y);
    }
}
