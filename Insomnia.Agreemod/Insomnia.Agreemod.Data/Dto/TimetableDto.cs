using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insomnia.Agreemod.Data.Dto
{
    public class TimetableDto
    {
        public string Location { get; set; }

        public List<AudienceDto> Audiences { get; set; }

        public string Day { get; set; }
    }
}
