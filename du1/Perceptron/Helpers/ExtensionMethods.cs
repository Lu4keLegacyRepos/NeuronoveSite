using System;
using System.Collections.Generic;
using System.Text;

namespace Perceptron.Helpers
{
    public static class ExtensionMethods
    {

        public static double Map(this double value, (double from, double to) from, (double from, double to) to)
        {
            return (value - from.from) / (from.to - from.from) * (to.to - to.from) + to.from;
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            var rng = new Random();
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
