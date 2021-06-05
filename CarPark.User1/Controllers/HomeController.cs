using CarPark.User.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using System.Resources;
using System.Reflection;



namespace CarPark.User.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IStringLocalizer<HomeController> _localizer;
        public HomeController(IStringLocalizer<HomeController> localizer, ILogger<HomeController> logger)
        {
            _localizer = localizer;
            _logger = logger;
        }

        public IActionResult Index()
        {
            #region MongoDB Veri Gönderme
            //var client = new MongoClient("mongodb+srv://oguzhancolak22:carpark@carparkcluster.m9jcz.mongodb.net/CarParkDB?retryWrites=true&w=majority");
            //var database = client.GetDatabase("CarParkDB");
            //var collection = database.GetCollection<Test>("Test");

            //var test = new Test()
            //{
            //    _Id = ObjectId.GenerateNewId(),
            //    NameSurname = "Ali Çolak",
            //    Age = 55,
            //    AdresssList = new List<Adress>
            //    {
            //        new Adress
            //        { Title="Ev Adresi", Description = "Merkez/Edirne" },

            //        new Adress
            //        { Title="İş Yeri Adresi", Description = "Herhangi bir yer  Merkez/Edirne" }
            //    }
            //};

            //collection.InsertOne(test); 
            #endregion

            #region Log Mesaj
            //_logger.LogInformation("İlk log denemesi");
            //_logger.LogError("Hata!!!");
            #endregion

            #region Log'a Değer Gönderme
            var customer = new Customer
            {
                Id = 1,
                Age = 22,
                NameSurname = "Oğuzhan Çolak"
            };

            //_logger.LogError("Customer'da bir hata oluştu {@customer}", customer);
            #endregion

            //var say_Hello_valuTR = _localizer["Say_Hello"];

            //var cultureInfo = CultureInfo.GetCultureInfo("en-US");
            //Thread.CurrentThread.CurrentCulture = cultureInfo;
            //Thread.CurrentThread.CurrentUICulture = cultureInfo;

            //var say_Hello_valueEN = _localizer["Say_Hello"];


            return View();
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
