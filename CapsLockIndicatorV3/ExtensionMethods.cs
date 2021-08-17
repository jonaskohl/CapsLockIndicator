using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapsLockIndicatorV3
{
    public static class ExtensionMethods
    {
        public static void Deconstruct<T>(this IEnumerable<T> list, out T first, out T second)
        {
            first = list.Count() > 0 ? list.ElementAt(0) : default(T);
            second = list.Count() > 1 ? list.ElementAt(1) : default(T);
        }

        public static void Deconstruct<T, U>(this U list, out T first, out T second, out U rest) where U : IEnumerable<T>
        {
            first = list.Count() > 0 ? list.ElementAt(0) : default(T);
            second = list.Count() > 1 ? list.ElementAt(1) : default(T);
            rest = (U)list.Skip(2);
        }

        /// <summary>Blends the specified colors together.</summary>
        /// <param name="color">Color to blend onto the background color.</param>
        /// <param name="backColor">Color to blend the other color onto.</param>
        /// <param name="amount">How much of <paramref name="color"/> to keep,
        /// “on top of” <paramref name="backColor"/>.</param>
        /// <returns>The blended colors.</returns>
        public static Color Blend(this Color color, Color backColor, double amount)
        {
            byte r = (byte)((color.R * amount) + backColor.R * (1 - amount));
            byte g = (byte)((color.G * amount) + backColor.G * (1 - amount));
            byte b = (byte)((color.B * amount) + backColor.B * (1 - amount));
            return Color.FromArgb(r, g, b);
        }

        public static void Deconstruct<T>(this T[] items, out T t0)
        {
            t0 = items.Length > 0 ? items[0] : default(T);
        }

        public static void Deconstruct<T>(this T[] items, out T t0, out T t1)
        {
            t0 = items.Length > 0 ? items[0] : default(T);
            t1 = items.Length > 1 ? items[1] : default(T);
        }

        public static void Deconstruct<T>(this T[] items, out T t0, out T t1, out T t2)
        {
            t0 = items.Length > 0 ? items[0] : default(T);
            t1 = items.Length > 1 ? items[1] : default(T);
            t2 = items.Length > 2 ? items[2] : default(T);
        }

        public static void Deconstruct<T>(this T[] items, out T t0, out T t1, out T t2, out T t3)
        {
            t0 = items.Length > 0 ? items[0] : default(T);
            t1 = items.Length > 1 ? items[1] : default(T);
            t2 = items.Length > 2 ? items[2] : default(T);
            t3 = items.Length > 3 ? items[3] : default(T);
        }

        public static void Deconstruct<T>(this T[] items, out T t0, out T t1, out T t2, out T t3, out T[] rest)
        {
            t0 = items.Length > 0 ? items[0] : default(T);
            t1 = items.Length > 1 ? items[1] : default(T);
            t2 = items.Length > 2 ? items[2] : default(T);
            t3 = items.Length > 3 ? items[3] : default(T);
            rest = items.Skip(4).ToArray();
        }
    }
}
