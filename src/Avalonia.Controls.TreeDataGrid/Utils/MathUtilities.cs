using System;

namespace Avalonia.Controls
{
    internal static class MathUtilities
    {
        public static bool AreClose(double value1, double value2)
        {
            if (value1 == value2) return true;
            double eps = (Math.Abs(value1) + Math.Abs(value2) + 10.0) * 2.2204460492503131e-16;
            double delta = value1 - value2;
            return -eps < delta && eps > delta;
        }

        public static bool LessThan(double value1, double value2)
        {
            return value1 < value2 && !AreClose(value1, value2);
        }

        public static bool LessThanOrClose(double value1, double value2)
        {
            return value1 < value2 || AreClose(value1, value2);
        }

        public static bool GreaterThan(double value1, double value2)
        {
            return value1 > value2 && !AreClose(value1, value2);
        }

        public static bool GreaterThanOrClose(double value1, double value2)
        {
            return value1 > value2 || AreClose(value1, value2);
        }

        public static bool IsZero(double value)
        {
            return Math.Abs(value) < 10.0 * 2.2204460492503131e-16;
        }
    }
}
