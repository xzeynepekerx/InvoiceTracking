using InvoiceTracking.Common.ResultModels;
using InvoiceTracking.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceTracking.BusinessEngine.Contracts
{
    public interface IInvoiceNumberTypeBusinessEngine
    {
        Result<List <InvoiceNumberType> > GetAllInvoiceNumberTypes();
    }
}
