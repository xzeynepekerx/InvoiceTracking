using InvoiceTracking.Data.Contracts;
using InvoiceTracking.Data.DataContext;
using InvoiceTracking.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceTracking.Data.Implementation
{
    public class UnitOfInvoice : IUnitOfInvoice
    {
        private readonly ZeynepInvoiceTrackingContext _ctx;

        public UnitOfInvoice(ZeynepInvoiceTrackingContext ctx) 
        {
            _ctx = ctx;
            InvoiceNumberAllocation =  new InvoiceNumberAllocationRepository (_ctx);
            InvoiceNumberRequestRepository =  new InvoiceNumberRequestRepository (_ctx);
            InvoiceNumberTypeRepository = new InvoiceNumberTypeRepository (_ctx);
        }

        public IInvoiceNumberAllocationRepository InvoiceNumberAllocation { get; private set; }
        public IInvoiceNumberRequestRepository InvoiceNumberRequestRepository { get; private set; }
        public IInvoiceNumberTypeRepository InvoiceNumberTypeRepository { get; private set; }


        public void Save()
        {
            _ctx.SaveChanges();
        } 


        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
