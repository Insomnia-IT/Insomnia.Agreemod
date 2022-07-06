using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insomnia.Agreemod.Data.Dto
{
    public class TimetableSourceDto
    {
        public string Day { get; set; }

        public string Naming { get; set; }

        public string Description { get; set; }

        public string SmallDescription { get; set; }

        public string DescriptionSpeaker { get; set; }

        public string Speaker { get; set; }

        public string TimeStart { get; set; }

        public string TimeEnd { get; set; }

        public string Location { get; set; }

        public string Price { get; set; }

        public string Type { get; set; }
    }
}
