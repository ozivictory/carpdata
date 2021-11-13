using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CARPDataGenerator.Models
{
    public static class SD
    {
        public static string GenerateTransactionCode(string extra = "", bool isPassword = false)
        {
            if (string.IsNullOrEmpty(extra) || string.IsNullOrWhiteSpace(extra))
            {
                extra = "UID";
            }

            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";

            if (isPassword)
            {
                numbers += "+=[]!*^£$";
            }

            string characters = numbers;

            characters += alphabets + small_alphabets + numbers;

            int length = 10;
            string id = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (id.IndexOf(character) != -1);
                id += character;
            }

            if (isPassword)
            {
                return "CARP*" + extra.ToLower() + id;
            }

            return "CARP-" + extra.ToUpper() + id + "-" + DateTime.Now.ToShortDateString();
        }


        public static string GenerateTransCode(string codeFromTrans)
        {
            Guid val = new Guid();
            return val.ToString().Replace(val.ToString().Substring(2, 7), codeFromTrans);
        }

        

        public static string GenerateName(int len, string description = null)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;


        }


        public static List<string> ListOfState = new List<string> { "Oyo", "Lagos", "Akwaibom", "Anambra", "Bauchi", "Bayelsa", "Lagos", "Borno", "Crossriver", "Delta", "Ebonyi", "Edo", "Ekiti", "Lagos", "Abuja", "Zamfra", "Niger", "Ogun", "Osun", "Ondo"};


        public static DateTime GetRandomDate(DateTime startDate, DateTime endDate)
        {
            var random = new Random();
            var range = Convert.ToInt32(endDate.Subtract(startDate).TotalDays);
            return startDate.AddDays(random.Next(range));
        }
    }
}
