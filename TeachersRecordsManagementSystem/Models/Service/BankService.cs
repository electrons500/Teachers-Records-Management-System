using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeachersrRecordsManagementSystem.Models.Data.TrmsContext;
using TeachersrRecordsManagementSystem.Models.ViewModel;

namespace TeachersrRecordsManagementSystem.Models.Service
{
    public class BankService
    {
        private trmsContext _Context;
        public BankService(trmsContext context)
        {
            _Context = context;

        }

        public List<BankViewModel> GetBanks()
        {
            try
            {
                var banks = _Context.Banks.ToList();

                List<BankViewModel> model = banks.Select(x => new BankViewModel
                {
                    BankId = x.BankId,
                    BankName = x.BankName
                }).ToList();

                return model;
            }
            catch (Exception)
            {

                List<BankViewModel> emptyModel = new List<BankViewModel>();
                return emptyModel;
            }
        }


        public BankViewModel GetBankDetails(int id)
        {
            Banks banks = _Context.Banks.Where(x => x.BankId == id).FirstOrDefault();
            BankViewModel model = new BankViewModel
            {
                BankId = banks.BankId,
                BankName = banks.BankName
            };

            return model;
        }


        public bool AddBanks(BankViewModel model)
        {
            try
            {
                Banks banks = new Banks
                {
                    BankName = model.BankName
                };

                _Context.Banks.Add(banks);
                _Context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateBanks(BankViewModel model)
        {
            try
            {
                Banks banks = _Context.Banks.Where(x => x.BankId == model.BankId).FirstOrDefault();
              
                banks.BankName = model.BankName;

                _Context.Banks.Update(banks);
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
