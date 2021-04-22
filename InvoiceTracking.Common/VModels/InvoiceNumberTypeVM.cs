using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InvoiceTracking.Common.VModels
{
    public class InvoiceNumberTypeVM : BaseVM
    { 
        [Required]
        public string Name { get; protected set; }
        public int DefaultDays { get; protected set; }
        public DateTime DateCreated { get; protected set; }


        //MVVM Create InvoiceType
        public void SetInvoiceType(string name)
        {
            this.Name = name;
        }


    }
}
