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
        private static string[] SystemLocations  = new[] {NamingDirections.VetviDereva};

        public static BadgeColor GetBadgeColor(this PeopleDto people)
        {
            try
            {
                var result = BadgeColor.Yellow;


                if (people is null)
                    return result;

                if (!people.LeaderLocations.IsNullOrEmpty())
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
                else if (people.Directions.NewUnion(people.VolunteerDirections)?.Contains(NamingDirections.VetviDereva) == true)
                    result = BadgeColor.Blue;

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static FoodType GetFoodType(this PeopleDto people)
        {
            try
            {
                var result = FoodType.Empty;

                if (!people.LeaderLocations.IsNullOrEmpty() || people.IsVolunteer)
                    result = FoodType.Free;
                else if (people.FoodType == NamingFoodType.Free)
                    result = FoodType.Free;
                else if (people.FoodType == NamingFoodType.Discont50)
                    result = FoodType.Discount50;

                return result;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static string GetPosition(this PeopleDto people)
        {
            try
            {
                if (people is null)
                    return String.Empty;

                var result = people.WhoIt;

                if (!String.IsNullOrEmpty(people.Position))
                    result = people.Position;
                else if (!people.LeaderLocations.IsNullOrEmpty())
                    result = "Организатор";
                else if (people.IsVolunteer)
                    result = "Волонтёр";

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static string[] RemoveSystemsLocations(this string[] locations)
        {
            try
            {
                var result = locations.Where(x => !SystemLocations.Contains(x)).ToArray();
                if (result.Length == 0)
                    return null;

                return result;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
    }
}
