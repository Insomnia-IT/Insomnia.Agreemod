using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insomnia.Agreemod.Data.Dto;
using Insomnia.Agreemod.Data.Enums;
using Insomnia.Agreemod.Data.Generic;

namespace Insomnia.Agreemod.General.Expansions
{
    public static class PeopleExpansions
    {
        private static string[] WhoItProfessions = new[] { WhoIt.Lecturer, WhoIt.Musicant, WhoIt.Animator, WhoIt.Master };
        private static string[] FoodTypes = new[] { NamingFoodType.Free, NamingFoodType.Discont50 };

        public static BadgeColor GetBadgeColor(this PeopleDto people)
        {
            var result = BadgeColor.Yellow;

            if (people.LeaderLocations.IsNullOrEmpty())
                result = BadgeColor.Red;
            else if (people.IsVolunteer)
            {
                if (people.VolunteerDirections?.Contains(NamingDirections.FirstAidPost) == true || people.WhoIt == WhoIt.Medic)
                    result = BadgeColor.Purple;
                else
                    result = BadgeColor.Green;
            }
            else if (WhoItProfessions.Contains(people.WhoIt))
                result = BadgeColor.Orange;
            else if (people.VolunteerDirections?.Contains(NamingDirections.VetviDereva) == true)
                result = BadgeColor.Blue;

            return result;
        }

        public static FoodType GetFoodType(this PeopleDto people)
        {
            var result = FoodType.Empty;

            if (people.LeaderLocations.IsNullOrEmpty() || people.IsVolunteer)
                result = FoodType.Free;
            else if (people.FoodType == NamingFoodType.Free)
                result = FoodType.Free;
            else if (people.FoodType == NamingFoodType.Discont50)
                result = FoodType.Discount50;

            return result;
        }

        public static string GetPosition(this PeopleDto people)
        {
            var result = people.WhoIt;

            if (!String.IsNullOrEmpty(people.Position))
                result = people.Position;
            else if (people.LeaderLocations.IsNullOrEmpty())
                result = "Организатор";
            else if (people.IsVolunteer)
                result = "Волонтёр";

            return result;
        }
    }
}
