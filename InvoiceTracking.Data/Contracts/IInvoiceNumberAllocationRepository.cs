using InvoiceTracking.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceTracking.Data.Contracts
{
    public interface IInvoiceNumberAllocationRepository : IRepositoryBase<InvoiceNumberAllocation> 
    {
    }
}
