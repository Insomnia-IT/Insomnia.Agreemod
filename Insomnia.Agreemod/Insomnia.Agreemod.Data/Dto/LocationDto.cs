using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insomnia.Agreemod.Data.Dto
{
    public class LocationDto
    {
        /// <summary>
        /// Название локации
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Поле: Статус локации
        /// Тэги локации
        /// </summary>
        public string[] Tags { get; set; }

        /// <summary>
        /// Поле: Направление 2022
        /// Направления локации
        /// </summary>
        public string[] Directions { get; set; }

    }
}
