using System.Collections.Generic;
using Logic.Classes;
using Logic.Interfaces;

namespace Logic.Repositories
{
    public class BankRepository
    {
        private IBankServices _bankServices;

        public BankRepository(IBankServices bankServices)
        {
            _bankServices = bankServices;
        }
        public Bank GetBankById(int id)
        {
           return _bankServices.GetBankById(id);
        }

        public List<Bank> GetBanken()
        {
            return _bankServices.GetBanken();
        }

        public Bank AddBank(Bank bank)
        {
           return _bankServices.AddBank(bank);
        }

        public void EditBank(Bank bank)
        {
            _bankServices.EditBank(bank);
        }

        public void RemoveBank(Bank bank)
        {
           _bankServices.RemoveBank(bank);
        }
    }
}
