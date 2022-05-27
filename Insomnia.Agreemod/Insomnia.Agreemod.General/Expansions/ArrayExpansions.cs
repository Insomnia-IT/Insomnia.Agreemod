using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insomnia.Agreemod.General.Expansions
{
    public static class ArrayExpansions
    {
        public static bool IsNullOrEmpty<T>(this T[] array)
        {
            if(array is null)
                return true;

            return array.Any();
        }

        public static T[] NewUnion<T>(this T[] array1, T[] array2)
        {
            if(array1 is null || array1.Length == 0)
                return array2;
            if (array2 is null || array2.Length == 0)
                return array1;

            return array1.Union(array2).ToArray();
        }
    }
}
