using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeachersrRecordsManagementSystem.Models.Data.TrmsContext;
using TeachersrRecordsManagementSystem.Models.ViewModel;

namespace TeachersrRecordsManagementSystem.Models.Service
{
    public class GenderService
    {
        private trmsContext _Context;

        public GenderService(trmsContext context)
        {
            _Context = context;
        }


        public List<GenderViewModel> GetGender()
        {
            try
            {
                var genders = _Context.Gender.ToList();

                List<GenderViewModel> model = genders.Select(x => new GenderViewModel
                {
                    GenderId = x.GenderId,
                    GenderName = x.GenderName
                }).ToList();

                return model;
            }
            catch (Exception)
            {

                List<GenderViewModel> emptyModel = new List<GenderViewModel>();
                return emptyModel;
            }
        }
    }
}
