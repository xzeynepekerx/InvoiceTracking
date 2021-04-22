using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceTracking.Common.VModels
{
    public class InvoiceNumberAllocationVM : BaseVM
    { 
            
        public int NumberOfDays { get; set; }
        public DateTime DateCraeted { get; set; }
        public int Period { get; set; }

        public string InvoiceId { get; set; }
        public InvoiceVM InvoiceVm { get; set; }

        public int InvoiceNumberTypeId { get; set; }
        public InvoiceNumberTypeVM InvoiceNumberTypeVm { get; set; }
    }
}

