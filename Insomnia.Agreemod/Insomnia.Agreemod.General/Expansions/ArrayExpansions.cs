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
                return false;

            return array.Any();
        }
    }
}
