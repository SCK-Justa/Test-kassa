using System.Collections.Generic;
using Logic.Classes;

namespace Logic.Interfaces
{
    public interface IBankServices
    {
        Bank GetBankById(int id);
        List<Bank> GetBanken();
        void AddBank(Bank bank);
        void EditBank(Bank bank);
        void RemoveBank(Bank bank);
    }
}
