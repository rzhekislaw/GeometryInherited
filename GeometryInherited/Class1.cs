namespace GeometryInherited
{
    #region Tools
    public static class Extentions
    {
        public static double Multiplication(this double[] array)
        {
            double result = 1;
            for(int i = 0; i < array.Length; i++)
            {
                result *= array[i];
            }
            return result;
        }
    }
    #endregion
    public class ArbitraryFigure
    {
        public int baseSidesCount;

        public double[] baseSides;
    }

    #region Triangle

    public class Triangle : ArbitraryFigure
    {
        public double a;

        public double h;

        public double R;

        public double r;

        public double angle;

        #region Perimeter
        public static double GetPerimeterVia3Sides(Triangle t)
        {
            if(t.baseSidesCount != 3)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if(t.baseSides.Any(a => a <= 0))
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            return t.baseSides.Sum();
        }

        public static double GetRegularTrianglePerimeter(Triangle t)
        {
            if (t.baseSidesCount != 3)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (t.a <= 0)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            return t.a * 3;
        }

        #endregion

        #region Area
        public static double GetAreaVia3BaseSides(Triangle t)
        {
            if (t.baseSidesCount != 3)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (t.baseSides.Any(a => a <= 0) || t.baseSides.Count() != 3)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            double p = GetPerimeterVia3Sides(t) / 2;
            return (Math.Sqrt(p * (p - t.baseSides[0]) * (p - t.baseSides[1]) * (p - t.baseSides[2])));
        }
        public static double GetAreaViaSideAndHeight(Triangle t)
        {
            if (t.baseSidesCount != 3)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (t.a <= 0 || t.h <= 0)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            return (t.a * t.h) / 2;
        }
        public static double GetAreaVia2BaseSidesAndAngle(Triangle t)
        {
            if (t.baseSidesCount != 3)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (t.baseSides.Any(a => a <= 0) || t.baseSides.Count() != 2)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if(t.angle <= 0)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            return (t.baseSides[0] * t.baseSides[1] * Math.Sin(t.angle));
        }
        public static double GetAreaViabaseSidesAndOuterRadius(Triangle t)
        {
            if (t.baseSidesCount != 3)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (t.baseSides.Any(a => a <= 0) || t.baseSides.Count() != 3)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if(t.R <= 0)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            return (t.baseSides.Multiplication() / (t.R * 4));
        }
        public static double GetAreaViabaseSidesAndInnerRadius(Triangle t)
        {
            if (t.baseSidesCount != 3)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (t.baseSides.Any(a => a <= 0) || t.baseSides.Count() != 3)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (t.r <= 0)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            double p = GetPerimeterVia3Sides(t) / 2;
            return p * t.r;
        }

        #endregion

    }

    public class TriangularPrism : Triangle
    {
        public double h;

        public TriangularPrism(int baseSidesCount = 0, double[] baseSides = null, double a = 0, double base_h = 0, double R = 0, double r = 0, double angle = 0, double h = 0)
        {
            if (baseSidesCount != 0)
            {
                this.baseSidesCount = baseSidesCount;
            }
            if (baseSides != null)
            {
                if (baseSides is double[])
                {
                    this.baseSides = baseSides as double[];
                }
            }
            if (a != 0)
            {
                this.a = a;
            }
            if (base_h != 0)
            {
                base.h = base_h;
            }
            if (R != 0)
            {
                this.R = R;
            }
            if (r != 0)
            {
                this.r = r;
            }
            if (angle != 0)
            {
                this.angle = angle;
            }
            if (h != 0)
            {
                this.h = h;
            }
        }
        public static double GetVolumeVia3BaseSides(TriangularPrism tp)
        {
            if (tp.baseSidesCount != 3)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (tp.baseSides.Any(a => a <= 0) || tp.baseSides.Count() != 3)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (tp.h <= 0)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            var S = GetAreaVia3BaseSides(tp);
            if(S == -1)
            {
                return -1;
            }
            return S * tp.h;
        }

        public static double GetVolumeViaBaseSideAndHeight(TriangularPrism tp)
        {
            if (tp.baseSidesCount != 3)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if(tp.a <=0 || ((Triangle)tp).h <= 0)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            var S = GetAreaViaSideAndHeight((Triangle)tp);
            return S * tp.h;
        }

        public static double GetVolumeVia2baseSidesAndBaseAngle(TriangularPrism tp)
        {
            if (tp.baseSidesCount != 3)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (tp.baseSides.Any((double a) => a <= 0) || tp.baseSides.Count() != 2)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1.0;
            }
            if (tp.angle <= 0)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            var S = GetAreaVia2BaseSidesAndAngle(tp);
            return S * tp.h;
        }

        public static double GetVolumeViabaseSidesAndOuterRadius(TriangularPrism tp)
        {
            if (tp.baseSidesCount != 3)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }

            if (tp.baseSides.Any((double a) => a <= 0) || tp.baseSides.Count() != 3)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }

            if (tp.R <= 0)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }

            var S = GetAreaViabaseSidesAndOuterRadius(tp);
            return S * tp.h;
        }

        public static double GetVolumeViabaseSidesAndInnerRadius(TriangularPrism tp)
        {
            if (tp.baseSidesCount != 3)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (tp.baseSides.Any(a => a <= 0) || tp.baseSides.Count() != 3)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (tp.r <= 0)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            var S = GetAreaViabaseSidesAndInnerRadius(tp);
            return S * tp.h;
        }
    }

    #endregion

    #region Square

    public class Square : ArbitraryFigure
    {
        public double d;

        #region Perimeter

        public static double GetPerimeterViaSide(Square s)
        {
            if (s.baseSidesCount != 4)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (s.baseSides.Any(a => a <= 0))
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (s.baseSides.Any(a => a != s.baseSides[0]))
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }

            return s.baseSides.Sum();
        }

        public static double GetPerimeterViaDiagonal(Square s)
        {
            if (s.baseSidesCount != 4)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (s.d <= 0)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (s.baseSides.Any(a => a != s.baseSides[0]))
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            return Math.Sqrt(2) * 2 * s.d;
        }

        #endregion

        #region Area

        public static double GetAreaViaSide(Square s)
        {
            if (s.baseSidesCount != 4)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (s.baseSides.Any(a => a <= 0))
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (s.baseSides.Any(a => a != s.baseSides[0]))
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }

            return Math.Pow(s.baseSides[0], 2);
        }

        public static double GetAreaViaDiagonal(Square s)
        {
            if (s.baseSidesCount != 4)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (s.baseSides.Any(a => a <= 0))
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (s.baseSides.Any(a => a != s.baseSides[0]))
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }

            return Math.Pow(s.d, 2) / 2;
        }

        #endregion
    }

    public class Cube : Square
    {
        public static double GetVolumeViaSide(Cube c)
        {
            if (c.baseSidesCount != 4)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (c.baseSides.Any(a => a <= 0))
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (c.baseSides.Any(a => a != c.baseSides[0]))
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }

            return GetAreaViaSide(c) * c.baseSides[0];
        }
    }

    #endregion

    #region Rectangle

    public class Rectangle : ArbitraryFigure
    {
        #region Perimeter

        public static double GetPerimeter(Rectangle r)
        {
            if (r.baseSidesCount != 4)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (r.baseSides.Any(a => a <= 0))
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (r.baseSides.Distinct().Count() != 2)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }

            return r.baseSides.Sum();
        }

        #endregion

        #region Area

        public static double GetArea(Rectangle r)
        {
            if (r.baseSidesCount != 4)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (r.baseSides.Any(a => a <= 0))
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (r.baseSides.Distinct().Count() != 2)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            
            return r.baseSides.Distinct().ToArray().Multiplication();
        }

        #endregion
    }

    public class Parallelepiped : Rectangle
    {
        double h;

        public static double GetVolume(Parallelepiped p)
        {
            if (p.baseSidesCount != 4)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (p.baseSides.Any(a => a <= 0))
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (p.baseSides.Distinct().Count() != 2)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            return GetArea(p) * p.h;
        }
    }

    #endregion

    #region Rhombus

    public class Rhombus : ArbitraryFigure
    {
        public float angle;

        public double[] diagonals;

        public double h;

        #region Perimeter

        public static double GetPerimeter(Rhombus r)
        {
            if (r.baseSidesCount != 4)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (r.baseSides.Any(a => a <= 0))
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (r.baseSides.Distinct().Count() != 1)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            return r.baseSides.Sum();
        }

        #endregion

        #region Area

        public static double GetAreaViaSideAndHeight(Rhombus r)
        {
            if (r.baseSidesCount != 4)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (r.baseSides.Any(a => a <= 0))
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (r.baseSides.Distinct().Count() != 1)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (r.h <= 0)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            return r.baseSides[0] * r.h;
        }

        public static double GetAreaViaSideAndAngle(Rhombus r)
        {
            if (r.baseSidesCount != 4)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (r.baseSides.Any(a => a <= 0))
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (r.baseSides.Distinct().Count() != 1)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (r.angle <= 0)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            return Math.Pow(r.baseSides[0], 2) * Math.Sin(r.angle);
        }

        public static double GetAreaViaDiagonals(Rhombus r)
        {
            if (r.baseSidesCount != 4)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (r.diagonals.Any(a => a <= 0))
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (r.diagonals.Count() != 2)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            return ((r.diagonals[0] * r.diagonals[1]) / 2);
        }

        #endregion
    }

    #endregion

    #region Parallelogram

    public class Parallelogram : ArbitraryFigure
    {
        public double h;

        public double[] diagonals;

        public float a_b_angle;

        public float d1_d2_angle;

        #region Perimeter

        public static double GetPerimeter(Parallelogram p)
        {
            if (p.baseSidesCount != 4)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (p.baseSides.Any(a => a <= 0))
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (p.baseSides.Distinct().Count() != 2)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }

            return p.baseSides.Sum();
        }

        #endregion

        #region Area

        public static double GetAreaViaSideAndHeight(Parallelogram p)
        {
            if (p.baseSidesCount != 4)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (p.baseSides.Any(a => a <= 0))
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (p.baseSides.Distinct().Count() != 1)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (p.h <= 0)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            return p.baseSides[0] * p.h;
        }

        public static double GetAreaVia2SidesAndAngle(Parallelogram p)
        {
            if (p.baseSidesCount != 4)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (p.baseSides.Any(a => a <= 0))
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (p.a_b_angle <= 0)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            return (p.baseSides.Distinct().ToArray()[0] * p.baseSides.Distinct().ToArray()[1]) * Math.Sin(p.a_b_angle);
        }

        public static double GetAreaVia2DiagonalsAndAngle(Parallelogram p)
        {
            if (p.baseSidesCount != 4)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (p.diagonals.Distinct().Count() != 2)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (p.d1_d2_angle <= 0)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            return (p.diagonals.Distinct().ToArray()[0] * p.diagonals.Distinct().ToArray()[1]) * Math.Sin(p.d1_d2_angle) / 2;
        }

        #endregion
    }

    #endregion

    #region Trapezoid

    public class Trapezoid : ArbitraryFigure
    {
        public double h;

        public double upper_base;

        public double lower_base;

        #region Perimeter

        public static double GetPerimeter(Trapezoid t)
        {
            if (t.baseSidesCount != 4)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (t.baseSides.Any(a => a <= 0))
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }

            return t.baseSides.Sum();
        }

        #endregion

        #region Area

        public static double GetAreaViaBasesAndHeight(Trapezoid t)
        {
            if (t.baseSidesCount != 4)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (t.h <= 0 || t.upper_base <= 0 || t.lower_base <= 0)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            return (t.upper_base + t.lower_base) * t.h / 2;
        }

        public static double GetAreaViaSides(Trapezoid t)
        {
            if (t.baseSidesCount != 4)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (t.baseSides.Any(a => a <= 0))
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            double p = (t.baseSides[0] + t.baseSides[1] + t.baseSides[2] + t.baseSides[3]) / 2;
            return (Math.Sqrt((p - t.baseSides[0]) * (p - t.baseSides[1]) * (p - t.baseSides[0] - t.baseSides[2]) * (p - t.baseSides[0] - t.baseSides[4]))) * ((t.baseSides[0] + t.baseSides[1]) / (Math.Abs(t.baseSides[0] - t.baseSides[1])));
        }

        #endregion
    }

    #endregion

    #region Circle

    public class Circle : ArbitraryFigure
    {
        public double r;

        public double d;

        #region Perimeter

        public static double GetPerimeterViaRadius(Circle c)
        {
            if (c.baseSidesCount != double.PositiveInfinity)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (c.r <= 0)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }

            return Math.PI * 2 * c.r;
        }

        public static double GetPerimeterViaDiameter(Circle c)
        {
            if (c.baseSidesCount != double.PositiveInfinity)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (c.d <= 0)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }

            return Math.PI * c.d;
        }

        #endregion

        #region Area
        public static double GetAreaViaRadius(Circle c)
        {
            if (c.baseSidesCount != double.PositiveInfinity)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (c.r <= 0)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }

            return Math.PI * Math.Pow(c.r, 2);
        }

        public static double GetAreaViaDiameter(Circle c)
        {
            if (c.baseSidesCount != double.PositiveInfinity)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (c.d <= 0)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }

            return Math.PI * Math.Pow(c.d, 2) / 4;
        }
        #endregion
    }

    public class Sphere : Circle
    {
        public double GetVolume(Sphere s)
        {
            if (s.baseSidesCount != double.PositiveInfinity)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (s.r <= 0)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            return (4 * Math.PI * Math.Pow(s.r, 3)) / 3;
        }
    }

    #endregion

    #region Ellipse

    public class Ellipse : ArbitraryFigure
    {
        public double minor_axix;

        public double major_axix;

        #region Perimeter
        public static double GetPerimeter(Ellipse e)
        {
            if (e.baseSidesCount != double.PositiveInfinity)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (e.minor_axix <= 0 || e.major_axix <= 0)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            return ((4 * Math.PI * e.minor_axix * e.major_axix) + (e.minor_axix - e.major_axix)) / (e.minor_axix + e.major_axix);
        }
        #endregion

        #region Area
        public static double GetArea(Ellipse e)
        {
            if (e.baseSidesCount != double.PositiveInfinity)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (e.minor_axix <= 0 || e.major_axix <= 0)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            return Math.PI * e.minor_axix * e.major_axix;
        }

        #endregion
    }

    #endregion

    #region Cylinder

    public class Cylinder : ArbitraryFigure
    {
        public double r;

        public double h;

        #region Area

        public static double GetArea(Cylinder c)
        {
            if (c.baseSidesCount != double.PositiveInfinity)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (c.r <= 0 || c.h <= 0)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            return Math.PI * c.r * c.h * 2;
        }

        #endregion

        #region Volume

        public static double GetVolume(Cylinder c)
        {
            if (c.baseSidesCount != double.PositiveInfinity)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (c.r <= 0 || c.h <= 0)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            return Math.PI * Math.Pow(c.r, 2) * c.h;
        }

        #endregion
    }

    #endregion

    #region Cone

    public class Cone : ArbitraryFigure
    {
        public double r;

        public double h;
        
        public double l;

        #region Area

        public static double GetArea(Cone c)
        {
            if (c.baseSidesCount != double.PositiveInfinity)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (c.r <= 0 || c.l <= 0)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            return (Math.PI * c.r * c.l) + (Math.PI * Math.Pow(c.r, 2));
        }

        #endregion

        #region Volume

        public static double GetVolume(Cone c)
        {
            if (c.baseSidesCount != double.PositiveInfinity)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            if (c.r <= 0 || c.h <= 0)
            {
                Console.WriteLine("Wrong attribute of figure was set during creating");
                return -1;
            }
            return (Math.PI * c.h * Math.Pow(c.r, 2)) / 3;
        }

        #endregion
    }

    #endregion
}