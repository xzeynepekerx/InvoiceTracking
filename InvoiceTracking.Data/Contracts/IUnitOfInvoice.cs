using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceTracking.Data.Contracts
{
    public interface IUnitOfInvoice : IDisposable
    {
        void Save();
    }
}
