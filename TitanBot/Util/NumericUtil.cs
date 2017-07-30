﻿using System.Linq;

namespace System
{
    public static class NumericUtil
    {
        public static int Clamp(this int value, int lower, int upper)
            => new int[] { value, lower, upper }.OrderBy(v => v).Skip(1).First();
        public static double Clamp(this double value, double lower, double upper)
            => new double[] { value, lower, upper }.OrderBy(v => v).Skip(1).First();
    }
}
