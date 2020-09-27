using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeachersrRecordsManagementSystem.Models.Service;
using TeachersrRecordsManagementSystem.Models.ViewModel;

namespace TeachersrRecordsManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private AdminService _AdminService;
        public AdminController(AdminService adminService)
        {
            _AdminService = adminService;
        }
        // GET: AdminController
        public ActionResult Index()
        {
            var model = _AdminService.GetAdmins();
            return View(model);
        }

        // GET: AdminController/AddAdmin
        public ActionResult AddAdmin()
        {
            return View();
        }

        // POST: AdminController/AddAdmin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAdmin(AdminViewModel model)
        {
            try
            {
                bool result = _AdminService.AddAdmin(model);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }

                throw new Exception();
               
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
