using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication6.Interfaces;

using WebApplication6.ExtensionMethods;
using WebApplication6.Models;
using WebApplication6.Data;

namespace WebApplication6.Services
{
    /// <summary>
    /// имплементация на ICapabilityService
    /// </summary>
    /// <param name="_service_category"></param>
    /// <param name="_service_wage_tax"></param>
    /// <param name="_context"></param>
    public class CapabilityService(
       IWorkCategoryService _service_category,
       IWageTaxService _service_wage_tax,
       MeisterContext _context) : ICapabilityService
    {


        //****************************************************************************
        WorkCapability ICapabilityService.EditCapability(int capability_id)
        {
            WorkCapability result = null;

            var item_cp = _context.WorkerCapabilities.Find(capability_id);
            if (item_cp != null)
            {
                var worker_name = _context.Workers.Find(item_cp.WorkerId);
                result = new WorkCapability()
                {
                    ID = item_cp.Id,
                    WorkerID = item_cp.WorkerId.Value,
                    CategoryID = item_cp.WorkCategoryId.Value,
                    Price = item_cp.Price.Value,
                    TaxWageID = item_cp.TaxWageId,
                    WorkerName = worker_name.Fname.IncludeLastName(worker_name.Lname),
                    ListTaxWage = (this as ICapabilityService).ComboWageTax((this as ICapabilityService).GetWageTax()),
                    ListCategory = (this as ICapabilityService).ComboCategory((this as ICapabilityService).GetCategory())
                };

            }
            else
            {
                result = null;
            }
            return result;
        }
        //****************************************************************************
        async Task ICapabilityService.DeleteCapabilty(int id)
        {
            var item = _context.WorkerCapabilities.Find(id);
            if (item != null)
            {
                _context.WorkerCapabilities.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
        //****************************************************************************

        async Task ICapabilityService.InsertCapability(WorkCapability sender)
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
        async Task ICapabilityService.UpdateCapability(WorkCapability sender)
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
        IEnumerable<SelectListItem> ICapabilityService.ComboWageTax(IEnumerable<WageTax> sender)
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
        IEnumerable<SelectListItem> ICapabilityService.ComboCategory(IEnumerable<Models.TaxCategory> sender)
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
        IEnumerable<WageTax> ICapabilityService.GetWageTax()
        {
            return _service_wage_tax.Read();
        }
        //****************************************************************************
        IEnumerable<Models.TaxCategory> ICapabilityService.GetCategory()
        {
            return _service_category.Read();
        }
        //****************************************************************************
        string ICapabilityService.WorkerName(int worker_id)
        {
            string result = null;

            Worker? item = _context.Workers.Find(worker_id);
            if (item != null)
            {
                result = item.Fname.IncludeLastName(item.Lname);
            }

            return result;
        }
        //****************************************************************************
        IEnumerable<SelectWorkCapability> ICapabilityService.CapalityList(int worker_id)
        {


            IEnumerable<SelectWorkCapability> result = from worker in _context.Workers

                                                           join capability in _context.WorkerCapabilities
                                                           on worker.Id equals capability.WorkerId

                                                           join tax_wage in _context.TaxWages
                                                           on capability.TaxWageId equals tax_wage.Id

                                                           join work_category in _context.WorkCategories
                                                           on capability.WorkCategoryId equals work_category.Id

                                                           where worker.Id == worker_id
                                                           orderby work_category.Caption
                                                           select
                                                           new SelectWorkCapability()
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
