using Store.Data.Entities.PhoneAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Data.Repositories
{
    public interface IPhoneRepository
    {
        List<Phone> GetAllPhones();
        List<Phone> GetAllByName(string name);
        List<Phone> GetAllByModel(string model);
        Phone GetPhone(int id);
        void DeletePhoneAmount(int id, int amount);
        void AddPhoneAmount(int id, int amount);
    }
}
