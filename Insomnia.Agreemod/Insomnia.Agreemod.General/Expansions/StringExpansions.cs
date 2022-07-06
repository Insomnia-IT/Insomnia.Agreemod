using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Insomnia.Agreemod.General.Expansions
{
    public static class StringExpansions
    {
        private static (char rus, string eng)[] TranslateLetters = new[]
        {
            ('а', "a"),
            ('б', "b"),
            ('в', "v"),
            ('г', "g"),
            ('д', "d"),
            ('е', "e"),
            ('ё', "yo"),
            ('ж', "j"),
            ('з', "z"),
            ('и', "i"),
            ('й', "yi"),
            ('к', "k"),
            ('л', "l"),
            ('м', "m"),
            ('н', "n"),
            ('о', "o"),
            ('п', "p"),
            ('р', "r"),
            ('с', "s"),
            ('т', "t"),
            ('у', "u"),
            ('ф', "f"),
            ('х', "h"),
            ('ц', "ts"),
            ('ч', "ch"),
            ('ш', "sh"),
            ('щ', "shch"),
            ('ъ', ""),
            ('ы', "ui"),
            ('ь', ""),
            ('э', "ye"),
            ('ю', "yu"),
            ('я', "ya"),
        };
        private static string[] NewCharForWhiteSpace = new string[]
        {
            ".",
            "_",
            ""
        };


        public static string AddOrderingChart(this string day)
            => day switch
            {
                "Четверг" => "1Четверг",
                "Пятница" => "2Пятница",
                "Суббота" => "3Суббота",
                "Воскресенье" => "4Воскресенье",
                "Понедельник" => "5Понедельник"
            };

        public static string RemoveOrderingChart(this string day)
                    => day switch
                    {
                        "1Четверг" => "Четверг",
                        "2Пятница" => "Пятница",
                        "3Суббота" => "Суббота",
                        "4Воскресенье" => "Воскресенье",
                        "5Понедельник" => "Понедельник"
                    };

        public static bool CanParseToInt(this string number)
        {
            try
            {
                int.Parse(number);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static bool CanParseToFloat(this string number)
        {
            try
            {
                float.Parse(number);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static string TranslateChar(this char c)
        {
            if (TranslateLetters.Any(b => b.rus == c))
                return TranslateLetters.FirstOrDefault(b => b.rus == c).eng;

            if (c == ' ')
            {
                var random = (new Random()).Next(0, NewCharForWhiteSpace.Length);
                return NewCharForWhiteSpace[random];
            }

            if (c == '_' || c == '.')
                return $"{c}";

            if(new char[] {'0','1','2','3','4','5','6','7','8','9'}.Contains(c))
                return $"{c}";

            return "";
        }

        public static string RemoveNotLetters(this string text)
        {
            return text.Replace(" ", "").Replace("(", "").Replace(")", "").Replace("/","").Replace("\\","");
        }

        //Смысла проверять как-то лучше никакого. 
        public static bool IsEmail(this string email) => email.CorrectRegex(@"/.+@.+\..+/i");

        public static bool IsPhone(this string phone) => phone.CorrectRegex(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$");

        public static bool CorrectRegex(this string text, string regex) => Regex.IsMatch(text, regex);

        public static bool AllElementsOfNumber(this string[] elements) =>
            elements.All(x => x.CanParseToFloat());

        public static string[] ToArray(this string elements) => elements.Split(',');
    }
}
