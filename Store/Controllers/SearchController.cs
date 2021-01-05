using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Data.Repositories;
using Store.Domain.Interfaces;

namespace Store.Controllers
{
    public class SearchController : Controller
    {
        private IPhoneService _phoneService;

        public SearchController(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }

        public IActionResult Index(string query)
        {
            var phones = _phoneService.GetAllByQuery(query);
            
            return View(phones);
        }
    }
}
