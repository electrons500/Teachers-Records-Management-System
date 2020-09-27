using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TeachersRecordsManagementSystem.Models.Service;
using TeachersrRecordsManagementSystem.Models.Data.TrmsContext;
using TeachersrRecordsManagementSystem.Models.ViewModel;

namespace TeachersrRecordsManagementSystem.Models.Service
{
    public class AdminService
    {
        private trmsContext _Context;
        public AdminService(trmsContext context)
        {
            _Context = context;
        }

        public List<AdminViewModel> GetAdmins()
        {
            try
            {
                var Admins = _Context.Admin.ToList();

                List<AdminViewModel> model = Admins.Select(x => new AdminViewModel
                {
                    Surname = x.Surname,
                    Othername = x.Othername,
                    Contact = x.Contact,
                    Email = x.Email,
                    Username = x.Username,
                    Password = x.Password
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                List<AdminViewModel> emptyModel = new List<AdminViewModel>();
                return emptyModel;
            }
        }

        public AdminViewModel GetAdminDetails(int id)
        {
            try
            {
                Admin admin = _Context.Admin.Where(x => x.AdminId == id).FirstOrDefault();
                AdminViewModel model = new AdminViewModel { 
                    Surname = admin.Surname,
                    Othername = admin.Othername,
                    Contact = admin.Contact,
                    Email = admin.Email,
                    Username = admin.Username,
                    Password = admin.Password
                
                };

                return model;
            }
            catch (Exception)
            {
                AdminViewModel emptyModel = new AdminViewModel();
                return emptyModel;
               
            }
        }


        public bool AddAdmin(AdminViewModel model)
        {
            try
            {
                Admin admin = new Admin
                {
                    Surname = model.Surname,
                    Othername = model.Othername,
                    Contact = model.Contact,
                    Email = model.Email,
                    Username = model.Username,
                    Password = EncryptData.MD5Encryption(model.Password)
                };

                _Context.Admin.Add(admin);
                _Context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }


    
    }
}

