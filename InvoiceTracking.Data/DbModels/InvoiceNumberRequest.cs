using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InvoiceTracking.Data.DbModels
{
    public class InvoiceNumberRequest : BaseEntity
    {
        //---------------------------------------------------------// 

        //Talepte bulunan kullanıcı bilgileri
        public string RequestingInvoiceId { get; set; }
        [ForeignKey("RequestingInvoiceId")]
        public Invoice RequestingInvoice { get; set; }

        //Onaylayan kullanıcı bilgileri
        public string ApprovedInvoiceId { get; set; }
        [ForeignKey("ApprovedInvoiceId")]
        public Invoice ApprovedInvoice { get; set; }


        public int InvoiceNumberTypeId { get; set; }
        [ForeignKey("InvoiceNumberTypeId")]
        public InvoiceNumberType InvoiceNumberType { get; set; }

        //---------------------------------------------------------//
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateRequested { get; set; }
        public string RequestComments { get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
    }
}
