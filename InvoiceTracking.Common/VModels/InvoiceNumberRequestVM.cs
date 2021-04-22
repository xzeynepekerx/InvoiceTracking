using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InvoiceTracking.Common.VModels
{
    public class InvoiceNumberRequestVM : BaseVM
    {
        public string RequestingInvoiceId { get; set; }
        public InvoiceVM RequestingInvoice { get; set; }


        public string ApprovedInvoiceId { get; set; }
        public InvoiceVM ApprovedInvoice { get; set; }


        public int InvoiceNumberTypeId { get; set; }
        public InvoiceNumberTypeVM InvoiceNumberType { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DateRequested { get; set; }

        [Display(Name = "Talep Açıklama")]
        [MaxLength(300,ErrorMessage = "300 karakterden fazla değere girilemez")]
        public string RequestComments { get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
    }
}
