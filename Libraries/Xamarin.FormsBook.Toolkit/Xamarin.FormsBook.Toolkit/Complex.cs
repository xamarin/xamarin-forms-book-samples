using System;

namespace Xamarin.FormsBook.Toolkit
{
    // Mostly a subset of System.Numerics.Complex.
    public struct Complex : IEquatable<Complex>, IFormattable
    {
        bool gotMagnitude, gotMagnitudeSquared;
        double magnitude, magnitudeSquared;

        public Complex(double real, double imaginary)
            : this()
        {
            Real = real;
            Imaginary = imaginary;
        }

        public double Real { private set; get; }

        public double Imaginary { private set; get; }

        // MagnitudeSquare and Magnitude calculated on demand and saved.
        public double MagnitudeSquared
        {
            get
            {
                if (gotMagnitudeSquared)
                {
                    return magnitudeSquared;
                }

                magnitudeSquared = Real * Real + Imaginary * Imaginary;
                gotMagnitudeSquared = true;
                return magnitudeSquared;
            }
        }

        public double Magnitude
        {
            get
            {
                if (gotMagnitude)
                {
                    return magnitude;
                }

                magnitude = Math.Sqrt(MagnitudeSquared);
                gotMagnitude = true;
                return magnitude;
            }
        }

        public static Complex operator +(Complex left, Complex right)
        {
            return new Complex(left.Real + right.Real, left.Imaginary + right.Imaginary);
        }

        public static Complex operator -(Complex left, Complex right)
        {
            return new Complex(left.Real - right.Real, left.Imaginary - right.Imaginary);
        }

        public static Complex operator *(Complex left, Complex right)
        {
            return new Complex(left.Real * right.Real - left.Imaginary * right.Imaginary,
                               left.Real * right.Imaginary + left.Imaginary * right.Real);
        }

        public static bool operator ==(Complex left, Complex right)
        {
            return left.Real == right.Real && left.Imaginary == right.Imaginary;
        }

        public static bool operator !=(Complex left, Complex right)
        {
            return !(left == right);
        }

        public static implicit operator Complex(double value)
        {
            return new Complex(value, 0);
        }

        public static implicit operator Complex(int value)
        {
            return new Complex(value, 0);
        }

        public override int GetHashCode()
        {
            return Real.GetHashCode() + Imaginary.GetHashCode();
        }

        public override bool Equals(Object value)
        {
            return Real.Equals(((Complex)value).Real) &&
                   Imaginary.Equals(((Complex)value).Imaginary);
        }

        public bool Equals(Complex value)
        {
            return Real.Equals(value) && Imaginary.Equals(value);
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}i", Real,
                                                 RealImaginaryConnector(Imaginary),
                                                 Math.Abs(Imaginary));
        }

        public string ToString(string format)
        {
            return String.Format("{0} {1} {2}i", Real.ToString(format),
                                                 RealImaginaryConnector(Imaginary),
                                                 Math.Abs(Imaginary).ToString(format));
        }

        public string ToString(IFormatProvider formatProvider)
        {
            return String.Format("{0} {1} {2}i", Real.ToString(formatProvider),
                                                 RealImaginaryConnector(Imaginary),
                                                 Math.Abs(Imaginary).ToString(formatProvider));
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return String.Format("{0} {1} {2}i", Real.ToString(format, formatProvider),
                                                 RealImaginaryConnector(Imaginary),
                                         Math.Abs(Imaginary).ToString(format, formatProvider));
        }

        string RealImaginaryConnector(double value)
        {
            return Math.Sign(value) > 0 ? "+" : "\u2013";
        }
    }
}

