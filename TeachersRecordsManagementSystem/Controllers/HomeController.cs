using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TeachersRecordsManagementSystem.Models.Service;
using TeachersrRecordsManagementSystem.Models;
using TeachersrRecordsManagementSystem.Models.Data.TrmsContext;
using TeachersrRecordsManagementSystem.Models.ViewModel;

namespace TeachersrRecordsManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private trmsContext _Context;
        int UserNumber;
        public HomeController(trmsContext context)
        {
            _Context = context;
          
        }

        public IActionResult Index()
        {


            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
       public IActionResult Login(AdminViewModel admin)
        {
            var password = EncryptData.MD5Encryption(admin.Password);
            

            var AdminAccount = _Context.Admin.Where(x => x.Username == admin.Username && x.Password == password).FirstOrDefault();
            if(AdminAccount != null)
            {
                HttpContext.Session.SetString("UserID", AdminAccount.AdminId.ToString());
                HttpContext.Session.SetString("Username", AdminAccount.Username.ToString());
                WriteToFile(AdminAccount.AdminId.ToString());

                return RedirectToAction("Welcome");
            }
            else
            {
                ModelState.AddModelError("", "Username or password is wrong");
            }
            
            
            return View();
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            WriteToFile("0");
            return RedirectToAction("Index");
        }

        public IActionResult Welcome()
        {
                     
            if (HttpContext.Session.GetString("UserID") != null || ReadFromFile() != 0)
            {
                ViewBag.Username = HttpContext.Session.GetString("Username");
                ViewBag.CountTeachers = _Context.Teachers.Count();
                ViewBag.CountBanks = _Context.Banks.Count();
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public void WriteToFile(string input)
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory() + "\\errormessage.txt");
            StreamWriter sw = new StreamWriter(filepath);
            sw.WriteLine(input);
            sw.Close();


        }

        public int ReadFromFile()
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory() + "\\errormessage.txt");
            StreamReader sr = new StreamReader(filepath);
            UserNumber = Convert.ToInt32(sr.ReadLine());
            sr.Close();
            return UserNumber;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
