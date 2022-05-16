using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insomnia.Agreemod.Data.Enums
{
    public enum BadgeColor
    {
        /// <summary>
        /// Красный. Цвет бейджа организаторов. 
        /// </summary>
        Red,
        /// <summary>
        /// Зелёный. Цвет бейджа волонтёра, который не принадлежит медпункту.
        /// </summary>
        Green,
        /// <summary>
        /// Синий. Цвет бейджа участника, который из одной из служб "Ветви дерева".
        /// </summary>
        Blue,
        /// <summary>
        /// Фиолетовый. Цвет бейджа волонтёра, который принадлежит медпункту.
        /// </summary>
        Purple,
        /// <summary>
        /// Желтный. Цвет бейджа для обычных участников.
        /// </summary>
        Yellow,
        /// <summary>
        /// Оранжевый. Цвет бейджа для участника который: аниматор, мастера, лектор или музыкант.
        /// </summary>
        Orange
    }
}
