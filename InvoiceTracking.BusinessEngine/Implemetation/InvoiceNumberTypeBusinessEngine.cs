using AutoMapper;
using InvoiceTracking.BusinessEngine.Contracts;
using InvoiceTracking.Common.ConstansModels;
using InvoiceTracking.Common.ResultModels;
using InvoiceTracking.Common.VModels;
using InvoiceTracking.Data.Contracts;
using InvoiceTracking.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvoiceTracking.BusinessEngine.Implemetation
{
    public class InvoiceNumberTypeBusinessEngine : IInvoiceNumberTypeBusinessEngine
    {

        #region Variables
        private readonly IUnitOfInvoice _UnitOfInvoice;
        private readonly IMapper _mapper;
        #endregion


        #region Constructor

        public InvoiceNumberTypeBusinessEngine(IUnitOfInvoice UnitOfInvoice,IMapper mapper)
        {
            _UnitOfInvoice = UnitOfInvoice;
            _mapper = mapper;        }
        #endregion

        #region CustomMethods
        public Result<List<InvoiceNumberTypeVM>> GetAllInvoiceNumberTypes()
        {
            var data = _UnitOfInvoice.InvoiceNumberTypeRepository.GetAll().ToList();

            #region 1.yöntem
            //    if (data != null)
            //    {
            //        List<InvoiceNumberType> returnData = new List<InvoiceNumberType>();

            //        foreach (var item in data)
            //        {
            //            returnData.Add(new InvoiceNumberType()
            //            {
            //                Id = item.Id,
            //                DateCreated = item.DateCreated,
            //                DefaultDays = item.DefaultDays,
            //                Name = item.Name
            //            });
            //        }
            //        return new Result<List<InvoiceNumberType>>(true, ResultConstant.RecordFound, returnData);
            //    }
            //    else
            //        return new Result<List<InvoiceNumberType>>(false , ResultConstant.RecordNotFound);

            #endregion


            #region 2. yöntem
            var numberTypes = _mapper.Map<List<InvoiceNumberType>, List<InvoiceNumberTypeVM>>(data);
            return new Result<List<InvoiceNumberTypeVM>>(true, ResultConstant.RecordFound, numberTypes);
        }

        Result<List<InvoiceNumberType>> IInvoiceNumberTypeBusinessEngine.GetAllInvoiceNumberTypes()
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
