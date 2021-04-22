using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceTracking.Data.DbModels
{
    public class InvoiceNumberType : BaseEntity
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
