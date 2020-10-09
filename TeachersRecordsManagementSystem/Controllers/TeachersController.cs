using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeachersrRecordsManagementSystem.Models.Service;
using TeachersrRecordsManagementSystem.Models.ViewModel;

namespace TeachersrRecordsManagementSystem.Controllers
{
    public class TeachersController : Controller
    {
        private TeachersService _TeachersService;
        int UserNumber;
        public TeachersController(TeachersService teachersService)
        {
            _TeachersService = teachersService;
        }
        
        // GET: TeachersController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("UserID") != null || ReadFromFile() != 0)
            {
                var model = _TeachersService.GetTeachers();
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

           
        }

        // GET: TeachersController/Details/5
        public ActionResult Teacherdetails(int id)
        {
            if (ReadFromFile() != 0)
            {
                var model = _TeachersService.GetTeachersDetails(id);
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }


            
        }

        // GET: TeachersController/Create
        public ActionResult AddTeachers()
        {
            if (HttpContext.Session.GetString("UserID") != null || ReadFromFile() != 0)
            {
                var model = _TeachersService.CreateTeachers();
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
           
        }

        // POST: TeachersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTeachers(TeachersViewModel model)
        {
            try
            {
                if (HttpContext.Session.GetString("UserID") != null || ReadFromFile() != 0)
                {
                    bool result = _TeachersService.AddTeachers(model);
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

        // GET: TeachersController/Edit/5
        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("UserID") != null || ReadFromFile() != 0)
            {
                var model = _TeachersService.GetTeachersDetails(id);
                 return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        // POST: TeachersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TeachersViewModel model)
        {
            try
            {
                if (HttpContext.Session.GetString("UserID") != null || ReadFromFile() != 0)
                {
                    bool result = _TeachersService.UpdateTeachers(model);
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

        // GET: TeachersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TeachersController/Delete/5
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


        public int ReadFromFile()
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory() + "\\errormessage.txt");
            StreamReader sr = new StreamReader(filepath);
            UserNumber = Convert.ToInt32(sr.ReadLine());
            sr.Close();

            return UserNumber;
        }


    }
}
