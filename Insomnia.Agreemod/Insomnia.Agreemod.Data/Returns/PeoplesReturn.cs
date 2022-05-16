using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insomnia.Agreemod.Data.ViewModels.Output;

namespace Insomnia.Agreemod.Data.Returns
{
    public class PeoplesReturn : BaseReturn
    {
        public IList<PeopleOutput> Peoples { get; set; }
    }
}
