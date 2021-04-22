using InvoiceTracking.Data.Contracts;
using InvoiceTracking.Data.DataContext;
using InvoiceTracking.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceTracking.Data.Implementation
{
    public class InvoiceNumberRequestRepository : Repository<InvoiceNumberRequest>, IInvoiceNumberRequestRepository
    {
        private readonly ZeynepInvoiceTrackingContext _ctx;

        public InvoiceNumberRequestRepository(ZeynepInvoiceTrackingContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
