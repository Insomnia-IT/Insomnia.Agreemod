using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insomnia.Agreemod.Data.Dto;

namespace Insomnia.Agreemod.Data.Returns
{
    public class LocationsReturn : BaseReturn
    {
        public List<LocationDto> Locations { get; set; }
    }
}