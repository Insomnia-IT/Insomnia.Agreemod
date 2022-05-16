using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insomnia.Agreemod.Data.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Insomnia.Agreemod.Data.ViewModels.Output
{
    public class PeopleOutput
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Позывной
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// Должность
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Локации которым принадлежит человек
        /// </summary>
        public string[] Locations { get; set; }

        /// <summary>
        /// Направления которым принадлежит человек
        /// </summary>
        public string[] Directions { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Ссылка на аватар
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// Цвет бейджика
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))] 
        public BadgeColor BadgeColor { get; set; }

        /// <summary>
        /// Тип питания
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public FoodType FoodType { get; set; }
        
        /// <summary>
        /// Особенности питания
        /// </summary>
        public string NutritionFeatures { get; set; }

        /// <summary>
        /// Дата приезда на поле
        /// </summary>
        public DateTime? ArrivalDate { get; set; }

        /// <summary>
        /// Дата отъезда с поля
        /// </summary>
        public DateTime? DepartureDate { get; set; }
    }
}
