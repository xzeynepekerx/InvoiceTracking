using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceTracking.Data.Contracts
{
    public interface IUnitOfInvoice : IDisposable
    {
        IInvoiceNumberAllocationRepository InvoiceNumberAllocation { get; }
        IInvoiceNumberRequestRepository InvoiceNumberRequestRepository { get; }
        IInvoiceNumberTypeRepository InvoiceNumberTypeRepository { get; }
        void Save();
    }
}
