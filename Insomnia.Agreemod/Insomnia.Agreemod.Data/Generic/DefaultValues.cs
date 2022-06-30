using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insomnia.Agreemod.Data.Dto;

namespace Insomnia.Agreemod.Data.Generic
{
    public static class DefaultValues
    {
        public const string FloodingChatNaming = "Флудилка";

        public static readonly Chat FloodingChat = new Chat(DefaultValues.FloodingChatNaming);

        public const string MainChatNaming = "Новостная лента";

        public static readonly Chat MainChat = new Chat(DefaultValues.MainChatNaming);

        public const string AdminChatNaming = "Организаторская";

        public static readonly Chat AdminChat = new Chat(DefaultValues.AdminChatNaming);

        public static readonly List<Chat> DefaultChats = new List<Chat>() { MainChat, FloodingChat };
    }
}