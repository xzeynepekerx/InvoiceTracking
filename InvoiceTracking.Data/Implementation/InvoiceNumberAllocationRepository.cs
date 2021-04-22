using InvoiceTracking.Data.Contracts;
using InvoiceTracking.Data.DataContext;
using InvoiceTracking.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace InvoiceTracking.Data.Implementation
{
    public class InvoiceNumberAllocationRepository : Repository<InvoiceNumberAllocation>, IInvoiceNumberAllocationRepository
    {
        private readonly ZeynepInvoiceTrackingContext _ctx;


        public InvoiceNumberAllocationRepository(ZeynepInvoiceTrackingContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }


    }
}
