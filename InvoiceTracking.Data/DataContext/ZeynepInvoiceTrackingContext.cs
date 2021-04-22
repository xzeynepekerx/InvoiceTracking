using InvoiceTracking.Data.DbModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceTracking.Data.DataContext
{
    public class ZeynepInvoiceTrackingContext : IdentityDbContext
    {
        public ZeynepInvoiceTrackingContext(DbContextOptions options) :base(options)
        {

        }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceNumberAllocation> InvoiceNumberAllocations { get; set; }
        public DbSet<InvoiceNumberRequest> InvoiceNumberRequests { get; set; }
        public DbSet<InvoiceNumberType> InvoiceNumberTypes { get; set; }
    }
}
