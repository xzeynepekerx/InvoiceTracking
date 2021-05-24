using AutoMapper;
using InvoiceTracking.Common.VModels;
using InvoiceTracking.Data.DbModels;

namespace InvoiceTracking.Common.Maps
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<InvoiceNumberType, InvoiceNumberTypeVM>().ReverseMap();
            CreateMap<InvoiceNumberAllocation, InvoiceNumberAllocationVM>().ReverseMap();
            CreateMap<InvoiceNumberRequest, InvoiceNumberRequestVM>().ReverseMap();
            CreateMap<Invoice, InvoiceVM>().ReverseMap();
        }
    }
}
