using Store.Data.Entities.PhoneAggregate;
using Store.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store.EF.Repoditories
{
    public class PhoneRepository : IPhoneRepository
    {
        private readonly PhonesContext _context;

        public PhoneRepository(PhonesContext context)
        {
            _context = context;
        }

        public List<Phone> GetAllPhones()
        {
            return _context.Phones.ToList();
        }
        public Phone GetPhone(int id)
        {
            return _context.Phones.FirstOrDefault(p => p.Id == id);
        }
        public List<Phone> GetAllByName(string name)
        {
            return _context.Phones.Where(c => c.Name == name).ToList();
        }
        public List<Phone> GetAllByModel(string model)
        {
            return _context.Phones.Where(c => c.Model == model).ToList();
        }
        public void DeletePhoneAmount(int id, int amount)
        {
            var phone = GetPhone(id);
            phone.Amount -= amount;
            _context.SaveChanges();
        }
        public void AddPhoneAmount(int id, int amount)
        {
            var phone = GetPhone(id);
            phone.Amount += amount;
            _context.SaveChanges();
        }
    }
}
