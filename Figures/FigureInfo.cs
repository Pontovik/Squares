namespace Figures
{
    interface IFigure
    {
        double GetSquare();
    }

    class Figure : IFigure
    {
        public virtual double GetSquare()
        {
            if (this == null)
            {
                throw new ArgumentNullException("figure is null");
            }

            if (this is Triangle)
            {
                var triangle = (Triangle)this;
                return triangle.GetSquare();
            }

            else if (this is Circle)
            {
                var circle = (Circle)this;
                return circle.GetSquare();
            }

            else
            {
                throw new ArgumentException("unknown type of figure");
            }
        }
    }
    class Triangle : Figure, IFigure
    {
        readonly int a;
        readonly int b;
        readonly int c;
        public Triangle(int a, int b, int c)
        {
            if (a < 0 || b < 0 || c < 0)
            {
                throw new ArgumentException("Sides must be positive");
            }

            this.a = a;
            this.b = b;
            this.c = c;
        }

        new public double GetSquare()
        {
            if (this == null)
            {
                throw new ArgumentNullException("figure is null");
            }

            if (!(this is Triangle))
            {
                throw new ArgumentException("its not a triangle");
            }

            if (a * a + b * b == c * c)
            {
                return a * b * 0.5;
            }

            if (a * a + c * c == b * b)
            {
                return 0.5 * a * c;
            }

            if (c * c + b * b == a * a)
            {
                return 0.5 * b * c;
            }

            var halfPerim = 0.5 * (a + b + c);

            return Math.Sqrt(halfPerim * (halfPerim - a) * (halfPerim - b) * (halfPerim - c));
        }
    }

    class Circle : Figure, IFigure
    {
        readonly int rad;
        public Circle(int rad)
        {
            if (rad < 0)
            {
                throw new ArgumentException("Radius must be positive");
            }

            this.rad = rad;
        }

        new public double GetSquare()
        {
            if (this == null)
            {
                throw new ArgumentNullException("figure is null");
            }

            if (!(this is Circle))
            {
                throw new ArgumentException("its not a circle");
            }

            return Math.PI * rad * rad;
        }
    }
}