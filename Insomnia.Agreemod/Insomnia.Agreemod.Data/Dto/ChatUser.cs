using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insomnia.Agreemod.Data.Generic;

namespace Insomnia.Agreemod.Data.Dto
{
    public class ChatUser
    {
        public string Uuid { get; set; }

        public string Name { get; set; }

        public string Nickname { get; set; }

        public string Password { get; set; }

        public List<Chat> Chats { get; set; } = DefaultValues.DefaultChats;
    }
}
