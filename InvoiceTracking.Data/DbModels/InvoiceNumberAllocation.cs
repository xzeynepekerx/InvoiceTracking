using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InvoiceTracking.Data.DbModels
{
    public class InvoiceNumberAllocation : BaseEntity
    {
        public int NumberOfDays { get; set; }
        public DateTime DateCraeted { get; set; }
        public int Period { get; set; }

        public string InvoiceId { get; set; }
        [ForeignKey("InvoiceId")]
        public Invoice Invoice { get; set; }

        public int InvoiceNumberTypeId { get; set; }
        [ForeignKey("InvoiceNumberTypeId")]
        public InvoiceNumberType InvoiceNumberType { get; set; }
    }
}
