using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insomnia.Agreemod.Data.Returns;

namespace Insomnia.Agreemod.BI.Interfaces
{
    public interface INotion
    {
        Task<PeoplesReturn> GetPeoples();

        Task<LocationsReturn> GetLocations();
    }
}
