using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TeachersrRecordsManagementSystem.Models.Data.TrmsContext;
using TeachersrRecordsManagementSystem.Models.ViewModel;

namespace TeachersrRecordsManagementSystem.Models.Service
{
    public class TeachersService
    {
        private trmsContext _Context;
        private BankService _BankService;
        private GenderService _GenderService;
        private MaritalStatusService _MaritalStatusService;
        private StateService _StateService;
        private TitleService _TitleService;
        public TeachersService(trmsContext context, BankService bankService, GenderService genderService, MaritalStatusService maritalStatusService, StateService stateService, TitleService titleService)
        {
            _Context = context;
            _BankService = bankService;
            _GenderService = genderService;
            _MaritalStatusService = maritalStatusService;
            _StateService = stateService;
            _TitleService = titleService;

        }

        public TeachersViewModel CreateTeachers()
        {
            TeachersViewModel model = new TeachersViewModel
            {
                BankList = new SelectList(_BankService.GetBanks(), "BankId", "BankName"),
                GenderList = new SelectList(_GenderService.GetGender(), "GenderId", "GenderName"),
                MaritalList = new SelectList(_MaritalStatusService.GetMaritalStatus(), "MaritalId", "MaritalStatusName"),
                StateList = new SelectList(_StateService.GetStates(), "StateId", "StateName"),
                TitleList = new SelectList(_TitleService.GetTitles(), "TitleId", "TitleName")
            };

            return model;
        }


        public List<TeachersViewModel> GetTeachers()
        {
            var teachers = _Context.Teachers.Include(x => x.Bank)
                                            .Include(x => x.Gender)
                                            .Include(x => x.Marital)
                                            .Include(x => x.State)
                                            .Include(x => x.Title)
                                            .ToList();
            List<TeachersViewModel> model = teachers.Select(x => new TeachersViewModel
            {
                TeacherId = x.TeacherId,
                TitleId = x.TitleId,
                Surname = x.Surname,
                Othernames = x.Othernames,
                FullName = $"{x.Title.TitleName} {x.Surname} {x.Othernames} ",
                BirthDate = x.BirthDate,
                GenderId = x.GenderId,
                GenderName = x.Gender.GenderName,
                Contact = x.Contact,
                StateId = x.StateId,
                StateName = x.State.StateName,
                ImageName = x.ImageName
               

            }).ToList();

            return model;
        }

        public TeachersViewModel GetTeachersDetails(int id)
        {
            try
            {
                Teachers teachers = _Context.Teachers.Where(x => x.TeacherId == id).Include(x => x.Bank)
                                                                                   .Include(x => x.Gender)
                                                                                   .Include(x => x.Marital)
                                                                                   .Include(x => x.State)
                                                                                   .Include(x => x.Title)
                                                                                   .FirstOrDefault();
                TeachersViewModel model = new TeachersViewModel
                {
                    TeacherId = teachers.TeacherId,
                    TitleId = teachers.TitleId,
                    TitleName = teachers.Title.TitleName,
                    TitleList = new SelectList(_Context.Title, "TitleId", "TitleName", teachers.Title.TitleId),
                    Surname = teachers.Surname,
                    Othernames = teachers.Othernames,
                    BirthDate = teachers.BirthDate,
                    GenderId = teachers.GenderId,
                    GenderName = teachers.Gender.GenderName,
                    GenderList = new SelectList(_Context.Gender, "GenderId", "GenderName", teachers.Gender.GenderId),
                    Hometown = teachers.Hometown,
                    Contact = teachers.Contact,
                    MaritalId = teachers.MaritalId,
                    MaritalStatusName = teachers.Marital.MaritalStatusName,
                    MaritalList = new SelectList(_Context.MaritalStatus, "MaritalId", "MaritalStatusName", teachers.Marital.MaritalId),
                    AcademicQualification = teachers.AcademicQualification,
                    ProfessionalQualification = teachers.ProfessionalQualification,
                    StaffId = teachers.StaffId,
                    RegisteredNumber = teachers.RegisteredNumber,
                    Ssfno = teachers.Ssfno,
                    BankId = teachers.BankId,
                    BankName = teachers.Bank.BankName,
                    BankList = new SelectList(_Context.Banks, "BankId", "BankName", teachers.Bank.BankId),
                    AccountName = teachers.AccountName,
                    FirstAppointmentDate = teachers.FirstAppointmentDate,
                    StateId = teachers.StateId,
                    StateList = new SelectList(_Context.State, "StateId", "StateName", teachers.State.StateId),
                    ImageName = teachers.ImageName

                };


                return model;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public bool AddTeachers(TeachersViewModel model)
        {
            try
            {

                string UserImageName = UploadedFile(model);
                Teachers teachers = new Teachers
                {
                    TitleId = model.TitleId,
                    Surname = model.Surname,
                    Othernames = model.Othernames,
                    BirthDate = model.BirthDate,
                    GenderId = model.GenderId,
                    Hometown = model.Hometown,
                    Contact = model.Contact,
                    MaritalId = model.MaritalId,
                    AcademicQualification = model.AcademicQualification,
                    ProfessionalQualification = model.ProfessionalQualification,
                    StaffId = model.StaffId,
                    RegisteredNumber = model.RegisteredNumber,
                    Ssfno = model.Ssfno,
                    BankId = model.BankId,
                    AccountName = model.AccountName,
                    FirstAppointmentDate = model.FirstAppointmentDate,
                    StateId = model.StateId,
                    ImageName = UserImageName


                };

                _Context.Teachers.Add(teachers);
                _Context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string UploadedFile(TeachersViewModel model)
        {
            string NewFileName = null;

            if (model.TeacherImage != null)
            {

                NewFileName = Guid.NewGuid().ToString() + "_" + model.TeacherImage.FileName;
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\userImages", NewFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.TeacherImage.CopyTo(fileStream);
                }
            }
            return NewFileName;
        }


        public bool UpdateTeachers(TeachersViewModel model)
        {
            Teachers teachers = _Context.Teachers.Where(x => x.TeacherId == model.TeacherId).Include(x => x.Bank)
                                                                                           .Include(x => x.Gender)
                                                                                           .Include(x => x.Marital)
                                                                                           .Include(x => x.State)
                                                                                           .Include(x => x.Title)
                                                                                           .FirstOrDefault();
            teachers.TeacherId = model.TeacherId;
            teachers.TitleId = model.TitleId;
            teachers.Surname = model.Surname;
            teachers.Othernames = model.Othernames;
            teachers.BirthDate = model.BirthDate;
            teachers.GenderId = model.GenderId;
            teachers.Hometown = model.Hometown;
            teachers.Contact = model.Contact;
            teachers.MaritalId = model.MaritalId;
            teachers.AcademicQualification = model.AcademicQualification;
            teachers.ProfessionalQualification = model.ProfessionalQualification;
            teachers.StaffId = model.StaffId;
            teachers.RegisteredNumber = model.RegisteredNumber;
            teachers.Ssfno = model.Ssfno;
            teachers.BankId = model.BankId;
            teachers.AccountName = model.AccountName;
            teachers.FirstAppointmentDate = model.FirstAppointmentDate;
            teachers.StateId = model.StateId;


            _Context.Teachers.Update(teachers);
            _Context.SaveChanges();

            return true;
        }


    }
}
