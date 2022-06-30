using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insomnia.Agreemod.Data.Dto;
using Insomnia.Agreemod.Data.Enums;
using Insomnia.Agreemod.Data.Generic;
using Insomnia.Agreemod.Data.ViewModels.Output;

namespace Insomnia.Agreemod.General.Expansions
{
    public static class PeopleExpansions
    {
        private static string[] WhoItProfessions = new[] { WhoIt.Lecturer, WhoIt.Musicant, WhoIt.Animator, WhoIt.Master };
        private static string[] FoodTypes = new[] { NamingFoodType.Free, NamingFoodType.Discont50 };
        private static string[] SystemLocations = new[] { NamingDirections.VetviDereva };
        private static string[] DictionaryForGenPassword = new string[]
        {
            "Ahegao",
            "Airtight",
            "Amateur",
            "Anal",
            "Analingus",
            "ASMR",
            "ATM",
            "Autofellatio",
            "Babysitter",
            "Ballbusting",
            "Bareback",
            "BBC",
            "BBW",
            "BD",
            "BDSM",
            "Big Dick",
            "Big Tits",
            "Bisexual Male",
            "Blowjob",
            "Bondage",
            "Boner",
            "Bottom",
            "Breast Bondage",
            "Breath play",
            "Bukkake",
            "bukkake phone sex large",
            "Caning",
            "Cartoon",
            "Casting",
            "Catheter",
            "CBT",
            "CEI",
            "Celebrity",
            "CFNM",
            "Chastity",
            "Chastity Belt",
            "CIM",
            "Cum in mouth",
            "Clamping",
            "Climax",
            "climax",
            "Cock Ring",
            "College",
            "Compilation",
            "Cougar",
            "Creampie",
            "Crossdresser (CD)",
            "Cuckold",
            "Cum Swap",
            "Cumshot",
            "Cunnilingus",
            "Daisy Chain",
            "Deepthroat",
            "Dogging",
            "Domme",
            "Double penetration",
            "DP",
            "Ebony",
            "Enema",
            "Escort",
            "Facefuck",
            "Facial",
            "Feet",
            "Female Orgasm",
            "Femdom",
            "Fetish",
            "Weird Fetishes",
            "FFM",
            "Fisting",
            "FK",
            "Flashlight",
            "Foot Worship",
            "Forced",
            "Gangbang",
            "Gay",
            "GILF",
            "Glory hole",
            "Golden shower",
            "Gonzo Porn",
            "Handjob",
            "Hatefuck",
            "Hentai",
            "Humping",
            "Interactive",
            "Interracial",
            "Jerk Off",
            "Jizz",
            "JOI",
            "Kinbaku",
            "Kinkster",
            "Lesbian",
            "Lezdom",
            "Looner looning",
            "Looner looning",
            "Lovense",
            "Masochism",
            "Massage",
            "Master",
            "Masturbation",
            "Mature",
            "MILF",
            "Mummification",
            "NSFW",
            "OFace",
            "OldYoung",
            "Orgy",
            "Parody",
            "PAWG",
            "Pegging",
            "PMV",
            "Pre Cum",
            "Prolapse",
            "Public",
            "Pump",
            "Pussy licking",
            "Queening or Face Sitting",
            "Quickie",
            "Reality",
            "Redhead",
            "Rimming",
            "Role Play",
            "Romantic",
            "Rough Sex",
            "Scat",
            "Scissoring",
            "Scrotum",
            "SFW",
            "Shaft",
            "Shemale",
            "Small Tits",
            "Solo female",
            "Sounding",
            "Spermicide",
            "Spinner",
            "Spit Roast",
            "Spooning",
            "Squirting",
            "Stepdad",
            "Stepmom",
            "Stepsister",
            "Strapon",
            "Striptease",
            "Sub submissive",
            "Sybian",
            "Taboo",
            "Teasing",
            "Teen",
            "Threesome",
            "Throatpie",
            "Titjob",
            "Toys",
            "Transsexual",
            "Transvestite",
            "Unicorn",
            "Vintage",
            "Virtual Reality",
            "Wank",
            "Webcam",
        };

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
                    if (people.VolunteerDirections?.Contains(NamingDirections.FirstAidPost) == true)
                        result = BadgeColor.Purple;
                    else
                        result = BadgeColor.Green;
                }
                else if (people.WhoIt == WhoIt.Medic)
                    result = BadgeColor.Purple;
                else if (WhoItProfessions.Contains(people.WhoIt))
                    result = BadgeColor.Orange;
                else if (people.OwnedbyLocation != null && people.OwnedbyLocation.Contains(NamingDirections.Laboratory))
                    result = BadgeColor.BlueLab;
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

