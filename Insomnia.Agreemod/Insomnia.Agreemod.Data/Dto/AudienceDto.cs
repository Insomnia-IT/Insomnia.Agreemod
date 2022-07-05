using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insomnia.Agreemod.Data.Dto
{
    public class AudienceDto
    {
        public int Number { get; set; }

        public List<TimetableElementDto> Elements {get; set;}
    }
}
