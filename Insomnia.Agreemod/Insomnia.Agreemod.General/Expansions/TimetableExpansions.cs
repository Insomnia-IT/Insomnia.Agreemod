using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insomnia.Agreemod.Data.Dto;

namespace Insomnia.Agreemod.General.Expansions
{
    public static class TimetableExpansions
    {
        public static IEnumerable<TimetableSourceDto> TimetablesFilter(this IEnumerable<TimetableSourceDto> timetables)
        {
            return timetables.Where(x => !String.IsNullOrEmpty(x.Day) && !String.IsNullOrEmpty(x.Location));
        }
    }
}
