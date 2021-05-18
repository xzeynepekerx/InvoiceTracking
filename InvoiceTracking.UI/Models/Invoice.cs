using System;
using System.Collections.Generic;

namespace InvoiceTracking.UI.Models
{
    public class Invoice
    {
        public string InvoiceNo { get; set; }
        public string NameSurname { get; set; }
        public string Tc { get; set; }
        public string SubscriberNo { get; set; }
        public string Address { get; set; }
        public short InvoiceType { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal Price { get; set; }
        public string InvoiceStatus { get; set; }
        public string InvoiceStatusText { get; set; }
    }
}
