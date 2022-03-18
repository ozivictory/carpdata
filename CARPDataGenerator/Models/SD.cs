using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CARPDataGenerator.Models
{
    //public class PersonInfo
    //{
    //    public string gender { get; set; }
    //    public Name name { get; set; } = new Name();
    //    public Location location { get; set; } = new Location();
    //    public string email { get; set; }
    //    public Login login { get; set; } = new Login();
    //    public Dob dob { get; set; } = new Dob();
    //    public Registered registered { get; set; } = new Registered();
    //    public string phone { get; set; }
    //    public string cell { get; set; }
    //    public Id id { get; set; } = new Id();
    //    public Picture picture { get; set; } = new Picture();
    //    public string nat { get; set; }
    //}

    //public class Name
    //{
    //    public string title { get; set; }
    //    public string first { get; set; }
    //    public string last { get; set; }
    //}

    //public class Location
    //{
    //    public string street { get; set; }
    //    public string city { get; set; }
    //    public string state { get; set; }
    //    public string postcode { get; set; }
    //    public Coordinates coordinates { get; set; }
    //    public Timezone timezone { get; set; }
    //}

    //public class Coordinates
    //{
    //    public string latitude { get; set; }
    //    public string longitude { get; set; }
    //}

    //public class Timezone
    //{
    //    public string offset { get; set; }
    //    public string
    //
    //
    //
    //
    //    ption { get; set; }
    //}

    //public class Login
    //{
    //    public string uuid { get; set; }
    //    public string username { get; set; }
    //    public string password { get; set; }
    //    public string salt { get; set; }
    //    public string md5 { get; set; }
    //    public string sha1 { get; set; }
    //    public string sha256 { get; set; }
    //}

    //public class Dob
    //{
    //    public DateTime date { get; set; }
    //    public int age { get; set; }
    //}

    //public class Registered
    //{
    //    public DateTime date { get; set; }
    //    public int age { get; set; }
    //}

    //public class Id
    //{
    //    public string name { get; set; }
    //    public string value { get; set; }
    //}

    //public class Picture
    //{
    //    public string large { get; set; }
    //    public string medium { get; set; }
    //    public string thumbnail { get; set; }
    //}

    


    public static class SD
    {
        //public async static Task<PersonInfo> APINameGenerator()
        //{
        //    PersonInfo personArray = new PersonInfo();
        //    Random rand = new Random();

        //    personArray.gender = "M";

        //    personArray.name.title = "Dr." + rand.Next(0, 15);
        //    personArray.name.first = GenerateName(7);
        //    personArray.name.last = GenerateName(rand.Next(4, 8));

        //    personArray.location.city = "Lagos";

        //    personArray.location.postcode = "11001" + rand.Next(0, 15); ;
        //    personArray.location.state = "Lagos";
        //    personArray.location.street = "12, aynju street";

        //    personArray.email = personArray.name.first + rand.Next(0, 15) +"@yahoo.com";

        //    personArray.login.salt = "1902";

        //    personArray.dob.date = DateTime.Now;

        //    personArray.registered.date = DateTime.Now;

        //    personArray.phone = "0908738748373";
        //    personArray.id.value = "12";

        //    return personArray;
            
        //}

        //public async static Task<PersonInfo> UnusedAPINameGenerator()
        //{
        //    PersonInfo personArray = new PersonInfo();


        //    using (var client = new HttpClient())
        //    {
        //        // https://randomuser.me/
        //        //client.BaseAddress = new Uri("https://randomuser.me/api/?nat=gb,us,au,ca,no,nl,fi");
        //        //client.DefaultRequestHeaders.Accept.Clear();
        //        //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        //GET Method
        //        HttpResponseMessage response = await client.GetAsync("https://randomuser.me/api/?nat=gb,us,au,ca,no,nl,fi");
        //        if (response.IsSuccessStatusCode)
        //        {
        //            string jsonresult = await response.Content.ReadAsStringAsync();

        //            dynamic result = JsonConvert.DeserializeObject(jsonresult);


        //            foreach (var item in result.results)
        //            {
        //                personArray.gender = item.gender;

        //                personArray.name.title = item.name.title;
        //                personArray.name.first = item.name.first;
        //                personArray.name.last = item.name.last;

        //                personArray.location.city = item.location.city;

        //                personArray.location.postcode = item.location.postcode;
        //                personArray.location.state = item.location.state;
        //                personArray.location.street = item.location.street.number;
        //                personArray.location.street = personArray.location.street + item.location.street.name;

        //                personArray.email = item.email;

        //                personArray.login.salt = item.login.salt;

        //                personArray.dob.date = item.dob.date;

        //                personArray.registered.date = item.registered.date;

        //                personArray.phone = item.phone;
        //                personArray.id.value = item.id.value;

        //            }


        //        }
        //        else
        //        {
        //            Console.WriteLine("Internal server Error");
        //        }

        //        return personArray;
        //    }
        //}

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
            Guid val = Guid.NewGuid();
            return val.ToString().Replace(val.ToString().Substring(3, 7), codeFromTrans);
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


        public static List<string> ListOfState = new List<string> { "Oyo", "Lagos", "Akwaibom", "Anambra", "Bauchi", "Bayelsa", "Lagos", "Borno", "Crossriver", "Delta", "Ebonyi", "Edo", "Ekiti", "Lagos", "Abuja", "Zamfra", "Niger", "Ogun", "Osun", "Ondo" };
        public static List<string> ListOfInstitution = new List<string> { "Access Bank", "Citibank", "Ecobank Nigeria", "Fidelity Bank Nigeria", "First City Monument Bank"
            , "Heritage Bank Plc", "Jaiz Bank", "Keystone Bank Limited", "Providus Bank Plc", "Stanbic IBTC Bank Nigeria Limited", "Polaris Bank", "Union Bank of Nigeria", "United bank for afica", "Wema Bank", "Sterling Bank", "Suntrust Bank", };

        public static List<string> ListOfOccupation = new List<string> { "Banker", "Lawyer", "Finacial Analyst", "Engineer", "Civil Engineer"
            , "Surgeon", "Accountant", "Software Engineer", "Media Personnel", "Sailor", "Pharmacist", "Business Analyst", "Director", "Data Analyst", "Teacher", "Mechnical Engineer", };

        public static List<string> ListOfSourceOfWealth = new List<string> { "Profession", "Company", "Investment", "Employment", "Profession", "Company", "Investment", "Employment" };
        public static List<string> ListOfReason = new List<string> { "Profession", "Company", "Investment", "Payment", "Profession", "Company", "Investment", "Payment" };
        public static List<string> ListOfCurrencies = new List<string> { "USD", "EUR", "GBP", "EUR", "USD", "GBP", "EUR", "USD", "GBP", "USD", "EUR", "GBP" , "USD", "GBP", "EUR", "USD", "GBP", "EUR", "EUR"};
        public static List<string> ListOfCountries = new List<string> { "GB", "US", "MT", "GB", "MT", "GB", "MT", "US", "GB", "US", "MT", "GB", "GB", "US" , "GB", "US", "MT", "GB", "GB", "US", "MT" };
        public static List<string> ListOfLocalGov = new List<string> { "Abadam", "Abeokuta", "Surulere", "Giade", "Kirf", "Apapa", "Epe", "Eti-osa", "Badagry", "Bada" , "Bida", "Gombe", "Ikoyi", "Ikeja", "Alimosho" };


        public static List<string> ListOfEntities = new List<string> { "May Crater Nigeria", "Deloijad Ltd", "Sakro Ltd.", "Paraduci CO and Family", "Mikano Limited", "Ensure & CO.", "UAS Mavre LTD", "ECADO Construction limited", "City Grant Corporation",
            "Solution Limited", "Romans Enterprise", "Ottawa house",  "Seek hotels and suite",
            "Maxwell Roads", "Changes and Profit Enterprise" };

        public static List<String> LegalForm = new List<string> { "LLC", "ORG", "PLC", "REG", "ORG", "REG", "PLC", "LLC" };

        public static List<String> ListOfBusiness = new List<string> { "Information Technology", "Corporate", "Construction", "Finance", "Rentals", "Technology", "Health", "Entertainment", "Information Technology", "Corporate", "Construction", "Finance", "Rentals", "Technology", "Health", "Entertainment" };
        public static List<String> StreetType = new List<string> { "Way", "Road", "Plot", "Office", "Way", "Road", "Plot", "Office" };
        public static List<String> Gender = new List<string> { "M", "F", "M", "F", "M", "F", "M", "F" };
        public static List<String> Title = new List<string> { "Mr", "Mrs", "Dr", "Engr", "Prof", "Mr", "Mrs", "Dr", "Engr", "Prof" };
        public static List<String> AccountType = new List<string> { "Savings", "Transit Account", "Current Business", "Fixed Deposit", "Current Personal", "Trading Account" };
//D- 
//E- 
//P- 
//O- Export Proceed Dorm
//I- 
//C- Call Deposit
//L- 
//T- Internal Account
// B - Trust Account
// Y - Escrow account"}


        public static DateTime GetRandomDate(DateTime startDate, DateTime endDate)
        {
            var random = new Random();
            var range = Convert.ToInt32(endDate.Subtract(startDate).TotalDays);
            return startDate.AddDays(random.Next(range));
        }


        public static string GetRandomSentence(int wordCount)
        {
            string[] words = { "an", "automobile", "or", "motor", "account", "is", "a", "wheeled", "motor", "vehicle", "used", "for", "valid", "passengers", "which", "also", "carries", "its", "own", "engine", "or" };

            StringBuilder builder = new StringBuilder();

            Random random = new Random();

            for (int i = 0; i < wordCount; i++)
            {
                // Select a random word from the array
                builder.Append(words[random.Next(words.Length)]).Append(" ");
            }

            string sentence = builder.ToString().Trim() + ". ";

            // Set the first letter of the first word in the sentenece to uppercase
            sentence = char.ToUpper(sentence[0]) + sentence.Substring(1);

            builder = new StringBuilder();
            builder.Append(sentence);

            return builder.ToString();
        }


        // api name

    }


}
