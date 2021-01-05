using Store.Data.Entities.PhoneAggregate;
using Store.Data.Repositories;
using Store.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store.Domain.DefaultImplementations
{
    public class PhoneService : IPhoneService
    {
        private IPhoneRepository _phoneRepository;
        public PhoneService(IPhoneRepository phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        public List<Phone> GetAllByQuery(string text)
        {
            string[] input = text.Split(' ');
            var result = new List<Phone>();
           
            var items = _phoneRepository.GetAllByName(input[0]);

            if (items.Count > 0 && input.Length > 1)
            {
                result.AddRange(items.Where(x => x.Model == input[1]));
            }
            else if(items.Count == 0)
            {
                result.AddRange(_phoneRepository.GetAllByModel(input[0]));
            }
            else
            {
                result.AddRange(items);
            }     

            return result;
        }
    }
}
