using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3
{
    public static class Extensions
    {
        public static dynamic Sum<T>(this IEnumerable<T> elements)
        {
            dynamic sum = default(T);

            foreach (T item in elements)
            {
                sum += item;
            }

            return sum;
        }

        public static dynamic Product<T>(this IEnumerable<T> elements)
        {
            dynamic product = 1;

            foreach (T item in elements)
            {
                product *= item;
            }

            return product;
        }

        public static dynamic Min<T>(this IEnumerable<T> elements)
        {
            dynamic min = long.MaxValue;

            foreach (T item in elements)
            {
                if (item < min)
                {
                    min = item;
                }
            }

            return min;
        }

        public static dynamic Max<T>(this IEnumerable<T> elements)
        {
            dynamic max = long.MinValue;

            foreach (T item in elements)
            {
                if (item > max)
                {
                    max = item;
                }
            }

            return max;
        }

        public static dynamic Average<T>(this IEnumerable<T> elements)
        {
            int count = 0;

            foreach (T item in elements)
            {
                count++;
            }

            return elements.Sum() / count;
        }
    }
}
