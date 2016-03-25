using System;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public struct BezierSpline
    {
        public BezierSpline(Point point0, Point point1, Point point2, Point point3)
            : this()
        {
            Point0 = point0;
            Point1 = point1;
            Point2 = point2;
            Point3 = point3;
        }

        public Point Point0 { private set; get; }

        public Point Point1 { private set; get; }

        public Point Point2 { private set; get; }

        public Point Point3 { private set; get; }

        public Point GetPointAtFractionLength(double t, out Point tangent)
        {
            // Calculate point on curve.
            double x = (1 - t) * (1 - t) * (1 - t) * Point0.X +
                       3 * t * (1 - t) * (1 - t) * Point1.X +
                       3 * t * t * (1 - t) * Point2.X +
                       t * t * t * Point3.X;

            double y = (1 - t) * (1 - t) * (1 - t) * Point0.Y +
                       3 * t * (1 - t) * (1 - t) * Point1.Y +
                       3 * t * t * (1 - t) * Point2.Y +
                       t * t * t * Point3.Y;

            Point point = new Point(x, y);

            // Calculate tangent to curve.
            x = 3 * (1 - t) * (1 - t) * (Point1.X - Point0.X) +
                6 * t * (1 - t) * (Point2.X - Point1.X) +
                3 * t * t * (Point3.X - Point2.X);

            y = 3 * (1 - t) * (1 - t) * (Point1.Y - Point0.Y) +
                6 * t * (1 - t) * (Point2.Y - Point1.Y) +
                3 * t * t * (Point3.Y - Point2.Y);

            tangent = new Point(x, y);
            return point;
        }
    }
}
