using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeachersrRecordsManagementSystem.Models.Data.TrmsContext;
using TeachersrRecordsManagementSystem.Models.ViewModel;

namespace TeachersrRecordsManagementSystem.Models.Service
{
    public class TitleService
    {
        private trmsContext _Context;
        public TitleService(trmsContext context)
        {
            _Context = context;
        }

        public List<TitleViewModel> GetTitles()
        {
            try
            {
                var titles = _Context.Title.ToList();

                List<TitleViewModel> model = titles.Select(x => new TitleViewModel
                {
                    TitleId = x.TitleId,
                    TitleName = x.TitleName
                }).ToList();

                return model;
            }
            catch (Exception)
            {

                List<TitleViewModel> emptymodel = new List<TitleViewModel>();
                return emptymodel;
            }

        }

    }
}
