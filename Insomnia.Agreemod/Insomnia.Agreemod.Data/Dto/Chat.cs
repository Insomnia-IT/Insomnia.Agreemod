using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insomnia.Agreemod.Data.Dto
{
    public class Chat
    {
        public string Naming { get; set; }

        public bool IsAdmin { get; set; } = false;

        public Chat(string naming, bool isAdmin)
        {
            Naming = naming;
            IsAdmin = isAdmin;
        }

        public Chat(string naming)
        {
            Naming = naming;
        }
    }
}
