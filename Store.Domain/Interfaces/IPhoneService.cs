using Store.Data.Entities.PhoneAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain.Interfaces
{
    public interface IPhoneService
    {
        List<Phone> GetAllByQuery(string query);
    }
}
