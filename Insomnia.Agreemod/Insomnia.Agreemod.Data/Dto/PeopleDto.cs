using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insomnia.Agreemod.Data.Enums;

namespace Insomnia.Agreemod.Data.Dto
{
    public class PeopleDto
    {
        /// <summary>
        /// Id строки для синхронизации
        /// </summary>
        public string Id { get; set; }

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
        /// Локации которыми руководит человек
        /// </summary>
        public string[] LeaderLocations { get; set; }

        /// <summary>
        /// Участник если из Ветвей Дерева принадлежит какой-либо локации.
        /// </summary>
        public string[] OwnedbyLocation { get; set; }

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
        /// Кто это
        /// </summary>
        public string WhoIt { get; set; }

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

        /// <summary>
        /// Направления, где волонтёр волонтёрит.
        /// </summary>
        public string[] VolunteerDirections { get; set; }

        /// <summary>
        /// Есть ли в поле "Волонтёр 2022" запись?
        /// </summary>
        public bool IsVolunteer => VolunteerDirections is not null && VolunteerDirections.Any();

        /// <summary>
        /// Тип питания из колонки тип питания. Первичная запись.
        /// </summary>
        public string FoodType { get; set; }
    }
}
