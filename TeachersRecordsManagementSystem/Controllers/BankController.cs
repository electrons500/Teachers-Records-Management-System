using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeachersrRecordsManagementSystem.Models.Data.TrmsContext;
using TeachersrRecordsManagementSystem.Models.Service;
using TeachersrRecordsManagementSystem.Models.ViewModel;

namespace TeachersrRecordsManagementSystem.Controllers
{
    public class BankController : Controller
    {
        private BankService _BankService;
        public BankController( BankService bankService)
        {
            _BankService = bankService;
        }
        
        
        // GET: BankController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("UserID") != null)
            {
                var model = _BankService.GetBanks();
                return View(model);
            }
            else
            {
                return RedirectToAction("Login","Home");
            }


           
        }

        // GET: BankController/Details/5
        public ActionResult Details(int id)
        {
          
            
            return View();
        }

        // GET: BankController/Create
        public ActionResult Addbanks()
        {
            if (HttpContext.Session.GetString("UserID") != null)
            {
               
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

           
        }

        // POST: BankController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Addbanks(BankViewModel model)
        {
            try
            {
                if (HttpContext.Session.GetString("UserID") != null)
                {
                    bool result = _BankService.AddBanks(model);
                    if (result)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
               

                throw new Exception();
                
            }
            catch
            {
                return View();
            }
        }

        // GET: BankController/Edit/5
        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("UserID") != null)
            {
                var model = _BankService.GetBankDetails(id);
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
           
        }

        // POST: BankController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BankViewModel model)
        {
            try
            {
                if (HttpContext.Session.GetString("UserID") != null)
                {
                    bool result = _BankService.UpdateBanks(model);
                    if (result)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
                throw new Exception();

            }
            catch
            {
                return View();
            }
        }
       

    }
}
