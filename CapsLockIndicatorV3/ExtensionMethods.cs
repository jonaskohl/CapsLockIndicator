using System;
using System.Collections.Generic;
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
    }
}
