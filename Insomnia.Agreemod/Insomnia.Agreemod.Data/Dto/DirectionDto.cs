using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insomnia.Agreemod.Data.Dto
{
    public class DirectionDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string SmallName { get; set; }

        public string GetName => String.IsNullOrEmpty(SmallName) ? Name : SmallName;
    }
}