        public static string GetName(this PeopleDto people)
        {
            if (!String.IsNullOrEmpty(people.Nickname))
                return people.Nickname.Trim();

            return people.Name.Trim();
        }

        public static string TranslateName(this PeopleDto people)
        {
            var name = people.GetName().ToLower();

            StringBuilder newName = new StringBuilder();

            for (var i = 0; i < name.Length; i++)
                newName.Append(name[i].TranslateChar());

            return newName.ToString();
        }

        public static List<Chat> GetChats(this PeopleDto people)
        {
            var chats = new List<Chat>();

            chats.AddRange(DefaultValues.DefaultChats);

            if (!people.LeaderLocations.IsNullOrEmpty())
            {
                chats.Add(DefaultValues.AdminChat);

                foreach(var d in people.LeaderLocations)
                {
                    chats.Add(new Chat(d, true));
                }
            }

            foreach(var d in people.VolunteerDirections.Where(x => !chats.Select(y => y.Naming).Contains(x)).ToList())
            {
                chats.Add(new Chat(d));
            }

            return chats;
        }

        public static string GenPassword(this PeopleDto people)
        {
            var newPassword = DictionaryForGenPassword[(new Random()).Next(0, DictionaryForGenPassword.Length - 1)].RemoveNotLetters() + (new Random()).Next(0, 9) + DictionaryForGenPassword[(new Random()).Next(0, DictionaryForGenPassword.Length - 1)].RemoveNotLetters();

            return newPassword;
        }

        public static string GetPosition(this PeopleDto people)
        {
            try
            {
                var result = people.WhoIt;

                if (!String.IsNullOrEmpty(people.Position))
                    result = people.Position;
                else if (!people.LeaderLocations.IsNullOrEmpty())
                    result = "Организатор";
                else if (people.IsVolunteer)
                    result = people.GetVolunteerDirections();
                else if (WhoItProfessions.Contains(people.WhoIt))
                    return result;
                else if (people.OwnedbyLocation != null && people.OwnedbyLocation.Length > 0)
                    result = String.Join(", ", people.OwnedbyLocation);

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static string GetVolunteerDirections(this PeopleDto people)
        {
            if (!people.IsVolunteer)
                return String.Empty;
            
            if(people.VolunteerDirections != null && people.VolunteerDirections.Length > 0)
                return String.Join(", ", people.VolunteerDirections);

            return String.Empty;
        }

        public static IEnumerable<PeopleDto> VolunteersFilter(this IEnumerable<PeopleDto> peoples)
        {
            return peoples.Where(x => x.IsVolunteer || !x.LeaderLocations.IsNullOrEmpty()).Where(x => !String.IsNullOrEmpty(x.Name));
        }

        public static IEnumerable<PeopleDto> PrticipantssFilter(this IEnumerable<PeopleDto> peoples)
        {
            return peoples;
        }

        public static IEnumerable<PeopleDto> UsersFilter(this IEnumerable<PeopleDto> peoples)
        {
            return peoples;
        }

        public static IEnumerable<PeopleDto> PeoplesFilter(this IEnumerable<PeopleDto> peoples)
        {
            return peoples.Where(x => !x.LeaderLocations.IsNullOrEmpty() || (x.ArrivalDate.HasValue && x.ArrivalDate.Value < new DateTime(2022,7,9)) || x.IsWeekendVolunteer);
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
