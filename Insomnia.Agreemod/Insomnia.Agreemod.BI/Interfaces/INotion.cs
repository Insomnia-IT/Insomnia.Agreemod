using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Insomnia.Agreemod.Data.Returns;
using Insomnia.Agreemod.Data.ViewModels.Input;

namespace Insomnia.Agreemod.BI.Interfaces
{
    public interface INotion
    {
        Task<PeoplesReturn> GetPeoples();

        Task<LocationsReturn> GetLocations();

        Task<TimetablesReturn> GetTimetablesForLocations();

        Task<Stream> ExportPeoples();

        Task<Stream> ExportLocations();

        Task<ChatUsersReturn> GetChatUsers();

        Task<MarkArrivalReturn> MarkArrivals(ArrivalUsers users);

        Task<MarkArrivalReturn> MarkArrival(ArrivalUser user);
    }
}
