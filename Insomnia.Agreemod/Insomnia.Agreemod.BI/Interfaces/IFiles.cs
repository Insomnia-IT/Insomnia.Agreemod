using Insomnia.Agreemod.Data.ViewModels.Output;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insomnia.Agreemod.Data.Dto;


namespace Insomnia.Agreemod.BI.Interfaces
{
    public interface IFiles
    {
        Task<Stream> Export(List<PeopleOutput> members);

        Task<Stream> ExportLocations(List<LocationDto> locations);

    }
}
