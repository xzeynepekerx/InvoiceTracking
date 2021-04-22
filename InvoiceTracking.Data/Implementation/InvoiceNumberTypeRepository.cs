using InvoiceTracking.Data.Contracts;
using InvoiceTracking.Data.DataContext;
using InvoiceTracking.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceTracking.Data.Implementation
{
    public class InvoiceNumberTypeRepository : Repository<InvoiceNumberType>, IInvoiceNumberTypeRepository
    {
        private readonly ZeynepInvoiceTrackingContext _ctx;

        public InvoiceNumberTypeRepository(ZeynepInvoiceTrackingContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
