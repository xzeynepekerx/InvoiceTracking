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
        private readonly IInvoiceNumberTypeBusinessEngine _ınvoiceNumberTypeBusinessEngine;

        public InvoiceNumberTypesController(IInvoiceNumberTypeBusinessEngine ınvoiceNumberTypeBusinessEngine)
        {
            _ınvoiceNumberTypeBusinessEngine = ınvoiceNumberTypeBusinessEngine;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
