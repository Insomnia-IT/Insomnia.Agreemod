using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insomnia.Agreemod.Data.Dto;

namespace Insomnia.Agreemod.Data.Returns
{
    public class ChatUsersReturn : BaseReturn
    {
        public List<ChatUser> Users { get; set; }
    }
}
