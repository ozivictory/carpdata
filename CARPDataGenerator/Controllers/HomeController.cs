using CARPDataGenerator.Data;
using CARPDataGenerator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CARPDataGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {

            HomeViewModel homeVM = new HomeViewModel();

            return View(homeVM);
        }


        [HttpPost]
        public async Task<IActionResult> Index(HomeViewModel homeVM)
        {
            

            if (ModelState.IsValid)
            {
                for(int i = 0; i < homeVM.NoOfrecords; i++)
                {
                    CTR ctr = new CTR();
                    FTR ftr = new FTR();


                    Random rand = new Random();
                    // add report indicator
                    //ctr.ID = i;
                    // generate code
                    ctr.CODE_FROM_TRANS = homeVM.codefromtrans;
                    ctr.TRANSACTION_NUMBER = SD.GenerateTransCode(homeVM.codefromtrans).Replace("-", "").Replace("_", "");
                    ctr.REFERENCE_NUMBER = "MRef-" + rand.Next(100008000, 800000000).ToString() + rand.Next(10, 99).ToString();
                    ctr.TRANSACTION_DESCRIPTION = homeVM.codefromtrans.ToUpper() + ":" + ctr.TRANSACTION_NUMBER;

                    
                    
                    ctr.TRANSACTION_LOCATION = SD.ListOfState[rand.Next(0, 19)];
                    ctr.TRANSACTION_DATE = SD.GetRandomDate(homeVM.StartDate, homeVM.EndDate);

                    // teller

                    // authorized


                    // late_deposit

                    // date_posting

                    // value_date

                    // transmode_code - conduction type // has 6 records
                    ctr.TRANSACTION_MODE_DESC = _db.LookupConductionType.ToList().ElementAt(rand.Next(0, 5)).Description;
                    ctr.TRANSACTION_MODE_CODE = _db.LookupConductionType.ToList().ElementAt(rand.Next(0, 5)).Item;
                    ctr.TRANSACTION_MODE_COMMENT = SD.GenerateName(rand.Next(4, 9));
                    ctr.PURPOSE_OF_TRANSACTION = SD.ListOfReason.ElementAt(rand.Next(0, SD.ListOfReason.Count() - 1));
                    if (homeVM.fromentityaccount || homeVM.toentityaccount)
                    {
                        // entity above 10m 
                        ctr.AMOUNT_LOCAL = rand.Next(10000001, 50000000);
                    }
                    else
                    {

                        ctr.AMOUNT_LOCAL = rand.Next(5000001, 19900000);
                    }


                    // tfrom and tfrommyclient


                    // from

                    // fromfundscode // funds type
                    ctr.FROM_FUNDS_CODE = homeVM.FundsTypeCode;
                    ctr.FROM_FUNDS_COMMENT = SD.GenerateName(rand.Next(3, 9));

                    ctr.FROM_COUNTRY = "NG";
                    ctr.TELLER = "CHIA";
                    ctr.AUTHORIZED = "SYSTEM";
                    ctr.LATE_DEPOSIT = false;
                    ctr.DATE_POSTING = SD.GetRandomDate(homeVM.StartDate, homeVM.EndDate);
                    ctr.TRANS_CONDUCTOR = SD.GenerateName(rand.Next(4, 8));


                    string currencyCode = SD.ListOfCurrencies.ElementAt(rand.Next(0, SD.ListOfCurrencies.Count() - 1));

                    // add from foreign currency
                    if (homeVM.FromAddForeignCurrency)
                    {
                        ctr.FROM_COUNTRY = SD.ListOfCountries.ElementAt(rand.Next(0, SD.ListOfCountries.Count() - 1));
                        ctr.FROM_PERSONAL_ACCOUNT_TYPE = "DOMICILLIARY ACCOUNT";
                        if (ctr.FROM_COUNTRY.Equals("US"))
                        {
                            currencyCode = "USD";
                        }else if (ctr.FROM_COUNTRY.Equals("GB"))
                        {
                            currencyCode = "GBP";
                        }else if (ctr.FROM_COUNTRY.Equals("MT"))
                        {
                            currencyCode = "EUR";
                        }

                        ctr.FROM_FOREIGN_CURRENCY_CODE = currencyCode; ;
                        ctr.FROM_FOREIGN_EXCHANGE_RATE = rand.Next(460, 500);
                        ctr.FROM_FOREIGN_AMOUNT = ctr.AMOUNT_LOCAL / ctr.FROM_FOREIGN_EXCHANGE_RATE;
                    }


                    if (homeVM.from.Equals("fromaccount"))
                    {
                        ctr.FROM_INSTITUTION_NAME = SD.ListOfInstitution.ElementAt(rand.Next(0, SD.ListOfInstitution.Count()-1));
                        ctr.FROM_INSTITUTION_CODE = ctr.FROM_INSTITUTION_NAME.Substring(0, 3) + rand.Next(150, 200);
                        ctr.FROM_INSTITUTION_SWIFT = ctr.FROM_INSTITUTION_NAME.Substring(0, 3) + rand.Next(1500, 2000);
                        ctr.FROM_INSTITUTION_BRANCH = ctr.FROM_INSTITUTION_CODE + ctr.TRANSACTION_LOCATION;
                        ctr.FROM_INSTITUTION_BRANCH_CODE = ctr.FROM_INSTITUTION_BRANCH;

                        ctr.FROM_ACCOUNT = rand.Next(1000000000, 2076543210).ToString();
                        ctr.FROM_ACCOUNT_IBAN = "IB" + ctr.FROM_ACCOUNT;
                        ctr.FROM_PERSONAL_ACCOUNT_TYPE = _db.LookupAccountType.ToList().ElementAt(rand.Next(0, 3)).Item; 
                        ctr.FROM_PERSONAL_ACCOUNT_DESC = _db.LookupAccountType.ToList().ElementAt(rand.Next(0, 3)).Description;
                        ctr.FROM_ACCOUNT_COMMENTS = SD.GenerateName(rand.Next(4, 10));
                        ctr.FROM_PERSON_GENDER = SD.Gender[rand.Next(0, 4)];
                        ctr.FROM_PERSON_TITLE = SD.Title[rand.Next(0, 4)];

                        ctr.STATUS_CODE = _db.LookupAccountStatusType.ToList().ElementAt(rand.Next(0, 1)).Item;
                        ctr.STATUS_DESC = _db.LookupAccountStatusType.ToList().ElementAt(rand.Next(0, 1)).Description;


                        //from account name

                        String firstName = SD.GenerateName(rand.Next(4, 8));
                        String lastName = SD.GenerateName(rand.Next(3, 8));
                        DateTime startRange = Convert.ToDateTime(rand.Next(1, 10) + "/" + rand.Next(1, 26) + "/" + rand.Next(1977, 1990) + " " + rand.Next(10, 20) + ":10:01");
                        DateTime endRange = Convert.ToDateTime(rand.Next(1, 10) + "/" + rand.Next(1, 26) + "/" + rand.Next(1997, 2009) + " " + rand.Next(10, 20) + ":10:01");


                        ctr.FROM_PERSON_FIRST_NAME = firstName;
                        ctr.FROM_PERSON_MIDDLE_NAME = lastName;
                        ctr.FROM_PERSON_MIDDLE_NAME = SD.GenerateName(rand.Next(2, 7));
                        ctr.FROM_PERSON_BIRTHDATE = SD.GetRandomDate(startRange, endRange); 
                        ctr.FROM_PERSON_BIRTH_PLACE = SD.ListOfState[rand.Next(0, 9)];
                        ctr.FROM_PERSON_MOTHERS_NAME = SD.GenerateName(rand.Next(4, 7));

                        ctr.FROM_PERSON_SSN = "SSN" + rand.Next(2000000, 8000000).ToString() + rand.Next(10, 99).ToString();
                        ctr.FROM_PERSON_PASSPORT_NUMBER = "NG" + rand.Next(10000000, 80000000).ToString() + rand.Next(10, 99).ToString();
                        ctr.FROM_PERSON_PASSPORT_COUNTRY = "NG";
                        ctr.FROM_PERSON_ID_NUMBER = "N" + rand.Next(1000000, 8000000).ToString() + rand.Next(10, 99).ToString();
                        ctr.FROM_PERSON_TPH_CONTACT_TYPE = "PRIVATE";
                        ctr.FROM_PERSON_EMPLOYER_TPH_COMMUNICATION_TYPE = "Mobile Phone";
                        ctr.FROM_PERSON_COUNTRY_PREFIX = "+234";
                        ctr.FROM_PERSON_TPH_EXTENSION = "";

                        ctr.FROM_PERSON_NUMBER = rand.Next(7000, 9000) + "" + rand.Next(40000, 90000);
                        ctr.FROM_PERSON_ADDRESS_TYPE = "Private";
                        ctr.FROM_PERSON_CITY = SD.ListOfState[rand.Next(0, 9)];
                        ctr.FROM_PERSON_ADDRESS = rand.Next(0, 500) + "- " + SD.GenerateName(rand.Next(3, 9)) + " " + SD.StreetType.ElementAt(rand.Next(0, SD.StreetType.Count() - 1)) + " - " + ctr.FROM_PERSON_CITY + "- Nig";
                        ctr.FROM_PERSON_TOWN = SD.ListOfLocalGov[rand.Next(0, 9)];
                        ctr.FROM_PERSON_COUNTRY_CODE = "NG";
                        ctr.FROM_PERSON_STATE = SD.ListOfState[rand.Next(0, 9)];
                        ctr.FROM_PERSON_NATIONALITY1 = "NIG";
                        ctr.FROM_PERSON_NATIONALITY2 = "NIG";
                        ctr.FROM_PERSON_NATIONALITY3 = "";
                        ctr.FROM_PERSON_RESIDENCE = "Home";

                        ctr.FROM_PERSON_EMAIL1 = firstName + ctr.FROM_PERSON_MIDDLE_NAME + "@email.com";
                        ctr.FROM_PERSON_EMAIL2 = firstName + ctr.FROM_PERSON_MIDDLE_NAME + "@email.com";
                        ctr.FROM_PERSON_EMAIL3 = lastName + ctr.FROM_PERSON_MIDDLE_NAME + "@email.com";
                        ctr.FROM_PERSON_OCCUPATION = SD.ListOfOccupation[rand.Next(0, 5)];
                        ctr.FROM_PERSON_SOURCE_OF_WEALTH = SD.ListOfSourceOfWealth[rand.Next(0, 6)];


                        //String firstName = "PAUL";

                        //String lastName = "OLOWU";

                        ctr.FROM_ACCOUNT_NAME = firstName + " " + lastName;

                        if (homeVM.fromentityaccount)
                        {
                            ctr.FROM_ENTITY_NAME = SD.ListOfInstitution.ElementAt(rand.Next(0, SD.ListOfInstitution.Count()-1));
                            ctr.FROM_ENTITY_COMMERCIAL_NAME = ctr.FROM_ENTITY_NAME;
                            ctr.FROM_PERSONAL_ACCOUNT_TYPE = _db.LookupAccountType.ToList().ElementAt(rand.Next(0, 3)).Item;
                            ctr.FROM_PERSONAL_ACCOUNT_DESC = _db.LookupAccountType.ToList().ElementAt(rand.Next(0, 3)).Description;




                            //DateTime startRange = Convert.ToDateTime(rand.Next(1, 10) + "/" + rand.Next(1, 26) + "/" + rand.Next(1977, 1990) + " " + rand.Next(10, 20) + ":10:01");
                            // DateTime endRange = Convert.ToDateTime(rand.Next(1, 10) + "/" + rand.Next(1, 26) + "/" + rand.Next(1997, 2009) + " " + rand.Next(10, 20) + ":10:01");

                            ctr.FROM_ENTITY_INCORPORATION_DATE = SD.GetRandomDate(startRange, endRange);ctr.FROM_ENTITY_NAME = SD.ListOfEntities.ElementAt(rand.Next(0, SD.ListOfEntities.Count() - 1));
                            ctr.FROM_ENTITY_INCORPORATION_LEGAL_FORM = SD.LegalForm.ElementAt(rand.Next(0, SD.LegalForm.Count() - 1));
                            ctr.FROM_ENTITY_INCORPORATION_NUMBER = ctr.FROM_ENTITY_NAME.Replace(" ", "").Substring(0, 4) + ctr.TRANSACTION_NUMBER.Substring(5, 3);
                            ctr.FROM_ENTITY_BUSINESS = SD.ListOfBusiness.ElementAt(rand.Next(0, SD.ListOfBusiness.Count() - 1));
                            ctr.FROM_ENTITY_INCORPORATION_COUNTRY_CODE = "NG";
                            ctr.FROM_ENTITY_TPH_CONTACT_TYPE = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 3)).Description;
                            ctr.FROM_ENTITY_TPH_COMMUNICATION_TYPE = _db.LookupCommunicationType.ToList().ElementAt(rand.Next(0, 6)).Description;
                            ctr.FROM_PERSON_COUNTRY_PREFIX = "+234";
                            ctr.FROM_ENTITY_NUMBER = rand.Next(187650, 987650) + "" + rand.Next(187650, 987650);
                            ctr.FROM_ENTITY_ADDRESS_TYPE = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 3)).Item;
                            ctr.FROM_ENTITY_ADDRESS_DESC = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 3)).Description;
                            string city = SD.ListOfState.ElementAt(rand.Next(0, SD.ListOfState.Count() - 1));
                            ctr.FROM_ENTITY_ADDRESS = rand.Next(0, 500) + "- " + SD.GenerateName(rand.Next(4, 9)) + " " + SD.StreetType.ElementAt(rand.Next(0, SD.StreetType.Count() - 1)) + " - " + city + "- Nigeria";
                            ctr.FROM_ENTITY_CITY = city;
                            ctr.FROM_ENTITY_COUNTRY_CODE = ctr.FROM_COUNTRY;
                            ctr.FROM_ENTITY_STATE = city;
                            ctr.FROM_ENTITY_EMAIL = ctr.FROM_ENTITY_NAME + "@email.com";
                            ctr.FROM_ENTITY_URL = ctr.FROM_ENTITY_COMMERCIAL_NAME + ".com";
                            ctr.FROM_ENTITY_BUSINESS_CLOSED = false;


                            ctr.FROM_ENTITY_INCORPORATION_STATE = city;
                            ctr.FROM_ENTITY_TAX_NUMBER = "TIN" + rand.Next(1000000, 9000000);
                            ctr.FROM_ENTITY_TAX_REG_NUMBER = "REG" + rand.Next(10009000, 89000000);
                            ctr.FROM_ENTITY_INCORPORATION_COUNTRY_CODE = "NG";
                            ctr.FROM_ENTITY_COMMENTS = SD.GenerateName(rand.Next(2, 7));





                            //DateTime startRange = Convert.ToDateTime(rand.Next(1, 10) + "/" + rand.Next(1, 26) + "/" + rand.Next(1977, 1990) + " " + rand.Next(10, 20) + ":10:01");
                            // DateTime endRange = Convert.ToDateTime(rand.Next(1, 10) + "/" + rand.Next(1, 26) + "/" + rand.Next(1997, 2009) + " " + rand.Next(10, 20) + ":10:01");

                            ctr.FROM_ENTITY_INCORPORATION_DATE = SD.GetRandomDate(startRange, endRange);
                        }

                    }
                    else if (homeVM.from.Equals("frommyclientaccount"))
                    {
                        // t-account-my-client
                        ctr.FROM_INSTITUTION_NAME = SD.ListOfInstitution.ElementAt(rand.Next(0, SD.ListOfInstitution.Count() - 1));

                        ctr.FROM_INSTITUTION_CODE = ctr.FROM_INSTITUTION_NAME.Substring(0, 3) + rand.Next(150, 200);

                        ctr.FROM_INSTITUTION_BRANCH = rand.Next(150, 200) + ctr.FROM_INSTITUTION_NAME.Substring(0, 3) + rand.Next(1, 20);

                        ctr.FROM_ACCOUNT = rand.Next(1000000000, 2076543210).ToString();
                        ctr.FROM_PERSONAL_ACCOUNT_TYPE = _db.LookupAccountType.ToList().ElementAt(rand.Next(0, 3)).Item;
                        ctr.FROM_PERSONAL_ACCOUNT_DESC = _db.LookupAccountType.ToList().ElementAt(rand.Next(0, 3)).Description;

                        ctr.FROM_ACCOUNT_COMMENTS = SD.GenerateName(rand.Next(4, 10));
                        ctr.FROM_CURRENCY_CODE = "NGN";

                        ctr.STATUS_CODE = _db.LookupAccountStatusType.ToList().ElementAt(rand.Next(0, 1)).Item;
                        ctr.STATUS_DESC = _db.LookupAccountStatusType.ToList().ElementAt(rand.Next(0, 1)).Description;


                        // from account name
                        //String firstName = "PAUL";

                        //String lastName = "OLOWU";

                        string firstName = SD.GenerateName(rand.Next(3, 8));
                        string lastName = SD.GenerateName(rand.Next(4, 9));

                        ctr.FROM_ACCOUNT_NAME = lastName + " " + firstName;
                        ctr.FROM_ACCOUNT_IBAN = "IB" + ctr.FROM_ACCOUNT;
                        ctr.FROM_ACCOUNT_COMMENTS = SD.GenerateName(rand.Next(4, 10));
                        ctr.FROM_PERSON_GENDER = SD.Gender[rand.Next(0, 4)];
                        ctr.FROM_PERSON_TITLE = SD.Title[rand.Next(0, 4)];
                        ctr.FROM_CLIENT_NUMBER = rand.Next(100000000, 900000000).ToString() + rand.Next(10, 99).ToString(); // 11 digits number only
                                                                                                                            //ctr.FROM_PERSONAL_ACCOUNT_TYPE = _db.LookupAccountType.ToList().ElementAt(rand.Next(0, 3)).Item;
                        DateTime startRange = Convert.ToDateTime(rand.Next(1, 10) + "/" + rand.Next(1, 26) + "/" + rand.Next(1977, 1990) + " " + rand.Next(10, 20) + ":10:01");
                        DateTime endRange = Convert.ToDateTime(rand.Next(1, 10) + "/" + rand.Next(1, 26) + "/" + rand.Next(1997, 2009) + " " + rand.Next(10, 20) + ":10:01");


                        ctr.FROM_PERSON_FIRST_NAME = firstName;
                        ctr.FROM_PERSON_MIDDLE_NAME = lastName;
                        ctr.FROM_PERSON_MIDDLE_NAME = SD.GenerateName(rand.Next(2, 7));
                        ctr.FROM_PERSON_BIRTHDATE = SD.GetRandomDate(startRange, endRange);
                        ctr.FROM_PERSON_BIRTH_PLACE = SD.ListOfState[rand.Next(0, 9)];
                        ctr.FROM_PERSON_MOTHERS_NAME = SD.GenerateName(rand.Next(4, 7));
                        ctr.FROM_PERSON_SSN = "SSN" + rand.Next(2000000, 8000000).ToString() + rand.Next(10, 99).ToString();
                        ctr.FROM_PERSON_PASSPORT_NUMBER = "NG" + rand.Next(10000000, 80000000).ToString() + rand.Next(10, 99).ToString();
                        ctr.FROM_PERSON_PASSPORT_COUNTRY = "NG";
                        ctr.FROM_PERSON_ID_NUMBER = "N" + rand.Next(1000000, 8000000).ToString() + rand.Next(10, 99).ToString();
                        ctr.FROM_PERSON_TPH_CONTACT_TYPE = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 4)).Description;
                        ctr.FROM_PERSON_EMPLOYER_TPH_COMMUNICATION_TYPE = _db.LookupCommunicationType.ToList().ElementAt(rand.Next(0, 4)).Description;
                        ctr.FROM_PERSON_COUNTRY_PREFIX = "+234";
                        
                        ctr.FROM_PERSON_NUMBER = rand.Next(7000, 9000) + "" + rand.Next(40000, 90000);
                        ctr.FROM_ENTITY_ADDRESS_TYPE = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 3)).Item;
                        ctr.FROM_ENTITY_ADDRESS_DESC = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 3)).Description;

                        ctr.FROM_PERSON_CITY = SD.ListOfState[rand.Next(0, 9)];
                        ctr.FROM_PERSON_ADDRESS= rand.Next(0, 500) + "- " + SD.GenerateName(rand.Next(3, 9)) + " " + SD.StreetType.ElementAt(rand.Next(0, SD.StreetType.Count() - 1)) + " - " + ctr.FROM_PERSON_CITY + "- Nig";
                        ctr.FROM_PERSON_TOWN = SD.ListOfLocalGov[rand.Next(0, 9)];
                        
                        ctr.FROM_PERSON_COUNTRY_CODE = "NG";
                        ctr.FROM_PERSON_STATE= SD.ListOfState[rand.Next(0, 9)];
                        ctr.FROM_PERSON_NATIONALITY1 = "NIG";
                        ctr.FROM_PERSON_NATIONALITY2 = "NIG";
                        ctr.FROM_PERSON_RESIDENCE = "Home";
                        
                        ctr.FROM_PERSON_EMAIL1 = firstName + ctr.FROM_PERSON_MIDDLE_NAME + "@email.com";
                        ctr.FROM_PERSON_EMAIL2 = firstName + ctr.FROM_PERSON_MIDDLE_NAME + "@email.com";
                        ctr.FROM_PERSON_EMAIL3 = lastName + ctr.FROM_PERSON_MIDDLE_NAME + "@email.com";
                        ctr.FROM_PERSON_OCCUPATION = SD.ListOfOccupation[rand.Next(0, 5)];
                        ctr.FROM_PERSON_EMPLOYER_NAME = SD.GenerateName(rand.Next(2, 10));
                        ctr.FROM_PERSON_EMPLOYER_ADDRESS_TYPE = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 3)).Description;
                        ctr.FROM_PERSON_EMPLOYER_ADDRESS = rand.Next(0, 200) + "- " + SD.GenerateName(rand.Next(2, 6)) + " " + SD.StreetType.ElementAt(rand.Next(0, SD.StreetType.Count() - 1)) + " - " + ctr.FROM_PERSON_CITY + "- Nigeria";
                        ctr.FROM_PERSON_EMPLOYER_CITY = ctr.FROM_PERSON_CITY;
                        ctr.FROM_PERSON_EMPLOYER_COUNTRY_CODE = "NG";
                        ctr.FROM_PERSON_EMPLOYER_ADDRESS_COMMENTS = SD.GenerateName(rand.Next(6, 9));
                        ctr.FROM_PERSON_EMPLOYER_STATE = ctr.FROM_PERSON_CITY;
                        ctr.FROM_PERSON_EMPLOYER_TPH_COMMUNICATION_TYPE = _db.LookupCommunicationType.ToList().ElementAt(rand.Next(0, 4)).Description;
                        ctr.FROM_PERSON_EMPLOYER_TPH_CONTACT_TYPE = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 4)).Description;
                        ctr.FROM_PERSON_EMPLOYER_NUMBER = rand.Next(700, 900) + "" + rand.Next(10000, 90000);
                        ctr.FROM_PERSON_EMPLOYER_COUNTRY_PREFIX = "+234";
                        ctr.DECEASED = false;
                        
                        
                        ctr.FROM_PERSON_TAX_NUMBER= "TIN" + rand.Next(1000099, 8500000);
                        ctr.FROM_PERSON_TAX_REG_NUMBER = ctr.FROM_PERSON_TAX_NUMBER;
                        ctr.FROM_PERSON_SOURCE_OF_WEALTH = SD.ListOfSourceOfWealth[rand.Next(0, 6)];













                        ctr.FROM_CUSTOMER_TYPE = "INDIVIDUAL";
                        ftr.RegistrationNumber = ctr.FROM_INSTITUTION_NAME.Replace(" ", "").Substring(0, 3) + "-" + Guid.NewGuid().ToString().Substring(0, 6);

                        string usercity = SD.ListOfState.ElementAt(rand.Next(0, SD.ListOfState.Count() - 1));
                        ftr.SecondLineAddress = rand.Next(0, 500) + "- " + SD.GenerateName(rand.Next(4, 9)) + " " + SD.StreetType.ElementAt(rand.Next(0, SD.StreetType.Count() - 1)) + " - " + usercity;
                        ftr.LocalGovernment = SD.ListOfLocalGov.ElementAt(rand.Next(0, SD.ListOfLocalGov.Count() - 1));
                        ftr.LinkedAccounts = rand.Next(23456, 65435) + "" + rand.Next(23456, 65435);
                        ftr.PurposeOfTransaction = SD.ListOfReason.ElementAt(rand.Next(0, SD.ListOfReason.Count() - 1));
                        ftr.NameOfSender = ctr.FROM_PERSON_FIRST_NAME + ctr.FROM_PERSON_LAST_NAME;
                        ftr.FirstName = ctr.FROM_PERSON_FIRST_NAME;
                        ftr.MiddleName = ctr.FROM_PERSON_MIDDLE_NAME;
                        ftr.Nationality = ctr.FROM_PERSON_NATIONALITY1;
                        ftr.DateOfBirth = ctr.FROM_PERSON_BIRTHDATE;
                        ftr.TypeOfIdentification = _db.LookupIdentifierType.ToList().ElementAt(rand.Next(0, 6)).Description;
                        ftr.IdentificationNo = "ID" + SD.GenerateName(3) + rand.Next(2009845, 3000000);
                        ftr.DateOfIssue = SD.GetRandomDate(startRange, endRange);
                        ftr.PlaceOfIssue = ftr.LocalGovernment;
                        ftr.IssuingAuthority = "Govt";
                        ftr.State = SD.ListOfState[rand.Next(1, 9)];
                        ftr.Email = ftr.SurnameOrNameOfOrganisation + "@mail.com";
                        ftr.SourceOfFunds = SD.ListOfSourceOfWealth[rand.Next(1, 4)];


                        

                        usercity = SD.ListOfState.ElementAt(rand.Next(0, SD.ListOfState.Count() - 1));
                        ftr.AddressOfBeneficiary = rand.Next(0, 500) + "- " + SD.GenerateName(rand.Next(4, 9)) + " " + SD.StreetType.ElementAt(rand.Next(0, SD.StreetType.Count() - 1)) + " - " + usercity + "- Nigeria";
                        usercity = SD.ListOfState.ElementAt(rand.Next(0, SD.ListOfState.Count() - 1));
                        ftr.AddressOfSender = rand.Next(0, 500) + "- " + SD.GenerateName(rand.Next(4, 9)) + " " + SD.StreetType.ElementAt(rand.Next(0, SD.StreetType.Count() - 1)) + " - " + usercity + "- Nigeria";

                        ctr.FROM_CMO = "MERIT BANK  ";
                        ftr.TransactionNumber = ctr.TRANSACTION_NUMBER;
                        ftr.ReferenceNumber = ctr.REFERENCE_NUMBER;
                        ftr.ForSourceTransaction = true;
                        ftr.ForDestinationTransaction = true;

                        if (homeVM.fromentityaccount)
                        {

                            ctr.FROM_CUSTOMER_TYPE = "INSTIITUTIONAL";
                            ctr.FROM_PERSONAL_ACCOUNT_TYPE = _db.LookupAccountType.ToList().ElementAt(rand.Next(0, 3)).Item;
                            ctr.FROM_PERSONAL_ACCOUNT_DESC = _db.LookupAccountType.ToList().ElementAt(rand.Next(0, 3)).Description;

                            ctr.FROM_ENTITY_NAME = SD.ListOfEntities.ElementAt(rand.Next(0, SD.ListOfEntities.Count() - 1));
                            ctr.FROM_ENTITY_INCORPORATION_LEGAL_FORM = SD.LegalForm.ElementAt(rand.Next(0, SD.LegalForm.Count() - 1));
                            ctr.FROM_ENTITY_INCORPORATION_NUMBER = ctr.FROM_ENTITY_NAME.Replace(" ", "").Substring(0, 4) + ctr.TRANSACTION_NUMBER.Substring(5, 3);
                            ctr.FROM_ENTITY_BUSINESS = SD.ListOfBusiness.ElementAt(rand.Next(0, SD.ListOfBusiness.Count() - 1));
                            ctr.FROM_ENTITY_INCORPORATION_COUNTRY_CODE = "NG";
                            ctr.FROM_ENTITY_TPH_CONTACT_TYPE = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 3)).Description;
                            ctr.FROM_ENTITY_TPH_COMMUNICATION_TYPE = _db.LookupCommunicationType.ToList().ElementAt(rand.Next(0, 6)).Description;
                            ctr.FROM_PERSON_COUNTRY_PREFIX = "+234";
                            ctr.FROM_ENTITY_NUMBER = rand.Next(187650, 987650) + "" + rand.Next(187650, 987650);
                            ctr.FROM_ENTITY_ADDRESS_TYPE = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 3)).Item;
                            ctr.FROM_ENTITY_ADDRESS_DESC = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 3)).Description;

                            string city = SD.ListOfState.ElementAt(rand.Next(0, SD.ListOfState.Count() - 1));
                            ctr.FROM_ENTITY_ADDRESS = rand.Next(0, 500) + "- " + SD.GenerateName(rand.Next(4, 9)) + " " + SD.StreetType.ElementAt(rand.Next(0, SD.StreetType.Count() - 1)) + " - " + city + "- Nigeria";
                            ctr.FROM_ENTITY_CITY = city;
                            ctr.FROM_ENTITY_COUNTRY_CODE = ctr.FROM_COUNTRY;
                            ctr.FROM_ENTITY_STATE = city;
                            ctr.FROM_ENTITY_EMAIL = ctr.FROM_ENTITY_NAME + "@email.com";
                            ctr.FROM_ENTITY_INCORPORATION_STATE = city;
                            ctr.FROM_ENTITY_TAX_NUMBER = "TIN" + rand.Next(1000000, 9000000);
                            ctr.FROM_ENTITY_TAX_REG_NUMBER = "REG" + rand.Next(10009000, 89000000);
                            ctr.FROM_ENTITY_INCORPORATION_COUNTRY_CODE = "NG";
                            ctr.FROM_ENTITY_COMMENTS = SD.GenerateName(rand.Next(2, 7));
                            ctr.FROM_ENTITY_URL = ctr.FROM_ENTITY_COMMERCIAL_NAME + ".com";
                            ctr.FROM_ENTITY_BUSINESS_CLOSED = false;



                            //DateTime startRange = Convert.ToDateTime(rand.Next(1, 10) + "/" + rand.Next(1, 26) + "/" + rand.Next(1977, 1990) + " " + rand.Next(10, 20) + ":10:01");
                            // DateTime endRange = Convert.ToDateTime(rand.Next(1, 10) + "/" + rand.Next(1, 26) + "/" + rand.Next(1997, 2009) + " " + rand.Next(10, 20) + ":10:01");

                            ctr.FROM_ENTITY_INCORPORATION_DATE = SD.GetRandomDate(startRange, endRange);

                            // director
                            TransactionSignatoryOrDirector entityDirector = new TransactionSignatoryOrDirector();

                            entityDirector.FOR_SOURCE_TRANSACTION = true;
                            entityDirector.FOR_DIRECTOR_RECORD = true;
                            entityDirector.TRANSACTION_NUMBER = ctr.TRANSACTION_NUMBER;
                            entityDirector.GENDER = SD.Gender.ElementAt(rand.Next(0, SD.Gender.Count() - 1));

                            entityDirector.FIRST_NAME = SD.GenerateName(rand.Next(4, 9));
                            entityDirector.LAST_NAME = SD.GenerateName(rand.Next(3, 10));
                            entityDirector.SSN = "SSN" + rand.Next(876543, 9800000);
                            entityDirector.BIRTHDATE = SD.GetRandomDate(startRange, endRange);
                            entityDirector.NATIONALITY1 = "NG";
                            entityDirector.RESIDENCE = "NG";
                            entityDirector.OCCUPATION = SD.ListOfOccupation.ElementAt(SD.ListOfOccupation.Count() - 1);
                            entityDirector.SOURCE_OF_WEALTH = SD.ListOfSourceOfWealth.ElementAt(SD.ListOfSourceOfWealth.Count() - 1);
                            entityDirector.SIGNATORY_OR_DIRECTOR_TPH_CONTACT_TYPE = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 3)).Description;
                            entityDirector.SIGNATORY_OR_DIRECTOR_TPH_COMMUNICATION_TYPE = _db.LookupCommunicationType.ToList().ElementAt(rand.Next(0, 6)).Description;
                            entityDirector.SIGNATORY_OR_DIRECTOR_NUMBER = rand.Next(87650, 890763) + "" + rand.Next(87650, 890763);

                            Guid guid = Guid.NewGuid();
                            entityDirector.SIGNATORY_OR_DIRECTOR_ID = guid.ToString();

                            _db.TransactionSignatoryOrDirector.Add(entityDirector);

                            // identification
                            TransactionPersonIdentification directorIdentification = new TransactionPersonIdentification();
                            directorIdentification.FOR_DIRECTOR_IDENTIFICATION = true;
                            directorIdentification.TRANSACTION_NUMBER = ctr.TRANSACTION_NUMBER;
                            directorIdentification.TYPE = _db.LookupIdentifierType.ToList().ElementAt(rand.Next(0, 6)).Description;
                            directorIdentification.NUMBER ="ID" + SD.GenerateName(3) + rand.Next(209845, 300000);
                            directorIdentification.ISSUE_COUNTRY = "NG";
                            directorIdentification.SIGNATORY_OR_DIRECTOR_ID = entityDirector.SIGNATORY_OR_DIRECTOR_ID;

                            _db.TransactionPersonIdentification.Add(directorIdentification);


                        }
                        else
                        {

                            
                            // signatory - support multiple (add 2) - type t_person_my_client
                            TransactionSignatoryOrDirector personSignatory = new TransactionSignatoryOrDirector();



                            personSignatory.FOR_SOURCE_TRANSACTION = true;
                            personSignatory.FOR_SIGNATORY_RECORD = true;
                            personSignatory.TRANSACTION_NUMBER = ctr.TRANSACTION_NUMBER;
                            Guid guid = Guid.NewGuid();
                            personSignatory.SIGNATORY_OR_DIRECTOR_ID = guid.ToString();

                            personSignatory.GENDER = SD.Gender.ElementAt(rand.Next(0, SD.Gender.Count() - 1));

                            personSignatory.TITLE = SD.Title.ElementAt(rand.Next(0, SD.Title.Count() - 1));

                            // passsport number and passport country
                            personSignatory.PASSPORT_NUMBER = "NG" + rand.Next(100000000, 900000000).ToString();
                            personSignatory.PASSPORT_COUNTRY = "NG"; //SD.ListOfCountries.ElementAt(rand.Next(0, SD.ListOfCountries.Count() - 1));

                            personSignatory.SIGNATORY_OR_DIRECTOR_STATE = SD.ListOfState.ElementAt(rand.Next(0, SD.ListOfState.Count() - 1));
                            personSignatory.NATIONALITY2 = "NG";  // SD.ListOfCountries.ElementAt(rand.Next(0, SD.ListOfCountries.Count() - 1));

                            personSignatory.EMAIL1 = firstName + "@email.com";
                            personSignatory.BVN = rand.Next(100010010, 900000000).ToString() + rand.Next(10, 99).ToString();
                            personSignatory.CCI = rand.Next(202010010, 900000000).ToString() + rand.Next(10, 99).ToString();
                            personSignatory.TIN = "TIN" + rand.Next(1000099, 8500000);
                            personSignatory.ID_NUMBER = ctr.FROM_PERSON_ID_NUMBER;
                            personSignatory.DECEASED = ctr.DECEASED;

                            // employers info



                            personSignatory.TAX_NUMBER = "TAX" + rand.Next(50000, 90000).ToString();
                            personSignatory.TAX_REG_NUMBER = personSignatory.NATIONALITY1 + "-" + personSignatory.TAX_NUMBER;




                            personSignatory.FIRST_NAME = SD.GenerateName(rand.Next(4, 9));
                            personSignatory.LAST_NAME = SD.GenerateName(rand.Next(3, 7));
                            personSignatory.MIDDLE_NAME = SD.GenerateName(rand.Next(3, 7));

                            DateTime IstartRange = Convert.ToDateTime(rand.Next(1, 10) + "/" + rand.Next(1, 26) + "/" + rand.Next(1967, 1990) + " " + rand.Next(10, 20) + ":10:01");
                            DateTime IendRange = Convert.ToDateTime(rand.Next(1, 10) + "/" + rand.Next(1, 26) + "/" + rand.Next(1997, 2009) + " " + rand.Next(10, 20) + ":10:01");

                            personSignatory.BIRTHDATE = SD.GetRandomDate(IstartRange, IendRange);

                            personSignatory.SSN = rand.Next(100000000, 900000000).ToString() + rand.Next(10, 99).ToString();

                            // phones
                            personSignatory.SIGNATORY_OR_DIRECTOR_TPH_CONTACT_TYPE = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 3)).Item; // has only 4 records
                            personSignatory.SIGNATORY_OR_DIRECTOR_TPH_COMMUNICATION_TYPE = _db.LookupCommunicationType.ToList().ElementAt(rand.Next(0, 6)).Item; // has only 7 records
                            personSignatory.SIGNATORY_OR_DIRECTOR_NUMBER = rand.Next(10000, 30000) + "" + rand.Next(6000, 9000);


                            // addresses
                            personSignatory.SIGNATORY_OR_DIRECTOR_ADDRESS_TYPE = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 3)).Item; // has only 4 records
                            string city = SD.ListOfState.ElementAt(rand.Next(0, SD.ListOfState.Count() - 1));

                            personSignatory.SIGNATORY_OR_DIRECTOR_ADDRESS = rand.Next(0, 500) + "- " + SD.GenerateName(rand.Next(4, 9)) + " " + SD.StreetType.ElementAt(rand.Next(0, SD.StreetType.Count() - 1)) + " - " + city + "- Nigeria";
                            personSignatory.SIGNATORY_OR_DIRECTOR_CITY = city;
                            personSignatory.SIGNATORY_OR_DIRECTOR_ZIP = rand.Next(1001, 9009) + "";
                            personSignatory.SIGNATORY_OR_DIRECTOR_COUNTRY_CODE = SD.ListOfCountries.ElementAt(rand.Next(0, SD.ListOfCountries.Count() - 1));


                            // nationality
                            personSignatory.NATIONALITY1 = SD.ListOfCountries.ElementAt(rand.Next(0, SD.ListOfCountries.Count() - 1));

                            personSignatory.RESIDENCE = SD.ListOfCountries.ElementAt(rand.Next(0, SD.ListOfCountries.Count() - 1));

                            personSignatory.OCCUPATION = SD.ListOfOccupation.ElementAt(rand.Next(0, SD.ListOfOccupation.Count() - 1));

                            personSignatory.SOURCE_OF_WEALTH = SD.ListOfSourceOfWealth.ElementAt(rand.Next(0, 3));

                            _db.TransactionSignatoryOrDirector.Add(personSignatory);
                            // SIGNATORY end


                            // load identification after signatory is added to db so as to get the genetated ID
                            // identification - multiple
                            TransactionPersonIdentification personIdentification = new TransactionPersonIdentification();

                            personIdentification.FOR_SIGNATORY_IDENTIFICATION = true;
                            personIdentification.TRANSACTION_NUMBER = ctr.TRANSACTION_NUMBER;
                            personIdentification.SIGNATORY_OR_DIRECTOR_ID = personSignatory.SIGNATORY_OR_DIRECTOR_ID;

                            personIdentification.TYPE = _db.LookupIdentifierType.ToList().ElementAt(rand.Next(0, 6)).Item; // has only 7 records
                            personIdentification.NUMBER = rand.Next(23456, 76543) + "" + rand.Next(23456, 76543);
                            personIdentification.ISSUE_COUNTRY = SD.ListOfCountries.ElementAt(rand.Next(0, SD.ListOfCountries.Count() - 1));

                            // issue date
                            personIdentification.ISSUE_DATE = SD.GetRandomDate(startRange, endRange);

                            _db.TransactionPersonIdentification.Add(personIdentification);
                            // identification end


                        }

                        ctr.BALANCE = rand.Next(1000000, 9000000);
                        ctr.STATUS_CODE = _db.LookupAccountStatusType.ToList().ElementAt(rand.Next(0, 1)).Item;
                        ctr.STATUS_DESC = _db.LookupAccountStatusType.ToList().ElementAt(rand.Next(0, 1)).Description;

                        ctr.BENEFICIARY = SD.GenerateName(rand.Next(3, 8)) + " " + SD.GenerateName(rand.Next(3, 8));
                        DateTime startDateRange = Convert.ToDateTime(rand.Next(1, 10) + "/" + rand.Next(1, 26) + "/" + rand.Next(1977, 1990) + " " + rand.Next(10, 20) + ":10:01");
                        DateTime endDateRange = Convert.ToDateTime(rand.Next(1, 10) + "/" + rand.Next(1, 26) + "/" + rand.Next(1997, 2009) + " " + rand.Next(10, 20) + ":10:01");

                        ctr.OPENED = SD.GetRandomDate(startDateRange, endDateRange);

                        if (homeVM.forFTR)
                        {
                            _db.FTR.Add(ftr);
                        }
                    }
                    else if (homeVM.from.Equals("fromperson"))
                    {

                        // t_from->from_person (type t_person)

                        ctr.FROM_PERSON_GENDER = SD.Gender.ElementAt(rand.Next(0, SD.Gender.Count() - 1));
                        ctr.FROM_PERSON_FIRST_NAME = SD.GenerateName(rand.Next(4, 8));
                        ctr.FROM_PERSON_LAST_NAME = SD.GenerateName(rand.Next(4, 8));
                        ctr.FROM_PERSON_MIDDLE_NAME = SD.GenerateName(rand.Next(2, 7));

                        DateTime startRange = Convert.ToDateTime(rand.Next(1, 10) + "/" + rand.Next(1, 26) + "/" + rand.Next(1977, 1990) + " " + rand.Next(10, 20) + ":10:01");
                        DateTime endRange = Convert.ToDateTime(rand.Next(1, 10) + "/" + rand.Next(1, 26) + "/" + rand.Next(1997, 2009) + " " + rand.Next(10, 20) + ":10:01");

                        ctr.FROM_PERSON_BIRTHDATE = SD.GetRandomDate(startRange, endRange);
                        ctr.FROM_PERSON_BIRTH_PLACE = SD.ListOfState[rand.Next(0, 9)];
                        ctr.FROM_PERSON_MOTHERS_NAME = SD.GenerateName(rand.Next(4, 7));


                        ctr.FROM_PERSON_GENDER = SD.Gender[rand.Next(0, 4)];
                        ctr.FROM_PERSON_TITLE = SD.Title[rand.Next(0, 4)];


                        ctr.FROM_PERSON_SSN = "SSN" + rand.Next(2000000, 8000000).ToString() + rand.Next(10, 99).ToString();
                        ctr.FROM_PERSON_PASSPORT_NUMBER = "NG" + rand.Next(10000000, 80000000).ToString() + rand.Next(10, 99).ToString();
                        ctr.FROM_PERSON_PASSPORT_COUNTRY = "NG";
                        ctr.FROM_PERSON_ID_NUMBER = "N" + rand.Next(1000000, 8000000).ToString() + rand.Next(10, 99).ToString();
                        ctr.FROM_PERSON_TPH_CONTACT_TYPE = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 4)).Description;
                        ctr.FROM_PERSON_TPH_COMMUNICATION_TYPE = _db.LookupCommunicationType.ToList().ElementAt(rand.Next(0, 4)).Description;
                        ctr.FROM_PERSON_EMPLOYER_TPH_COMMUNICATION_TYPE = "Mobile Phone";
                        ctr.FROM_PERSON_COUNTRY_PREFIX = "+234";

                        ctr.FROM_PERSON_NUMBER = rand.Next(7000, 9000) + "" + rand.Next(40000, 90000);
                        ctr.FROM_PERSON_ADDRESS_TYPE = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 4)).Description;
                        ctr.FROM_PERSON_CITY = SD.ListOfState[rand.Next(0, 9)];
                        ctr.FROM_PERSON_ADDRESS = rand.Next(0, 500) + "- " + SD.GenerateName(rand.Next(3, 9)) + " " + SD.StreetType.ElementAt(rand.Next(0, SD.StreetType.Count() - 1)) + " - " + ctr.FROM_PERSON_CITY + "- Nig";
                        ctr.FROM_PERSON_TOWN = SD.ListOfLocalGov[rand.Next(0, 9)];

                        ctr.FROM_PERSON_COUNTRY_CODE = "NG";
                        ctr.FROM_PERSON_STATE = SD.ListOfState[rand.Next(0, 9)];
                        ctr.FROM_PERSON_NATIONALITY1 = "NIG";
                        ctr.FROM_PERSON_NATIONALITY2 = "NIG";
                        ctr.FROM_PERSON_RESIDENCE = "Home";

                        ctr.FROM_PERSON_EMAIL1 = ctr.FROM_PERSON_FIRST_NAME + ctr.FROM_PERSON_MIDDLE_NAME + "@email.com";
                        ctr.FROM_PERSON_EMAIL2 = ctr.FROM_PERSON_FIRST_NAME + ctr.FROM_PERSON_MIDDLE_NAME + "@email.com";
                        ctr.FROM_PERSON_EMAIL3 = ctr.FROM_PERSON_FIRST_NAME + ctr.FROM_PERSON_MIDDLE_NAME + "@email.com";
                        ctr.FROM_PERSON_OCCUPATION = SD.ListOfOccupation[rand.Next(0, 5)];
                        ctr.FROM_PERSON_SOURCE_OF_WEALTH = SD.ListOfSourceOfWealth[rand.Next(0, 6)];



                    }



                    // to
                    // tofundscode // funds type
                    ctr.TO_FUNDS_CODE = homeVM.FundsTypeCode;

                    if (string.IsNullOrEmpty(ctr.FROM_COUNTRY))
                    {

                        ctr.TO_COUNTRY_CODE = "NG";
                    }
                    else
                    {
                        ctr.TO_COUNTRY_CODE = ctr.FROM_COUNTRY;
                    }

                    // add to foreign currency
                    if (homeVM.ToAddForeignCurrency)
                    {
                        if (string.IsNullOrEmpty(ctr.FROM_COUNTRY))
                        {
                            ctr.TO_COUNTRY_CODE = SD.ListOfCountries.ElementAt(rand.Next(0, SD.ListOfCountries.Count() - 1));
                            ctr.FROM_PERSONAL_ACCOUNT_TYPE = "DOMICILLIARY ACCOUNT";
                        }
                        else
                        {
                            ctr.TO_COUNTRY_CODE = ctr.FROM_COUNTRY;
                        }
                        

                        if (ctr.TO_COUNTRY_CODE.Equals("US"))
                        {
                            currencyCode = "USD";
                        }
                        else if (ctr.TO_COUNTRY_CODE.Equals("GB"))
                        {
                            currencyCode = "GBP";
                        }
                        else if (ctr.TO_COUNTRY_CODE.Equals("MT"))
                        {
                            currencyCode = "EUR";
                        }

                        ctr.TO_FOREIGN_CURRENCY_CODE = currencyCode;
                        ctr.TO_FOREIGN_EXCHANGE_RATE = rand.Next(460, 500);
                        ctr.TO_FOREIGN_AMOUNT = ctr.AMOUNT_LOCAL / ctr.TO_FOREIGN_EXCHANGE_RATE;
                        //ctr.TO_FOREIGN_AMOUNT = ctr.AMOUNT_LOCAL * rand.Next(300, 400);

                    }


                    



                    if (homeVM.to.Equals("toaccount"))
                    {

                        
                        ctr.TO_INSTITUTION_NAME = SD.ListOfInstitution.ElementAt(rand.Next(0, SD.ListOfInstitution.Count() - 1));
                        ctr.TO_INSTITUTION_CODE = ctr.TO_INSTITUTION_NAME.Substring(0, 3) + rand.Next(150, 200);
                        ctr.TO_INSTITUTION_SWIFT = ctr.TO_INSTITUTION_NAME.Substring(0, 3) + rand.Next(1500, 2000);
                        ctr.TO_INSTITUTION_BRANCH = ctr.TO_INSTITUTION_CODE + ctr.TRANSACTION_LOCATION;
                        ctr.TO_INSTITUTION_BRANCH_CODE = ctr.TO_INSTITUTION_BRANCH;

                        ctr.TO_ACCOUNT = rand.Next(1000000000, 2076543210).ToString();
                        ctr.TO_ACCOUNT_IBAN = "IB" + ctr.TO_ACCOUNT;
                        ctr.TO_PERSONAL_ACCOUNT_TYPE = _db.LookupAccountType.ToList().ElementAt(rand.Next(0, 4)).Item;
                        ctr.TO_PERSONAL_ACCOUNT_DESC = _db.LookupAccountType.ToList().ElementAt(rand.Next(0, 4)).Description;
                        ctr.TO_ACCOUNT_COMMENTS = SD.GenerateName(rand.Next(4, 10));
                      
                        

                       
                        // to account name
                        String firstName = SD.GenerateName(rand.Next(4, 8));
                        String lastName = SD.GenerateName(rand.Next(3, 8));

                        ctr.TO_ACCOUNT_NAME = firstName + " " + lastName;
                        ctr.TO_STATUS_CODE = _db.LookupAccountStatusType.ToList().ElementAt(rand.Next(0, 1)).Item;
                        ctr.TO_STATUS_DESC = _db.LookupAccountStatusType.ToList().ElementAt(rand.Next(0, 1)).Description;

                        ctr.TO_PERSON_GENDER = SD.Gender[rand.Next(0, 5)];
                        ctr.TO_PERSON_TITLE = SD.Title[rand.Next(0, 5)];
                        ctr.TO_CLIENT_NUMBER = rand.Next(100000000, 900000000).ToString() + rand.Next(10, 99).ToString(); // 11 digits number only
                        ctr.TO_PERSON_FIRST_NAME = firstName;
                        ctr.TO_PERSON_LAST_NAME = lastName;
                        ctr.TO_PERSON_MIDDLE_NAME = SD.GenerateName(rand.Next(4, 9));
                        ctr.TO_PERSON_MOTHERS_NAME = SD.GenerateName(rand.Next(2, 8));

                        DateTime startRange = Convert.ToDateTime(rand.Next(1, 10) + "/" + rand.Next(1, 26) + "/" + rand.Next(1977, 1990) + " " + rand.Next(10, 20) + ":10:01");
                        DateTime endRange = Convert.ToDateTime(rand.Next(1, 10) + "/" + rand.Next(1, 26) + "/" + rand.Next(1997, 2009) + " " + rand.Next(10, 20) + ":10:01");
                        ctr.TO_PERSON_BIRTHDATE = SD.GetRandomDate(startRange, endRange);
                        ctr.TO_PERSON_BIRTH_PLACE = SD.ListOfState[rand.Next(0, 5)];
                        ctr.TO_PERSON_SSN  = "SSN" + rand.Next(1000000, 7000000).ToString() + rand.Next(10, 99).ToString();
                        ctr.TO_PERSON_PASSPORT_NUMBER = "NG" + rand.Next(20050000, 70005000).ToString() + rand.Next(10, 99).ToString();
                        ctr.TO_PERSON_PASSPORT_COUNTRY = "NG";
                        ctr.TO_PERSON_ID_NUMBER = "NG" + rand.Next(1000000, 8000000).ToString() + rand.Next(10, 99).ToString();
                        ctr.TO_PERSON_TPH_CONTACT_TYPE = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 1)).Description;

                        ctr.TO_PERSON_COUNTRY_PREFIX = "+234";
                        ctr.TO_PERSON_NUMBER = rand.Next(5000, 9000) + "" + rand.Next(20000, 90000);
                        ctr.TO_PERSON_ADDRESS_TYPE = "Private";
                        ctr.TO_PERSON_CITY = SD.ListOfState[rand.Next(1, 9)];
                        ctr.TO_PERSON_ADDRESS = rand.Next(1, 500) + "- " + SD.GenerateName(rand.Next(3, 9)) + " " + SD.StreetType.ElementAt(rand.Next(0, SD.StreetType.Count() - 1)) + " - " + ctr.TO_PERSON_CITY + "- Nig";
                        ctr.TO_PERSON_TOWN = SD.ListOfLocalGov[rand.Next(1, 9)];

                        ctr.TO_PERSON_COUNTRY_CODE = "NG";
                        ctr.TO_PERSON_STATE = SD.ListOfState[rand.Next(1, 9)];
                        ctr.TO_PERSON_NATIONALITY1 = "NIG";
                        ctr.TO_PERSON_NATIONALITY2 = "NIG";
                        ctr.TO_PERSON_RESIDENCE = "Home";


                        ctr.TO_PERSON_EMAIL1 = firstName + ctr.TO_PERSON_MIDDLE_NAME + "@email.com";
                        ctr.TO_PERSON_EMAIL2 = firstName + ctr.TO_PERSON_MIDDLE_NAME + "@email.com";
                        ctr.TO_PERSON_EMAIL3 = lastName + ctr.TO_PERSON_MIDDLE_NAME + "@email.com";
                        ctr.TO_PERSON_OCCUPATION = SD.ListOfOccupation[rand.Next(0, 4)];
                        ctr.TO_PERSON_EMPLOYER_NAME = SD.GenerateName(rand.Next(5, 10));
                        ctr.TO_PERSON_EMPLOYER_ADDRESS_TYPE = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 3)).Description;
                        ctr.TO_PERSON_EMPLOYER_ADDRESS = rand.Next(0, 200) + "- " + SD.GenerateName(rand.Next(2, 6)) + " " + SD.StreetType.ElementAt(rand.Next(0, SD.StreetType.Count() - 1)) + " - " + ctr.TO_PERSON_CITY + "- Nigeria";
                        ctr.TO_PERSON_EMPLOYER_CITY = ctr.TO_PERSON_CITY;
                        ctr.TO_PERSON_EMPLOYER_COUNTRY_CODE = "NG";
                        ctr.TO_PERSON_EMPLOYER_STATE = ctr.TO_PERSON_CITY;
                        ctr.TO_PERSON_EMPLOYER_TPH_CONTACT_TYPE = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 3)).Description;
                        ctr.TO_PERSON_EMPLOYER_NUMBER = rand.Next(700, 900) + "" + rand.Next(10000, 90000);
                        ctr.TO_PERSON_TAX_REG_NUMBER = "TIN" + rand.Next(1000099, 8500000);
                        ctr.TO_PERSON_SOURCE_OF_WEALTH = SD.ListOfSourceOfWealth[rand.Next(0, 6)];
                        ctr.TO_PERSON_DECEASED = false;





                        if (homeVM.toentityaccount)
                        {
                            ctr.TO_ENTITY_NAME = SD.ListOfInstitution.ElementAt(rand.Next(0, SD.ListOfInstitution.Count() - 1));
                            ctr.TO_ENTITY_COMMERCIAL_NAME = ctr.TO_ENTITY_NAME;
                            ctr.TO_PERSONAL_ACCOUNT_TYPE = _db.LookupAccountType.ToList().ElementAt(rand.Next(0, 3)).Item;
                            ctr.TO_PERSONAL_ACCOUNT_DESC = _db.LookupAccountType.ToList().ElementAt(rand.Next(0, 3)).Description;

                            ctr.TO_ENTITY_INCORPORATION_LEGAL_FORM = SD.LegalForm.ElementAt(rand.Next(0, SD.LegalForm.Count() - 1));
                            ctr.TO_ENTITY_INCORPORATION_NUMBER = ctr.TO_ENTITY_NAME.Replace(" ", "").Substring(0, 4) + ctr.TRANSACTION_NUMBER.Substring(5, 3);
                            ctr.TO_ENTITY_BUSINESS = SD.ListOfBusiness.ElementAt(rand.Next(0, SD.ListOfBusiness.Count() - 1));
                            ctr.TO_ENTITY_INCORPORATION_COUNTRY_CODE = "NG";
                            ctr.TO_ENTITY_TPH_CONTACT_TYPE = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 3)).Description;
                            ctr.TO_ENTITY_TPH_COMMUNICATION_TYPE = _db.LookupCommunicationType.ToList().ElementAt(rand.Next(0, 6)).Description;
                            ctr.TO_PERSON_COUNTRY_PREFIX = "+234";
                            ctr.TO_ENTITY_NUMBER = rand.Next(187650, 987650) + "" + rand.Next(187650, 987650);
                            ctr.TO_ENTITY_ADDRESS_TYPE = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 3)).Item;
                            ctr.TO_ENTITY_ADDRESS_DESC = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 3)).Description;
                            string city = SD.ListOfState.ElementAt(rand.Next(0, SD.ListOfState.Count() - 1));
                            ctr.TO_ENTITY_ADDRESS = rand.Next(0, 500) + "- " + SD.GenerateName(rand.Next(4, 9)) + " " + SD.StreetType.ElementAt(rand.Next(0, SD.StreetType.Count() - 1)) + " - " + city + "- Nigeria";
                            ctr.TO_ENTITY_CITY = city;
                            ctr.TO_ENTITY_COUNTRY_CODE = ctr.TO_COUNTRY_CODE; ;
                            ctr.TO_ENTITY_STATE = city;
                            ctr.TO_ENTITY_EMAIL = ctr.TO_ENTITY_NAME + "@email.com";
                            ctr.TO_ENTITY_URL = ctr.TO_ENTITY_COMMERCIAL_NAME + ".COM";
                            ctr.TO_ENTITY_INCORPORATION_STATE = city;
                            ctr.TO_ENTITY_TAX_NUMBER = "TIN" + rand.Next(1000000, 9000000);
                            ctr.TO_ENTITY_TAX_REG_NUMBER = "REG" + rand.Next(10009000, 89000000);
                            ctr.TO_ENTITY_INCORPORATION_COUNTRY_CODE = "NG";
                            ctr.TO_ENTITY_COMMENTS = SD.GenerateName(rand.Next(2, 7));
                        }





                    }
                    else if (homeVM.to.Equals("tomyclientaccount"))
                    {
                        // t-account-my-client
                        ctr.TO_INSTITUTION_NAME = SD.ListOfInstitution.ElementAt(rand.Next(0, SD.ListOfInstitution.Count() - 1));
                        ctr.TO_INSTITUTION_CODE = ctr.TO_INSTITUTION_NAME.Substring(0, 3) + rand.Next(150, 200);
                        ctr.TO_INSTITUTION_BRANCH = rand.Next(150, 200) + ctr.TO_INSTITUTION_NAME.Substring(0, 3) + rand.Next(1, 20);
                        ctr.TO_INSTITUTION_SWIFT = ctr.TO_INSTITUTION_NAME.Substring(0, 3) + rand.Next(1000, 2500);

                        ctr.TO_ACCOUNT = rand.Next(1000000000, 2076543210).ToString();
                        ctr.TO_ACCOUNT_IBAN = "IB" + ctr.TO_ACCOUNT;
                        ctr.TO_PERSONAL_ACCOUNT_TYPE = _db.LookupAccountType.ToList().ElementAt(rand.Next(0, 3)).Item;
                        ctr.TO_PERSONAL_ACCOUNT_DESC = _db.LookupAccountType.ToList().ElementAt(rand.Next(0, 3)).Description;

                        ctr.TO_CURRENCY_CODE = "NGN";

                        
                        // to account name
                        string firstName = SD.GenerateName(rand.Next(3, 8));
                        string lastName = SD.GenerateName(rand.Next(4, 9));

                        ctr.TO_ACCOUNT_NAME = lastName + " " + firstName;
                        ctr.TO_STATUS_CODE = "ACTIVE";
                        ctr.TO_PERSON_GENDER = SD.Gender[rand.Next(0, 5)];
                        ctr.TO_PERSON_TITLE = SD.Title[rand.Next(0, 5)];
                        ctr.TO_PERSON_FIRST_NAME = firstName;
                        ctr.TO_PERSON_LAST_NAME = lastName;
                        ctr.TO_PERSON_MIDDLE_NAME = SD.GenerateName(rand.Next(4, 9));
                        ctr.TO_PERSON_MOTHERS_NAME = SD.GenerateName(rand.Next(2, 8));
                        ctr.TO_CLIENT_NUMBER = rand.Next(100000000, 900000000).ToString() + rand.Next(10, 99).ToString(); // 11 digits number only
                        
                        DateTime startRange = Convert.ToDateTime(rand.Next(1, 10) + "/" + rand.Next(1, 26) + "/" + rand.Next(1977, 1990) + " " + rand.Next(10, 20) + ":10:01");
                        DateTime endRange = Convert.ToDateTime(rand.Next(1, 10) + "/" + rand.Next(1, 26) + "/" + rand.Next(1997, 2009) + " " + rand.Next(10, 20) + ":10:01");
                        
                        ctr.TO_PERSON_BIRTHDATE = SD.GetRandomDate(startRange, endRange);
                        ctr.TO_PERSON_BIRTH_PLACE = SD.ListOfState[rand.Next(0, 5)];
                        ctr.TO_PERSON_SSN = "SSN" + rand.Next(2004000, 8006000).ToString() + rand.Next(10, 99).ToString();
                        ctr.TO_PERSON_PASSPORT_NUMBER = "NG" + rand.Next(1006000, 70005000).ToString() + rand.Next(10, 99).ToString();
                        ctr.TO_PERSON_PASSPORT_COUNTRY = "NG";
                        ctr.TO_PERSON_TPH_CONTACT_TYPE = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 3)).Description;
                        ctr.TO_PERSON_TPH_COMMUNICATION_TYPE = _db.LookupCommunicationType.ToList().ElementAt(rand.Next(0, 6)).Description;
                        ctr.TO_PERSON_COUNTRY_PREFIX = "+234";

                        ctr.TO_PERSON_NUMBER = rand.Next(5000, 9000) + "" + rand.Next(20000, 90000);
                        ctr.TO_PERSON_ADDRESS_TYPE = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 3)).Description;
                        
                        ctr.TO_PERSON_CITY = SD.ListOfState[rand.Next(1, 9)];
                        ctr.TO_PERSON_STATE = ctr.TO_PERSON_CITY;
                        ctr.TO_PERSON_ADDRESS = rand.Next(1, 500) + "- " + SD.GenerateName(rand.Next(3, 9)) + " " + SD.StreetType.ElementAt(rand.Next(0, SD.StreetType.Count() - 1)) + " - " + ctr.TO_PERSON_CITY + "- Nig";
                        ctr.TO_PERSON_TOWN = SD.ListOfLocalGov[rand.Next(1, 9)];
                        ctr.TO_PERSON_COUNTRY_CODE = "NG";
                        
                        ctr.TO_PERSON_NATIONALITY1 = "NIG";
                        ctr.TO_PERSON_NATIONALITY2 = "NIG";
                        ctr.TO_PERSON_RESIDENCE = "Home";


                        ctr.TO_PERSON_EMAIL1 = firstName + ctr.TO_PERSON_MIDDLE_NAME + "@email.com";
                        ctr.TO_PERSON_EMAIL2 = firstName + ctr.TO_PERSON_MIDDLE_NAME + "@email.com";
                        ctr.TO_PERSON_EMAIL3 = lastName + ctr.TO_PERSON_MIDDLE_NAME + "@email.com";
                        ctr.TO_PERSON_OCCUPATION = SD.ListOfOccupation[rand.Next(0, 4)];
                        ctr.TO_PERSON_EMPLOYER_NAME = SD.GenerateName(rand.Next(5, 10));
                        ctr.TO_PERSON_EMPLOYER_ADDRESS_TYPE = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 3)).Description;
                        ctr.TO_PERSON_EMPLOYER_ADDRESS = rand.Next(0, 200) + "- " + SD.GenerateName(rand.Next(2, 6)) + " " + SD.StreetType.ElementAt(rand.Next(0, SD.StreetType.Count() - 1)) + " - " + ctr.TO_PERSON_CITY + "- Nigeria";
                        ctr.TO_PERSON_EMPLOYER_CITY = ctr.TO_PERSON_CITY;
                        ctr.TO_PERSON_EMPLOYER_COUNTRY_CODE = "NG";
                        ctr.TO_PERSON_EMPLOYER_TOWN = ctr.TO_PERSON_CITY;
                        ctr.TO_PERSON_EMPLOYER_STATE = ctr.TO_PERSON_CITY;
                        ctr.TO_PERSON_EMPLOYER_TPH_CONTACT_TYPE = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 3)).Description;
                        ctr.TO_PERSON_EMPLOYER_TPH_COMMUNICATION_TYPE= _db.LookupCommunicationType.ToList().ElementAt(rand.Next(0, 6)).Description;
                        ctr.TO_PERSON_EMPLOYER_NUMBER = rand.Next(700, 900) + "" + rand.Next(10000, 90000);
                        ctr.TO_PERSON_TAX_NUMBER = "TIN" + rand.Next(1000099, 8500000);
                        ctr.TO_PERSON_TAX_REG_NUMBER = ctr.TO_PERSON_TAX_NUMBER;
                        ctr.TO_PERSON_SOURCE_OF_WEALTH = SD.ListOfSourceOfWealth[rand.Next(0, 5)];


                        ftr = new FTR();

                        ctr.TO_CUSTOMER_TYPE = "INDIVIDUAL";
                        ftr.RegistrationNumber = ctr.TO_INSTITUTION_NAME.Replace(" ", "").Substring(0, 3) + "-" + Guid.NewGuid().ToString().Substring(0, 6);

                        string usercity = SD.ListOfState.ElementAt(rand.Next(0, SD.ListOfState.Count() - 1));
                        ftr.SecondLineAddress = rand.Next(0, 500) + "- " + SD.GenerateName(rand.Next(4, 9)) + " " + SD.StreetType.ElementAt(rand.Next(0, SD.StreetType.Count() - 1)) + " - " + usercity;
                        ftr.LocalGovernment = SD.ListOfLocalGov.ElementAt(rand.Next(0, SD.ListOfLocalGov.Count() - 1));
                        ftr.LinkedAccounts = rand.Next(23456, 65435) + "" + rand.Next(23456, 65435);
                        ftr.FirstName = ctr.TO_PERSON_FIRST_NAME;
                        ftr.MiddleName = ctr.TO_PERSON_MIDDLE_NAME;
                        ftr.Nationality = ctr.TO_PERSON_NATIONALITY1;
                        ftr.DateOfBirth = ctr.TO_PERSON_BIRTHDATE;
                        ftr.TypeOfIdentification = _db.LookupIdentifierType.ToList().ElementAt(rand.Next(0, 6)).Description;
                        ftr.IdentificationNo = "ID" + SD.GenerateName(3) + rand.Next(2009845, 3000000);
                        ftr.DateOfIssue= SD.GetRandomDate(startRange, endRange);
                        ftr.PlaceOfIssue =  ftr.LocalGovernment;
                        ftr.IssuingAuthority = "Govt";
                        ftr.State = SD.ListOfState[rand.Next(1, 9)];
                        ftr.Email = ftr.SurnameOrNameOfOrganisation + "@mail.com";
                        ftr.SourceOfFunds = SD.ListOfSourceOfWealth[rand.Next(1, 4)];

                        ftr.PurposeOfTransaction = SD.ListOfReason.ElementAt(rand.Next(0, SD.ListOfReason.Count() - 1));

                        usercity = SD.ListOfState.ElementAt(rand.Next(0, SD.ListOfState.Count() - 1));
                        ftr.AddressOfBeneficiary = rand.Next(0, 500) + "- " + SD.GenerateName(rand.Next(4, 9)) + " " + SD.StreetType.ElementAt(rand.Next(0, SD.StreetType.Count() - 1)) + " - " + usercity + "- Nigeria";
                        usercity = SD.ListOfState.ElementAt(rand.Next(0, SD.ListOfState.Count() - 1));
                        ftr.AddressOfSender = rand.Next(0, 500) + "- " + SD.GenerateName(rand.Next(4, 9)) + " " + SD.StreetType.ElementAt(rand.Next(0, SD.StreetType.Count() - 1)) + " - " + usercity + "- Nigeria";

                        ctr.TO_CMO = "MERIT BANK";
                        ftr.TransactionNumber = ctr.TRANSACTION_NUMBER;
                        ftr.ReferenceNumber = "MRT-" + ctr.TRANSACTION_NUMBER.Substring(5, 4);
                        ftr.ForDestinationTransaction = true;

                        if (homeVM.toentityaccount)
                        {
                            ctr.TO_CUSTOMER_TYPE = "INSTIITUTIONAL";

                            ctr.TO_PERSONAL_ACCOUNT_DESC = _db.LookupAccountType.ToList().ElementAt(rand.Next(0, 3)).Description;
                            ctr.TO_PERSONAL_ACCOUNT_TYPE = _db.LookupAccountType.ToList().ElementAt(rand.Next(0, 3)).Item;

                            ctr.TO_ENTITY_NAME =  SD.ListOfEntities.ElementAt(rand.Next(0, SD.ListOfEntities.Count() - 1));
                            ctr.TO_ENTITY_INCORPORATION_LEGAL_FORM = SD.LegalForm.ElementAt(rand.Next(0, SD.LegalForm.Count() - 1));
                            ctr.TO_ENTITY_INCORPORATION_NUMBER = ctr.TO_ENTITY_NAME.Replace(" ", "").Substring(0, 4) + ctr.TRANSACTION_NUMBER.Substring(5, 3);
                            ctr.TO_ENTITY_BUSINESS = SD.ListOfBusiness.ElementAt(rand.Next(0, SD.ListOfBusiness.Count() - 1));
                            ctr.TO_ENTITY_INCORPORATION_COUNTRY_CODE = "NG";
                            ctr.TO_ENTITY_TPH_CONTACT_TYPE = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 3)).Description;
                            ctr.TO_ENTITY_TPH_COMMUNICATION_TYPE = _db.LookupCommunicationType.ToList().ElementAt(rand.Next(0, 6)).Description;
                            
                            ctr.TO_PERSON_COUNTRY_PREFIX = "+234";
                            ctr.TO_ENTITY_NUMBER = rand.Next(187650, 987650) + "" + rand.Next(187650, 987650);
                            ctr.TO_ENTITY_ADDRESS_TYPE = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 3)).Description;
                            string city = SD.ListOfState.ElementAt(rand.Next(0, SD.ListOfState.Count() - 1));
                            ctr.TO_ENTITY_ADDRESS = rand.Next(0, 500) + "- " + SD.GenerateName(rand.Next(4, 9)) + " " + SD.StreetType.ElementAt(rand.Next(0, SD.StreetType.Count() - 1)) + " - " + city + "- Nigeria";
                            ctr.TO_ENTITY_CITY = city;
                            ctr.TO_ENTITY_STATE = city;
                            ctr.TO_ENTITY_COUNTRY_CODE = ctr.TO_COUNTRY_CODE;
                            ctr.TO_ENTITY_EMAIL = ctr.TO_ENTITY_NAME + "@email.com";
                            ctr.TO_ENTITY_INCORPORATION_STATE = city;
                            
                            ctr.TO_ENTITY_TAX_NUMBER = "TIN" + rand.Next(1000000, 9000000);
                            ctr.TO_ENTITY_TAX_REG_NUMBER = "REG" + rand.Next(10009000, 89000000);
                            ctr.TO_ENTITY_INCORPORATION_COUNTRY_CODE = "NG";
                            ctr.TO_ENTITY_COMMENTS = SD.GenerateName(rand.Next(2, 7));


                            DateTime IstartRange = Convert.ToDateTime(rand.Next(1, 10) + "/" + rand.Next(1, 26) + "/" + rand.Next(1987, 1990) + " " + rand.Next(10, 20) + ":10:01");
                            DateTime IendRange = Convert.ToDateTime(rand.Next(1, 10) + "/" + rand.Next(1, 26) + "/" + rand.Next(1991, 2009) + " " + rand.Next(10, 20) + ":10:01");

                            ctr.TO_ENTITY_INCORPORATION_DATE = SD.GetRandomDate(IstartRange, IendRange);

                            // director
                            TransactionSignatoryOrDirector entityDirector = new TransactionSignatoryOrDirector();

                            entityDirector.FOR_DESTINATION_TRANSACTION = true;
                            entityDirector.FOR_DIRECTOR_RECORD = true;
                            entityDirector.TRANSACTION_NUMBER = ctr.TRANSACTION_NUMBER;
                            entityDirector.GENDER = SD.Gender.ElementAt(rand.Next(0, SD.Gender.Count() - 1));

                            entityDirector.FIRST_NAME = SD.GenerateName(rand.Next(4, 9));
                            entityDirector.LAST_NAME = SD.GenerateName(rand.Next(3, 10));
                            entityDirector.MIDDLE_NAME = SD.GenerateName(rand.Next(4, 9));
                            entityDirector.MOTHERS_NAME = SD.GenerateName(rand.Next(4, 10));
                            entityDirector.SSN = "" + rand.Next(876543, 9800000);
                            entityDirector.BIRTH_PLACE = SD.ListOfState.ElementAt(rand.Next(0, SD.ListOfState.Count() - 1));

                            entityDirector.BIRTHDATE = SD.GetRandomDate(startRange, endRange);
                            entityDirector.NATIONALITY1 = "NG";
                            entityDirector.RESIDENCE = "NG";
                            entityDirector.OCCUPATION = SD.ListOfOccupation.ElementAt(SD.ListOfOccupation.Count() - 1);
                            entityDirector.SOURCE_OF_WEALTH = SD.ListOfSourceOfWealth.ElementAt(SD.ListOfSourceOfWealth.Count() - 1);
                            entityDirector.SIGNATORY_OR_DIRECTOR_TPH_CONTACT_TYPE = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 3)).Item;
                            entityDirector.SIGNATORY_OR_DIRECTOR_TPH_COMMUNICATION_TYPE = _db.LookupCommunicationType.ToList().ElementAt(rand.Next(0, 6)).Item;
                            entityDirector.SIGNATORY_OR_DIRECTOR_NUMBER = rand.Next(87650, 890763) + "" + rand.Next(87650, 890763);
                            entityDirector.PASSPORT_NUMBER = "NG" + rand.Next(1006000, 70005000).ToString() + rand.Next(10, 99).ToString();
                            entityDirector.PASSPORT_COUNTRY = "NG";
                            entityDirector.ID_NUMBER = "ID" + rand.Next(1026000, 70025000).ToString() + rand.Next(10, 99).ToString();
                            entityDirector.EMAIL1 = entityDirector.FIRST_NAME + entityDirector.MIDDLE_NAME + "@email.com";
                            entityDirector.EMAIL2 = entityDirector.FIRST_NAME + entityDirector.LAST_NAME + "@email.com";
                            Guid guid = Guid.NewGuid();
                            entityDirector.SIGNATORY_OR_DIRECTOR_ID = guid.ToString();

                            _db.TransactionSignatoryOrDirector.Add(entityDirector);

                            // identification
                            TransactionPersonIdentification directorIdentification = new TransactionPersonIdentification();
                            directorIdentification.FOR_DIRECTOR_IDENTIFICATION = true;
                            directorIdentification.TRANSACTION_NUMBER = ctr.TRANSACTION_NUMBER;
                            directorIdentification.TYPE = _db.LookupIdentifierType.ToList().ElementAt(rand.Next(0, 6)).Item;
                            directorIdentification.NUMBER = SD.GenerateName(3) + rand.Next(209845, 300000);
                            directorIdentification.ISSUE_COUNTRY = "NG";
                            directorIdentification.SIGNATORY_OR_DIRECTOR_ID = entityDirector.SIGNATORY_OR_DIRECTOR_ID;

                            _db.TransactionPersonIdentification.Add(directorIdentification);


                        }
                        else
                        {

                            // signatory - support multiple (add 2) - type t_person_my_client
                            TransactionSignatoryOrDirector personSignatory = new TransactionSignatoryOrDirector();



                            personSignatory.FOR_DESTINATION_TRANSACTION = true;
                            personSignatory.FOR_SIGNATORY_RECORD = true;
                            
                            personSignatory.TRANSACTION_NUMBER = ctr.TRANSACTION_NUMBER;
                            Guid guid = Guid.NewGuid();
                            personSignatory.SIGNATORY_OR_DIRECTOR_ID = guid.ToString();

                            //personSignatory.ROLE = SD.
                            personSignatory.GENDER = SD.Gender.ElementAt(rand.Next(0, SD.Gender.Count() - 1));

                            personSignatory.TITLE = SD.Title.ElementAt(rand.Next(0, SD.Title.Count() - 1));

                            // passsport number and passport country
                            personSignatory.PASSPORT_NUMBER = rand.Next(100000000, 900000000).ToString();
                            personSignatory.PASSPORT_COUNTRY = SD.ListOfCountries.ElementAt(rand.Next(0, SD.ListOfCountries.Count() - 1));

                            personSignatory.SIGNATORY_OR_DIRECTOR_STATE = SD.ListOfState.ElementAt(rand.Next(0, SD.ListOfState.Count() - 1));
                            personSignatory.NATIONALITY2 = SD.ListOfCountries.ElementAt(rand.Next(0, SD.ListOfCountries.Count() - 1));

                            personSignatory.EMAIL1 = firstName + "@email.com";
                            personSignatory.BVN = rand.Next(100010010, 900000000).ToString() + rand.Next(10, 99).ToString();
                            personSignatory.CCI = rand.Next(202010010, 900000000).ToString() + rand.Next(10, 99).ToString();
                            personSignatory.TIN = "TIN" + rand.Next(1000099, 8500000);


                            // employers info



                            personSignatory.TAX_NUMBER = "TIN" + rand.Next(50000, 90000).ToString();
                            personSignatory.TAX_REG_NUMBER = personSignatory.NATIONALITY1 + "-" + personSignatory.TAX_NUMBER;




                            personSignatory.FIRST_NAME = SD.GenerateName(rand.Next(4, 9));
                            personSignatory.LAST_NAME = SD.GenerateName(rand.Next(3, 7));
                            personSignatory.MIDDLE_NAME = SD.GenerateName(rand.Next(3, 7));

                            DateTime BstartRange = Convert.ToDateTime(rand.Next(1, 10) + "/" + rand.Next(1, 26) + "/" + rand.Next(1967, 1989) + " " + rand.Next(10, 20) + ":10:01");
                            DateTime BendRange = Convert.ToDateTime(rand.Next(1, 10) + "/" + rand.Next(1, 26) + "/" + rand.Next(1990, 2009) + " " + rand.Next(10, 20) + ":10:01");

                            personSignatory.BIRTHDATE = SD.GetRandomDate(BstartRange, BendRange);

                            personSignatory.SSN = rand.Next(100000000, 900000000).ToString() + rand.Next(10, 99).ToString();
                            personSignatory.ID_NUMBER = ctr.TO_PERSON_ID_NUMBER;

                            // phones
                            personSignatory.SIGNATORY_OR_DIRECTOR_TPH_CONTACT_TYPE = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 3)).Description; // has only 4 records
                            personSignatory.SIGNATORY_OR_DIRECTOR_TPH_COMMUNICATION_TYPE = _db.LookupCommunicationType.ToList().ElementAt(rand.Next(0, 6)).Description; // has only 7 records
                            personSignatory.SIGNATORY_OR_DIRECTOR_NUMBER = rand.Next(10000, 30000) + "" + rand.Next(6000, 9000);


                            // addresses
                            personSignatory.SIGNATORY_OR_DIRECTOR_ADDRESS_TYPE = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 3)).Description; // has only 4 records
                            string city = SD.ListOfState.ElementAt(rand.Next(0, SD.ListOfState.Count() - 1));

                            personSignatory.SIGNATORY_OR_DIRECTOR_ADDRESS = rand.Next(0, 500) + "- " + SD.GenerateName(rand.Next(4, 9)) + " " + SD.StreetType.ElementAt(rand.Next(0, SD.StreetType.Count() - 1)) + " - " + city + "- Nigeria";
                            personSignatory.SIGNATORY_OR_DIRECTOR_CITY = city;
                            personSignatory.SIGNATORY_OR_DIRECTOR_ZIP = rand.Next(1001, 9009) + "";
                            personSignatory.SIGNATORY_OR_DIRECTOR_COUNTRY_CODE = SD.ListOfCountries.ElementAt(rand.Next(0, SD.ListOfCountries.Count() - 1));


                            // nationality
                            personSignatory.NATIONALITY1 = SD.ListOfCountries.ElementAt(rand.Next(0, SD.ListOfCountries.Count() - 1));

                            personSignatory.RESIDENCE = SD.ListOfCountries.ElementAt(rand.Next(0, SD.ListOfCountries.Count() - 1));

                            personSignatory.OCCUPATION = SD.ListOfOccupation.ElementAt(rand.Next(0, SD.ListOfOccupation.Count() - 1));

                            personSignatory.SOURCE_OF_WEALTH = SD.ListOfSourceOfWealth.ElementAt(rand.Next(0, 3));
                            



                            _db.TransactionSignatoryOrDirector.Add(personSignatory);
                            // SIGNATORY end


                            // load identification after signatory is added to db so as to get the genetated ID
                            // identification - multiple
                            TransactionPersonIdentification personIdentification = new TransactionPersonIdentification();

                            personIdentification.FOR_SIGNATORY_IDENTIFICATION = true;
                            personIdentification.TRANSACTION_NUMBER = ctr.TRANSACTION_NUMBER;
                            personIdentification.SIGNATORY_OR_DIRECTOR_ID = personSignatory.SIGNATORY_OR_DIRECTOR_ID;

                            personIdentification.TYPE = _db.LookupIdentifierType.ToList().ElementAt(rand.Next(0, 6)).Item; // has only 7 records
                            personIdentification.NUMBER = rand.Next(23456, 76543) + "" + rand.Next(23456, 76543);
                            personIdentification.ISSUE_COUNTRY = SD.ListOfCountries.ElementAt(rand.Next(0, SD.ListOfCountries.Count() - 1));

                            // issue date
                            personIdentification.ISSUE_DATE = SD.GetRandomDate(startRange, endRange);

                            _db.TransactionPersonIdentification.Add(personIdentification);
                            // identification end


                        }

                        ctr.TO_BALANCE = rand.Next(1000000, 9000000);
                        ctr.TO_DATE_BALANCE = homeVM.EndDate;
                        ctr.TO_STATUS_CODE = _db.LookupAccountStatusType.ToList().ElementAt(rand.Next(0, 1)).Description;

                        ctr.TO_BENEFICIARY = SD.GenerateName(rand.Next(3, 8)) + " " + SD.GenerateName(rand.Next(3, 8));
                        DateTime startDateRange = Convert.ToDateTime(rand.Next(1, 10) + "/" + rand.Next(1, 26) + "/" + rand.Next(1967, 1990) + " " + rand.Next(10, 20) + ":10:01");
                        DateTime endDateRange = Convert.ToDateTime(rand.Next(1, 10) + "/" + rand.Next(1, 26) + "/" + rand.Next(1997, 2009) + " " + rand.Next(10, 20) + ":10:01");

                        ctr.TO_OPENED = SD.GetRandomDate(startDateRange, endDateRange);

                        if (homeVM.forFTR)
                        {
                            _db.FTR.Add(ftr);
                        }
                    }
                    else if (homeVM.to.Equals("toperson"))
                    {

                        // t_to->to_person (type t_person)

                        ctr.TO_PERSON_GENDER = SD.Gender.ElementAt(rand.Next(0, SD.Gender.Count() - 1));
                        ctr.TO_PERSON_FIRST_NAME = SD.GenerateName(rand.Next(4, 8));
                        ctr.TO_PERSON_LAST_NAME = SD.GenerateName(rand.Next(4, 8));
                        ctr.TO_PERSON_MIDDLE_NAME = SD.GenerateName(rand.Next(2, 7));

                        DateTime startRange = Convert.ToDateTime(rand.Next(1, 10) + "/" + rand.Next(1, 26) + "/" + rand.Next(1977, 1990) + " " + rand.Next(10, 20) + ":10:01");
                        DateTime endRange = Convert.ToDateTime(rand.Next(1, 10) + "/" + rand.Next(1, 26) + "/" + rand.Next(1997, 2009) + " " + rand.Next(10, 20) + ":10:01");

                        ctr.TO_PERSON_BIRTHDATE = SD.GetRandomDate(startRange, endRange);
                        ctr.TO_PERSON_BIRTH_PLACE = SD.ListOfState[rand.Next(0, 9)];
                        ctr.TO_PERSON_MOTHERS_NAME = SD.GenerateName(rand.Next(4, 7));


                        ctr.TO_PERSON_GENDER = SD.Gender[rand.Next(0, 4)];
                        ctr.TO_PERSON_TITLE = SD.Title[rand.Next(0, 4)];


                        ctr.TO_PERSON_SSN = "SSN" + rand.Next(2000500, 8000500).ToString() + rand.Next(10, 99).ToString();
                        ctr.TO_PERSON_PASSPORT_NUMBER = "NG" + rand.Next(10000000, 80000000).ToString() + rand.Next(10, 99).ToString();
                        ctr.TO_PERSON_PASSPORT_COUNTRY = "NG";
                        ctr.TO_PERSON_ID_NUMBER = "N" + rand.Next(2000000, 8000000).ToString() + rand.Next(10, 99).ToString();
                        ctr.TO_PERSON_TPH_CONTACT_TYPE = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 3)).Description;
                        ctr.TO_PERSON_EMPLOYER_TPH_COMMUNICATION_TYPE = _db.LookupCommunicationType.ToList().ElementAt(rand.Next(0, 3)).Description;
                        ctr.TO_PERSON_COUNTRY_PREFIX = "+234";

                        ctr.TO_PERSON_NUMBER = rand.Next(4000, 9000) + "" + rand.Next(40000, 90000);
                        ctr.TO_PERSON_ADDRESS_TYPE = _db.LookupContactType.ToList().ElementAt(rand.Next(0, 3)).Description;
                        ctr.TO_PERSON_CITY = SD.ListOfState[rand.Next(0, 9)];
                        ctr.TO_PERSON_ADDRESS = rand.Next(0, 500) + "- " + SD.GenerateName(rand.Next(3, 9)) + " " + SD.StreetType.ElementAt(rand.Next(0, SD.StreetType.Count() - 1)) + " - " + ctr.TO_PERSON_CITY + "- Nig";
                        ctr.TO_PERSON_TOWN = SD.ListOfLocalGov[rand.Next(0, 9)];

                        ctr.TO_PERSON_COUNTRY_CODE = "NG";
                        ctr.TO_PERSON_STATE = SD.ListOfState[rand.Next(0, 9)];
                        ctr.TO_PERSON_NATIONALITY1 = "NIG";
                        ctr.TO_PERSON_NATIONALITY2 = "NIG";
                        ctr.TO_PERSON_RESIDENCE = "Home";

                        ctr.TO_PERSON_EMAIL1 = ctr.TO_PERSON_FIRST_NAME + ctr.TO_PERSON_MIDDLE_NAME + "@email.com";
                        ctr.TO_PERSON_EMAIL2 = ctr.TO_PERSON_FIRST_NAME + ctr.TO_PERSON_MIDDLE_NAME + "@email.com";
                        ctr.TO_PERSON_EMAIL3 = ctr.TO_PERSON_FIRST_NAME + ctr.TO_PERSON_MIDDLE_NAME + "@email.com";
                        ctr.FROM_PERSON_OCCUPATION = SD.ListOfOccupation[rand.Next(0, 5)];

                    }


                    _db.CTR.Add(ctr);
                }

                _db.SaveChanges();

            }

            return View(homeVM);
        }




        public IActionResult Privacy()
        {
            Stream result = new MemoryStream();

            using (var source = System.IO.File.OpenRead("Book.xlsx"))
            using (var excel = new OfficeOpenXml.ExcelPackage(result, source))
            {
                ExcelPackage.LicenseContext = LicenseContext.Commercial;

                // Fill cells here
                // Leave headers etc as is

                excel.Save();
            }

            // load excel lookupvalues
            using (var package = new ExcelPackage(new FileInfo("Book.xlsx")))
            {
                ExcelPackage.LicenseContext = LicenseContext.Commercial;

                //        public DbSet<ContactType> LookupContactType { get; set; }
                //public DbSet<CommunicationType> LookupCommunicationType { get; set; }
                //public DbSet<IdentifierType> LookupIdentifierType { get; set; }
                //public DbSet<CountryCodes> LookupCountryCodes { get; set; }
                //public DbSet<ConductionType> LookupConductionType { get; set; }
                //public DbSet<FundsType> LookupFundsType { get; set; }
                //public DbSet<Currencies> LookupCurrencies { get; set; }
                //public DbSet<AccountType> LookupAccountType { get; set; }
                //public DbSet<EntityLegalFormType> LookupEntityLegalFormType { get; set; }
                //public DbSet<AccountStatusType> LookupAccountStatusType { get; set; }



                // CONTACT TYPE
                //ContactType contactType = new ContactType();

                //var firstSheet = package.Workbook.Worksheets["5.9 CONTRACT TYPE"];

                //contactType.Item = firstSheet.Cells["B4"].Text;
                //contactType.Description = firstSheet.Cells["C4"].Text;
                //_db.LookupContactType.Add(contactType);



                //contactType = new ContactType();
                //contactType.Item = firstSheet.Cells["B5"].Text;
                //contactType.Description = firstSheet.Cells["C5"].Text;
                //_db.LookupContactType.Add(contactType);



                //contactType = new ContactType();
                //contactType.Item = firstSheet.Cells["B6"].Text;
                //contactType.Description = firstSheet.Cells["C6"].Text;
                //_db.LookupContactType.Add(contactType);



                //contactType = new ContactType();
                //contactType.Item = firstSheet.Cells["B7"].Text;
                //contactType.Description = firstSheet.Cells["C7"].Text;
                //_db.LookupContactType.Add(contactType);

                //// COMMUNICATION TYPE

                //CommunicationType communicationType = new CommunicationType();

                //var secondSheet = package.Workbook.Worksheets["5.10 COMMUNICATION TYPE"];

                //communicationType.Item = secondSheet.Cells["B4"].Text;
                //communicationType.Description = secondSheet.Cells["C4"].Text;
                //_db.LookupCommunicationType.Add(communicationType);


                //communicationType = new CommunicationType();
                //communicationType.Item = secondSheet.Cells["B5"].Text;
                //communicationType.Description = secondSheet.Cells["C5"].Text;
                //_db.LookupCommunicationType.Add(communicationType);


                //communicationType = new CommunicationType();
                //communicationType.Item = secondSheet.Cells["B6"].Text;
                //communicationType.Description = secondSheet.Cells["C6"].Text;
                //_db.LookupCommunicationType.Add(communicationType);

                //communicationType = new CommunicationType();
                //communicationType.Item = secondSheet.Cells["B7"].Text;
                //communicationType.Description = secondSheet.Cells["C7"].Text;
                //_db.LookupCommunicationType.Add(communicationType);


                //communicationType = new CommunicationType();
                //communicationType.Item = secondSheet.Cells["B8"].Text;
                //communicationType.Description = secondSheet.Cells["C8"].Text;
                //_db.LookupCommunicationType.Add(communicationType);


                //communicationType = new CommunicationType();
                //communicationType.Item = secondSheet.Cells["B9"].Text;
                //communicationType.Description = secondSheet.Cells["C9"].Text;
                //_db.LookupCommunicationType.Add(communicationType);


                //communicationType = new CommunicationType();
                //communicationType.Item = secondSheet.Cells["B10"].Text;
                //communicationType.Description = secondSheet.Cells["C10"].Text;
                //_db.LookupCommunicationType.Add(communicationType);



                //// identifier type
                //IdentifierType identifier = new IdentifierType();

                //var thirdSheet = package.Workbook.Worksheets["5.10 COMMUNICATION TYPE"];

                //identifier.Item = thirdSheet.Cells["B4"].Text;
                //identifier.Description = thirdSheet.Cells["C4"].Text;
                //_db.LookupIdentifierType.Add(identifier);


                //identifier = new IdentifierType();
                //identifier.Item = thirdSheet.Cells["B5"].Text;
                //identifier.Description = thirdSheet.Cells["C5"].Text;
                //_db.LookupIdentifierType.Add(identifier);


                //identifier = new IdentifierType();
                //identifier.Item = thirdSheet.Cells["B6"].Text;
                //identifier.Description = thirdSheet.Cells["C6"].Text;
                //_db.LookupIdentifierType.Add(identifier);


                //identifier = new IdentifierType();
                //identifier.Item = thirdSheet.Cells["B7"].Text;
                //identifier.Description = thirdSheet.Cells["C7"].Text;
                //_db.LookupIdentifierType.Add(identifier);


                //identifier = new IdentifierType();
                //identifier.Item = thirdSheet.Cells["B8"].Text;
                //identifier.Description = thirdSheet.Cells["C8"].Text;
                //_db.LookupIdentifierType.Add(identifier);


                //identifier = new IdentifierType();
                //identifier.Item = thirdSheet.Cells["B9"].Text;
                //identifier.Description = thirdSheet.Cells["C9"].Text;
                //_db.LookupIdentifierType.Add(identifier);



                //identifier = new IdentifierType();
                //identifier.Item = thirdSheet.Cells["B10"].Text;
                //identifier.Description = thirdSheet.Cells["C10"].Text;
                //_db.LookupIdentifierType.Add(identifier);




                //// country codes
                //CountryCodes countryCodes= new CountryCodes();

                //var fourthSheet = package.Workbook.Worksheets["5.14 COUNTRY CODES"];
                //for (int i = 3; i <= 301; i++)
                //{
                //    countryCodes = new CountryCodes();
                //    countryCodes.Value = fourthSheet.Cells["B" + i.ToString()].Text;
                //    countryCodes.Description = fourthSheet.Cells["C" + i.ToString()].Text;
                //    _db.LookupCountryCodes.Add(countryCodes);

                //}



                //// conduction type
                //ConductionType conduction = new ConductionType();

                //var fifthSheet = package.Workbook.Worksheets["5.6 CONDUCTION TYPE"];

                //conduction.Item = fifthSheet.Cells["B4"].Text;
                //conduction.Description = fifthSheet.Cells["C4"].Text;
                //_db.LookupConductionType.Add(conduction);


                //conduction = new ConductionType();
                //conduction.Item = fifthSheet.Cells["B5"].Text;
                //conduction.Description = fifthSheet.Cells["C5"].Text;
                //_db.LookupConductionType.Add(conduction);


                //conduction = new ConductionType();
                //conduction.Item = fifthSheet.Cells["B6"].Text;
                //conduction.Description = fifthSheet.Cells["C6"].Text;
                //_db.LookupConductionType.Add(conduction);


                //conduction = new ConductionType();
                //conduction.Item = fifthSheet.Cells["B7"].Text;
                //conduction.Description = fifthSheet.Cells["C7"].Text;
                //_db.LookupConductionType.Add(conduction);


                //conduction = new ConductionType();
                //conduction.Item = fifthSheet.Cells["B8"].Text;
                //conduction.Description = fifthSheet.Cells["C8"].Text;
                //_db.LookupConductionType.Add(conduction);


                //conduction = new ConductionType();
                //conduction.Item = fifthSheet.Cells["B9"].Text;
                //conduction.Description = fifthSheet.Cells["C9"].Text;
                //_db.LookupConductionType.Add(conduction);


                //// FUNDS TYPE
                //FundsType funds = new FundsType();

                //var sixthSheet = package.Workbook.Worksheets["5.2 FUND TYPE"];

                //funds.Value = sixthSheet.Cells["B4"].Text;
                //funds.Description = sixthSheet.Cells["C4"].Text;
                //_db.LookupFundsType.Add(funds);


                //funds = new FundsType();
                //funds.Value = sixthSheet.Cells["B5"].Text;
                //funds.Description = sixthSheet.Cells["C5"].Text;
                //_db.LookupFundsType.Add(funds);


                //funds = new FundsType();
                //funds.Value = sixthSheet.Cells["B6"].Text;
                //funds.Description = sixthSheet.Cells["C6"].Text;
                //_db.LookupFundsType.Add(funds);


                //funds = new FundsType();
                //funds.Value = sixthSheet.Cells["B7"].Text;
                //funds.Description = sixthSheet.Cells["C7"].Text;
                //_db.LookupFundsType.Add(funds);


                //funds = new FundsType();
                //funds.Value = sixthSheet.Cells["B8"].Text;
                //funds.Description = sixthSheet.Cells["C8"].Text;
                //_db.LookupFundsType.Add(funds);


                //funds = new FundsType();
                //funds.Value = sixthSheet.Cells["B9"].Text;
                //funds.Description = sixthSheet.Cells["C9"].Text;
                //_db.LookupFundsType.Add(funds);


                //funds = new FundsType();
                //funds.Value = sixthSheet.Cells["B10"].Text;
                //funds.Description = sixthSheet.Cells["C10"].Text;
                //_db.LookupFundsType.Add(funds);


                //funds = new FundsType();
                //funds.Value = sixthSheet.Cells["B11"].Text;
                //funds.Description = sixthSheet.Cells["C11"].Text;
                //_db.LookupFundsType.Add(funds);


                //funds = new FundsType();
                //funds.Value = sixthSheet.Cells["B12"].Text;
                //funds.Description = sixthSheet.Cells["C12"].Text;
                //_db.LookupFundsType.Add(funds);


                //funds = new FundsType();
                //funds.Value = sixthSheet.Cells["B13"].Text;
                //funds.Description = sixthSheet.Cells["C13"].Text;
                //_db.LookupFundsType.Add(funds);



                //funds = new FundsType();
                //funds.Value = sixthSheet.Cells["B14"].Text;
                //funds.Description = sixthSheet.Cells["C14"].Text;
                //_db.LookupFundsType.Add(funds);


                //funds = new FundsType();
                //funds.Value = sixthSheet.Cells["B15"].Text;
                //funds.Description = sixthSheet.Cells["C15"].Text;
                //_db.LookupFundsType.Add(funds);


                //funds = new FundsType();
                //funds.Value = sixthSheet.Cells["B16"].Text;
                //funds.Description = sixthSheet.Cells["C16"].Text;
                //_db.LookupFundsType.Add(funds);


                //// CURRENCIES
                //Currencies currency = new Currencies();

                //var seventhSheet = package.Workbook.Worksheets["5.13 CURRENCIES-ENUMERATION"];
                //for(int i = 3; i <= 289; i++)
                //{
                //    currency = new Currencies();
                //    currency.Value = seventhSheet.Cells["B" + i.ToString()].Text;
                //    currency.Description = seventhSheet.Cells["C" + i.ToString()].Text;
                //    _db.LookupCurrencies.Add(currency);
                //}


                //// ACCOUNT TYPE
                //AccountType accountType = new AccountType();

                //var eightSheet = package.Workbook.Worksheets["5.3 ACCOUNT TYPE"];

                //accountType.Item = eightSheet.Cells["B4"].Text;
                //accountType.Description = eightSheet.Cells["C4"].Text;
                //_db.LookupAccountType.Add(accountType);


                //accountType = new AccountType();
                //accountType.Item = eightSheet.Cells["B5"].Text;
                //accountType.Description = eightSheet.Cells["C5"].Text;
                //_db.LookupAccountType.Add(accountType);


                //accountType = new AccountType();
                //accountType.Item = eightSheet.Cells["B6"].Text;
                //accountType.Description = eightSheet.Cells["C6"].Text;
                //_db.LookupAccountType.Add(accountType);


                //accountType = new AccountType();
                //accountType.Item = eightSheet.Cells["B7"].Text;
                //accountType.Description = eightSheet.Cells["C7"].Text;
                //_db.LookupAccountType.Add(accountType);


                //accountType = new AccountType();
                //accountType.Item = eightSheet.Cells["B8"].Text;
                //accountType.Description = eightSheet.Cells["C8"].Text;
                //_db.LookupAccountType.Add(accountType);


                //accountType = new AccountType();
                //accountType.Item = eightSheet.Cells["B9"].Text;
                //accountType.Description = eightSheet.Cells["C9"].Text;
                //_db.LookupAccountType.Add(accountType);


                //accountType = new AccountType();
                //accountType.Item = eightSheet.Cells["B10"].Text;
                //accountType.Description = eightSheet.Cells["C10"].Text;
                //_db.LookupAccountType.Add(accountType);


                //accountType = new AccountType();
                //accountType.Item = eightSheet.Cells["B11"].Text;
                //accountType.Description = eightSheet.Cells["C11"].Text;
                //_db.LookupAccountType.Add(accountType);


                //accountType = new AccountType();
                //accountType.Item = eightSheet.Cells["B12"].Text;
                //accountType.Description = eightSheet.Cells["C12"].Text;
                //_db.LookupAccountType.Add(accountType);


                //accountType = new AccountType();
                //accountType.Item = eightSheet.Cells["B13"].Text;
                //accountType.Description = eightSheet.Cells["C13"].Text;
                //_db.LookupAccountType.Add(accountType);


                //accountType = new AccountType();
                //accountType.Item = eightSheet.Cells["B14"].Text;
                //accountType.Description = eightSheet.Cells["C14"].Text;
                //_db.LookupAccountType.Add(accountType);


                //accountType = new AccountType();
                //accountType.Item = eightSheet.Cells["B15"].Text;
                //accountType.Description = eightSheet.Cells["C15"].Text;
                //_db.LookupAccountType.Add(accountType);





                //// ENTITY LEGAL FORM TYPE
                //EntityLegalFormType legalForm = new EntityLegalFormType();

                //var ninethSheet = package.Workbook.Worksheets["5.11 ENTITYLEGAL FORM"];

                //legalForm.Item = ninethSheet.Cells["B4"].Text;
                //legalForm.Description = ninethSheet.Cells["C4"].Text;
                //_db.LookupEntityLegalFormType.Add(legalForm);


                //legalForm = new EntityLegalFormType();
                //legalForm.Item = ninethSheet.Cells["B5"].Text;
                //legalForm.Description = ninethSheet.Cells["C5"].Text;
                //_db.LookupEntityLegalFormType.Add(legalForm);


                //legalForm = new EntityLegalFormType();
                //legalForm.Item = ninethSheet.Cells["B6"].Text;
                //legalForm.Description = ninethSheet.Cells["C6"].Text;
                //_db.LookupEntityLegalFormType.Add(legalForm);


                //legalForm = new EntityLegalFormType();
                //legalForm.Item = ninethSheet.Cells["B7"].Text;
                //legalForm.Description = ninethSheet.Cells["C7"].Text;
                //_db.LookupEntityLegalFormType.Add(legalForm);



                //// ACCOUNT STATUS TYPE
                //AccountStatusType accountStatus = new AccountStatusType();

                //var tenthSheet = package.Workbook.Worksheets["5.4 ACCOUNT STATUS TYPE"];

                //accountStatus.Item = tenthSheet.Cells["B4"].Text;
                //accountStatus.Description = tenthSheet.Cells["C4"].Text;
                //_db.LookupAccountStatusType.Add(accountStatus);


                //accountStatus = new AccountStatusType();
                //accountStatus.Item = tenthSheet.Cells["B5"].Text;
                //accountStatus.Description = tenthSheet.Cells["C5"].Text;
                //_db.LookupAccountStatusType.Add(accountStatus);


                //accountStatus = new AccountStatusType();
                //accountStatus.Item = tenthSheet.Cells["B6"].Text;
                //accountStatus.Description = tenthSheet.Cells["C6"].Text;
                //_db.LookupAccountStatusType.Add(accountStatus);


                //accountStatus = new AccountStatusType();
                //accountStatus.Item = tenthSheet.Cells["B7"].Text;
                //accountStatus.Description = tenthSheet.Cells["C7"].Text;
                //_db.LookupAccountStatusType.Add(accountStatus);


                //accountStatus = new AccountStatusType();
                //accountStatus.Item = tenthSheet.Cells["B8"].Text;
                //accountStatus.Description = tenthSheet.Cells["C8"].Text;
                //_db.LookupAccountStatusType.Add(accountStatus);

                // country codes
                IndicatorType lookupIndicatortype = new IndicatorType();

                var lastSheet = package.Workbook.Worksheets["5.19 INDICATOR TYPE"];
                for (int i = 4; i <= 449; i++)
                {
                    lookupIndicatortype = new IndicatorType();
                    lookupIndicatortype.Item = lastSheet.Cells["B" + i.ToString()].Text;
                    lookupIndicatortype.Description = lastSheet.Cells["C" + i.ToString()].Text;
                    _db.LookupIndicatorType.Add(lookupIndicatortype);

                }


                _db.SaveChanges();
            }

            return View();
        }


        public async Task<IActionResult> Test()
        {

            // https://stackoverflow.com/questions/10679214/how-do-you-set-the-content-type-header-for-an-httpclient-request
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://sandbox.myidentitypass.com/api/v1/biometrics/merchant/data/verification/voters_card");
            client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "voters_card");
            request.Headers.Add("x-api-key", "test_uxpv0eiqtvb9y6dl5a7nno:3EkOH5xN5Vb6XtQAYG_w1PA5RJk");
            request.Content = new StringContent("{\"state\":\"Lagos\",\"last_name\":\"test\",\"number\":\"987f545AJ67890\"}",
                                                Encoding.UTF8,
                                                "application/json");//CONTENT-TYPE header

            await client.SendAsync(request)
                  .ContinueWith(responseTask =>
                  {
                      System.Diagnostics.Debug.WriteLine("Response: {0}", responseTask.Result);
                  });


            //https://stackoverflow.com/questions/53551361/how-to-add-api-key-in-request-header-using-web-api
            // https://stackoverflow.com/questions/21404734/how-to-add-and-get-header-values-in-webapi?noredirect=1&lq=1
       //     HttpClient httpClient = new HttpClient();
       //     HttpRequestMessage request = new HttpRequestMessage();
       //     request.RequestUri = new Uri("https://sandbox.myidentitypass.com/api/v1/biometrics/merchant/data/wallet/balance");
       //     request.Method = HttpMethod.Get; httpClient.DefaultRequestHeaders
       //.Accept
       //.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

       //     request.Headers.Add("x-api-key", "test_uxpv0eiqtvb9y6dl5a7nno:3EkOH5xN5Vb6XtQAYG_w1PA5RJk");
       //     HttpResponseMessage response = await httpClient.SendAsync(request);
       //     var responseString = await response.Content.ReadAsStringAsync();
       //     var statusCode = response.StatusCode;

            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("https://sandbox.myidentitypass.com/api/v1/biometrics/merchant/data/wallet/balance");
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    client.Method = HttpMethod.Get;
            //    request.Headers.Add("api_key", "1234");

            //    //GET Method
            //    HttpResponseMessage response = await client.GetAsync("api/Department/1");
            //    if (response.IsSuccessStatusCode)
            //    {
            //        string jsonresult = await response.Content.ReadAsStringAsync();

            //        dynamic result = JsonConvert.DeserializeObject(jsonresult);
            //    }
            //    else
            //    {
            //        Console.WriteLine("Internal server Error");
            //    }
            //}

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
