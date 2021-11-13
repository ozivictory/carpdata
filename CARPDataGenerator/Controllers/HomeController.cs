using CARPDataGenerator.Data;
using CARPDataGenerator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        public IActionResult Index(HomeViewModel homeVM)
        {
            

            if (ModelState.IsValid)
            {
                for(int i = 0; i < homeVM.NoOfrecords; i++)
                {
                    CTR ctr = new CTR();

                    // generate code
                    ctr.CODE_FROM_TRANS = homeVM.codefromtrans;
                    ctr.TRANSACTION_NUMBER = SD.GenerateTransCode(homeVM.codefromtrans);
                    ctr.TRANSACTION_DESCRIPTION = homeVM.codefromtrans.ToUpper() + ":" + ctr.TRANSACTION_NUMBER;

                    Random rand = new Random();
                    
                    ctr.TRANSACTION_LOCATION = SD.ListOfState[rand.Next(0, 19)];
                    ctr.TRANSACTION_DATE = SD.GetRandomDate(homeVM.StartDate, homeVM.EndDate);

                }

                // from
                if (homeVM.from.Equals("fromaccount"))
                {

                }else if (homeVM.from.Equals("frommyclientaccount"))
                {

                }
                else if (homeVM.from.Equals("fromperson"))
                {

                }
                else if (homeVM.from.Equals("frommyclientperson"))
                {

                }
                else if (homeVM.from.Equals("fromentity"))
                {

                }
                else if (homeVM.from.Equals("frommycliententity"))
                {

                }
                

                // to

            }

            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
