using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeachersrRecordsManagementSystem.Models.Data.TrmsContext;
using TeachersrRecordsManagementSystem.Models.ViewModel;

namespace TeachersrRecordsManagementSystem.Models.Service
{
    public class MaritalStatusService
    {
        private trmsContext _Context;
        public MaritalStatusService(trmsContext context)
        {
            _Context = context;
        }

        public List<MaritalStatusViewModel> GetMaritalStatus()
        {
            try
            {
                var maritalstatus = _Context.MaritalStatus.ToList();
                List<MaritalStatusViewModel> model = maritalstatus.Select(x => new MaritalStatusViewModel
                {
                    MaritalId = x.MaritalId,
                    MaritalStatusName = x.MaritalStatusName
                }).ToList();

                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
