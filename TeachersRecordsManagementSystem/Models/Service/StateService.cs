using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeachersrRecordsManagementSystem.Models.Data.TrmsContext;
using TeachersrRecordsManagementSystem.Models.ViewModel;

namespace TeachersrRecordsManagementSystem.Models.Service
{
    public class StateService
    {
        private trmsContext _Context;
        public StateService(trmsContext context)
        {
            _Context = context;
        }

        public List<StateViewModel> GetStates()
        {
            try
            {
                var states = _Context.State.ToList();
                List<StateViewModel> model = states.Select(x => new StateViewModel
                {
                    StateId = x.StateId,
                    StateName = x.StateName
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                List<StateViewModel> emptyModel = new List<StateViewModel>();
                return emptyModel;
            }
        }
    }
}
