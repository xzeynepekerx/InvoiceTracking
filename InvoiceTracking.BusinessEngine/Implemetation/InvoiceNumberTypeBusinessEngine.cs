using InvoiceTracking.BusinessEngine.Contracts;
using InvoiceTracking.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceTracking.BusinessEngine.Implemetation
{
    public class InvoiceNumberTypeBusinessEngine : IInvoiceNumberTypeBusinessEngine
    {
        private readonly IUnitOfInvoice _UnitOfInvoice;

        public InvoiceNumberTypeBusinessEngine(IUnitOfInvoice UnitOfInvoice)
        {
            _UnitOfInvoice = UnitOfInvoice;
        }
    }
}
