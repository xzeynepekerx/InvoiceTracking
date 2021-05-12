using InvoiceTracking.BusinessEngine.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceTracking.UI.Controllers
{
    public class InvoiceNumberTypesController : Controller
    {
        private readonly IInvoiceNumberTypeBusinessEngine _InvoiceNumberTypeBusinessEngine;

        public InvoiceNumberTypesController(IInvoiceNumberTypeBusinessEngine ınvoiceNumberTypeBusinessEngine)
        {
            _InvoiceNumberTypeBusinessEngine = ınvoiceNumberTypeBusinessEngine;
        }

        public IActionResult Index()
        {
            var data = _InvoiceNumberTypeBusinessEngine.GetAllInvoiceNumberTypes();
            if (data.IsSuccess)
            {
                var result = data.Data;
                return View(result);
            }
            return View();
        }
    }
}
