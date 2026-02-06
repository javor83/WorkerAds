using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication6.DatabaseModels;

namespace WebApplication6.Models
{


    /// <summary>
    /// имплементация на IServiceCapability
    /// </summary>
    /// <param name="_service_category"></param>
    /// <param name="_service_wage_tax"></param>
    /// <param name="_context"></param>
    public class ServiceCapability(
       IServiceWorkCategory _service_category,
       IServiceWageTax _service_wage_tax,
       MeisterContext _context) : IServiceCapability
    {


        //****************************************************************************
        DTO_WorkCapability IServiceCapability.EditCapability(int capability_id)
        {
            DTO_WorkCapability result = null;

            var item_cp = _context.WorkerCapabilities.Find(capability_id);
            if (item_cp != null)
            {
                var worker_name = _context.Workers.Find(item_cp.WorkerId);
                result = new DTO_WorkCapability()
                {
                    ID = item_cp.Id,
                    WorkerID = item_cp.WorkerId.Value,
                    CategoryID = item_cp.WorkCategoryId.Value,
                    Price = item_cp.Price.Value,
                    TaxWageID = item_cp.TaxWageId,
                    WorkerName = ToFullName.FullName(worker_name.Fname, worker_name.Lname),
                    ListTaxWage = (this as IServiceCapability).ComboWageTax((this as IServiceCapability).GetWageTax()),
                    ListCategory = (this as IServiceCapability).ComboCategory((this as IServiceCapability).GetCategory())
                };

            }
            else
            {
                result = null;
            }
            return result;
        }
        //****************************************************************************
        async Task IServiceCapability.DeleteCapabilty(int id)
        {
            var item = _context.WorkerCapabilities.Find(id);
            if (item != null)
            {
                _context.WorkerCapabilities.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
        //****************************************************************************

        async Task IServiceCapability.InsertCapability(DTO_WorkCapability sender)
        {
            WorkerCapability wcap = new WorkerCapability()
            {
                WorkerId = sender.WorkerID,
                Price = sender.Price,
                TaxWageId = sender.TaxWageID,
                WorkCategoryId = sender.CategoryID,
            };
            _context.WorkerCapabilities.Add(wcap);
            await _context.SaveChangesAsync();
        }

        //****************************************************************************
        async Task IServiceCapability.UpdateCapability(DTO_WorkCapability sender)
        {
            var cp = _context.WorkerCapabilities.Find(sender.ID);
            if (cp != null)
            {
                cp.TaxWageId = sender.TaxWageID;
                cp.WorkCategoryId = sender.CategoryID;
                cp.Price = sender.Price;
                await _context.SaveChangesAsync();

            }
        }

        //****************************************************************************
        IEnumerable<SelectListItem> IServiceCapability.ComboWageTax(IEnumerable<DTO_WageTax> sender)
        {
            var query = sender.Select
               (
                   x =>
                   new SelectListItem()
                   {
                       Text = x.Name,
                       Value = x.ID.ToString()
                   }
               );
            return query;
        }
        //****************************************************************************
        IEnumerable<SelectListItem> IServiceCapability.ComboCategory(IEnumerable<DTO_WorkCategory> sender)
        {
            var query = sender.Select
            (
                x =>
                new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.ID.ToString()
                }
            );
            return query;
        }


        //****************************************************************************
        IEnumerable<DTO_WageTax> IServiceCapability.GetWageTax()
        {
            return _service_wage_tax.Read();
        }
        //****************************************************************************
        IEnumerable<DTO_WorkCategory> IServiceCapability.GetCategory()
        {
            return _service_category.Read();
        }
        //****************************************************************************
        string IServiceCapability.WorkerName(int worker_id)
        {
            string result = null;

            Worker? item = _context.Workers.Find(worker_id);
            if (item != null)
            {
                result = ToFullName.FullName(item.Fname, item.Lname);
            }

            return result;
        }
        //****************************************************************************
        IEnumerable<DTO_SelectWorkCapability> IServiceCapability.CapalityList(int worker_id)
        {


            IEnumerable<DTO_SelectWorkCapability> result = from worker in _context.Workers

                                                           join capability in _context.WorkerCapabilities
                                                           on worker.Id equals capability.WorkerId

                                                           join tax_wage in _context.TaxWages
                                                           on capability.TaxWageId equals tax_wage.Id

                                                           join work_category in _context.WorkCategories
                                                           on capability.WorkCategoryId equals work_category.Id

                                                           where worker.Id == worker_id
                                                           orderby work_category.Caption
                                                           select
                                                           new DTO_SelectWorkCapability()
                                                           {
                                                               ID = capability.Id,
                                                               TaxWage = tax_wage.Caption,
                                                               Category = work_category.Caption,
                                                               Price = capability.Price
                                                           };




            return result;

        }
        //****************************************************************************
    }
}
