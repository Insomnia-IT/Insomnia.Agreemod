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
        private static string[] OldUsers = new string[]
        {
            "970953bd",
"c59f9845",
"f5041fc6",
"e9c5aae2",
"dee5eae5",
"a3412db4",
"7341b5af",
"1e7bad52",
"3291f487",
"85784a0a",
"3099301a",
"53fec463",
"12652899",
"2b17f0b8",
"67a6539d",
"a7d4800e",
"f5f6b6cd",
"bc9964a4",
"ad8cb779",
"4a783702",
"2f992494",
"d9124c03",
"b084f31c",
"628ad845",
"1f6e1d53",
"17403864",
"975c0513",
"042cf7b8",
"528419ea",
"0c3eb29a",
"91c5a9f4",
"433392a8",
"6ce0df3f",
"96896ee4",
"ba0ef7be",
"3bc58a62",
"506225dc",
"776421be",
"d898a3e2",
"dcda1cdd",
"1386cefc",
"526463e3",
"bf336508",
"c989d905",
"ea6f4f3f",
"28bbce30",
"4e6c47ba",
"9582878e",
"9769f53a",
"d384b907",
"d44fadd8",
"53fd52f8",
"ba9aa568",
"d39d6ac7",
"e5989e2e",
"3d70563a",
"4e1251f4",
"556dc3c2",
"e4d70b4c",
"07c703a7",
"0c79baa9",
"1aeeb0a4",
"498fc4d4",
"4c7f1242",
"6cedcdda",
"6fc3606d",
"703bd154",
"86f961ea",
"9cb3f801",
"9e9fab32",
"cdf7926c",
"e3dded76",
"f2f8210f",
"f44546fe",
"23d9c19b",
"28905491",
"4b8dd07b",
"b73cd036",
"d026718a",
"1062a601",
"776d9367",
"3cbcc925",
"444273a9",
"aec5a8a8",
"8907a63b",
"6f10c692",
"46ab6d41",
"c13a9dfb",
"41b95ef5",
"1e89a221",
"570e3ccf",
"75eda601",
"33dcef29",
"56679462",
"d63976a2",
"25c62e59",
"8294a5ad",
"2da5d771",
"9e4150e3",
"1205f5aa",
"261b29e8",
"9b75f739",
"c8660d20",
"17f508dc",
"8971d729",
"f83c384b",
"3679ce1b",
"b97f796a",
"64385e88",
"d6098c09",
"691ea244",
"2e923d43",
"3f04fbc9",
"72db920c",
"8d05a9f0",
"5c95a3ad",
"60cb5c0c",
"9af680ef",
"be4d1bff",
"4446cccc",
"0169e455",
"4e3af87f",
"1c33d677",
"eb5ea687",
"a85b04bf",
"ce423828",
"dca496bd",
"6d7d1760",
"7d5b7584",
"970c3246",
"e77a82bc",
"83facbb5",
"47a2093a",
"2024213d",
"77c96132",
"31ee40a9",
"35528866",
"4ed68ce6",
"66e0db62",
"76ede220",
"c99414ce",
"343f3df4",
"2f2809fa",
"9ec2c67b",
"af685d82",
"8642086d",
"6ddaec7d",
"cbec107a",
"3b19305f",
"03b0c494",
"e57da6f8",
"9cf354fc",
"3b6ddc87",
"ef3e855f",
"5250af8e",
"5c0d8857",
"146f4d2d",
"04eb6325",
"1ab5b7a0",
"1a78cc4a",
"919bb1be",
"b9e17c1f",
"e558fb16",
"bac31288",
"17f33809",
"5ec6875e",
"8a35dd24",
"b6e944be",
"07d3b63b",
"250ced04",
"afbe429c",
"bdd9a29f",
"355ed58f",
"addce084",
"60007c2d",
"d0485217",
"4522989c",
"0915bbd8",
"577f4952",
"9e7d5b34",
"546e09d1",
"74dede62",
"f24a921d",
"f606b801",
"9c1ed990",
"1f01adb1",
"71f49347",
"a710b9d2",
"e8cb7ff6",
"7672a4af",
"e590e80b",
"f0cc38b6",
"a7f7d9b1",
"0ee45e35",
"650c7f27",
"891c304a",
"4dbbee47",
"e7d9778e",
"d2656d45",
"dddd270b",
"18c7c856",
"81b917e6",
"872071da",
"7a9df8d9",
"da3d9117",
"4199af85",
"39b5e81a",
"5ece7439",
"a7592b34",
"a4440d1b",
"c1d41396",
"206b610a",
"29fdf19c",
"f010cbf1",
"8001d151",
"ffc385d4",
"76bca1a1",
"bcc0d8a7",
"c1afcf5a",
"aa232f32",
"8d4007fd",
"cbbb30c5",
"0a205fc4",
"9c19f309",
"3c1ef520",
"66686868",
"909485aa",
"0e7dbff0",
"a80a68fe",
"b3e238db",
"f0aa0b3b",
"0b8ee586",
"d7e7e4c8",
"188f4a34",
"4383b805",
"10cb3891",
"3df88df9",
"90040f93",
"d02ecd15",
"e5eb5824",
"fbc21280",
"7b977ea3",
"3c58dc88",
"c31ba90b",
"1c6b715b",
"9b1b0996",
"8df403f2",
"79e29c37",
"282ad68b",
"f231eb0b",
"b6a6ca62",
"5b1b1e66",
"87b46680",
"33e173da",
"8dcdfcb5",
"604a7aa4",
"f204fd23",
"d5c4e89d",
"8c83b94d",
"1b6470ac",
"439c1875",
"45e20f3d",
"f0753ad8",
"80abe8bf",
"2d3dfc13",
"2e689461",
"aa323f07",
"922dfa09",
"bca9c014",
"3c5f8e1c",
"42953601",
"3bbb3bb0",
"5fa669a9",
"4cce309f",
"e0bc5c61",
"d5b956ae",
"a1060d0f",
"c906cb4c",
"1cdd9732",
"797982b2",
"20c146a5",
"628d0ef8",
"9ec9ba01",
"e14d019c",
"2f47ba46",
"8b232143",
"0809356e",
"50ea21f4",
"12eea50a",
"c3b07e8a",
"82505a80",
"e55cd442",
"bcf0cce4",
"2835426f",
"f389160b",
"f021cbe6",
"1e7158a0",
"091af797",
"c61e3cc1",
"7e8d89f5",
"3155135a",
"556daeba",
"d9ff20f9",
"70ad822f",
"9a6eadec",
"da0ba277",
"97ed1889",
"3e2ff334",
"d04f2228",
"3d67994b",
"dfe13223",
"38d63771",
"126dad3d",
"311d36e1",
"3c1616da",
"480bfd90",
"ac0045ef",
"a46909dd",
"10969fea",
"0aa37fc0",
"5a815983",
"76f71ae2",
"b6d190a2",
"276e8134",
"82d4fbeb",
"7f6db909",
"33edc405",
"07a2fc20",
"cf52074b",
"e317756e",
"97db8749",
"e40c6f68",
"9042b989",
"9c7ee619",
"b19198cc",
"7bac0f06",
"a81a3610",
"c8a917b3",
"7a66cf72",
"5602a324",
"f0b4ed44",
"b9513093",
"1d25d999",
"ac54bf93",
"71aa1045",
"9925b926",
"4ce1d883",
"68099fc8",
"d1f94b94",
"dc3e78b8",
"4b68f26d",
"5aa8ab53",
"4b59ad5a",
"53442fa5",
"b51680fd",
"9a93b6a5",
"accec07d",
"fc2473c8",
"e8a8d42e",
"403e9adf",
"33a8c87d",
"bde712d3",
"7b205579",
"7ef19c8d",
"e5e68ea4",
"28b364b3",
"cccba6f7",
"52aab0a5",
"fd21a90a",
"a5315cdd",
"01db4612",
"53ac582c",
"e6e380c5",
"cfefad2e",
"6ea2da6b",
"a5e3b770",
"9b0b78f1",
"f40e1861",
"7a38d255",
"ff8f4d41",
"34c6e1bf",
"17957913",
"f3b0e05d",
"9d2726b8",
"af9fe980",
"a9687940",
"212211c1",
"d0d95a8c",
"2bd30da0",
"569cb952",
"aff80ae1",
"026b403d",
"69dd7f7c",
"60fc7b11",
"6df3c131",
"232516a6",
"39ec03c0",
"56a721f8",
"95222647",
"78a18ac4",
"1ab159fc",
"a189cd8e",
"501222cc",
"1a9e7309",
"f8a89ce3",
"f38381f8",
"340553d6",
"93109ff9",
"e4b6aea2",
"6feff59b",
"640655c6",
"f973fd1e",
"23cec9c0",
"df773e53",
"314f2461",
"cb8cfe67",
"a46aee70",
"82a3543c",
"d35fff1a",
"9a75628e",
"5b53e43c",
"3fdf7cbc",
"17d64fb1",
"82d3d728",
"d553b4fa",
"19109cbf",
"613cc355",
"88517eaa",
"c5a34f84",
"bb064301",
"bfa7bacc",
"6375da0d",
"98bc165b",
"e085615d",
"83e0a1ad",
"db175fcb",
"3ed20e71",
"8ab8504e",
"4d68855b",
"1b9f2aed",
"09417b81",
"c92fdb11",
"1b845024",
"33b7044e",
"6aa255d3",
"879ec4ac",
"7cd09ef0",
"d4228717",
"5a7bbf88",
"abc93518",
"4b856213",
"7a0e051d",
"0ae91a49",
"254f319a",
"617b476d",
"d78d8d2e",
"385221cd",
"ede6de76",
"eba8230b",
"73bd21ce",
"9de84bf5",
"69ac9903",
"a2b15016",
"ecf2a2a3",
"1849b9ef",
"d5a30cf8",
"f8e0556e",
"c3b0bb50",
"a9d6a50e",
"82b08a13",
"dc9533b3",
"a8d5eb86",
"df537a15",
"15e72f64",
"240664bc",
"dd83478e",
"54da1ff8",
"7688953f",
"6310beb3",
"064df89e",
"e9f2c5ae",
"5a51bc7e",
"47e709cc",
"d37cc24b",
"fb336758",
"c92f1264",
"3715fdc7",
"ee313a13",
"1ab03f10",
"a84e217e",
"ed40496e",
"4e327584",
"a1ff8368",
"2a4b189e",
"2f59ca22",
"64a82127",
"09567c06",
"e3c1571a",
"4ffbc6f0",
"3068c054",
"c502ef9f",
"4d71ea7a",
"8f3e1fc8",
"eceecf79",
"4ce4e6f8",
"1a2d5b2f",
"78e79fb5",
"b294586d",
"34e70ca9",
"78203333",

        };

        public static BadgeColor GetBadgeColor(this PeopleDto people)
        {
            try
            {
                var result = BadgeColor.Yellow;

                if (people.Name == "Самороднов Ярослав")
                    Console.WriteLine("");

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
                else if (people.OwnedbyLocation != null && people.OwnedbyLocation.Contains(NamingDirections.LaboratoryL1))
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
            return peoples.Where(x => !OldUsers.Contains(x.Uuid.Split('-')[0])).Where(x => x.IsVolunteer || !x.LeaderLocations.IsNullOrEmpty()).Where(x => !String.IsNullOrEmpty(x.Name));
        }

        public static IEnumerable<PeopleDto> PrticipantssFilter(this IEnumerable<PeopleDto> peoples)
        {
            return peoples;//.Where(x => !OldUsers.Contains(x.Uuid.Split('-')[0]));
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
