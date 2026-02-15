using GCommon.Contracts;
using GCommon.Data;
using GCommon.ExtensionMethods;
using GCommon.Models;

namespace GCommon.Services
{
    public class AdsPersonService(MeisterContext _context) : IAdsPersonService
    {



        //*****************************************************************
        IEnumerable<AdsPersonViewModel> IAdsPersonService.Read()
        {
            IEnumerable<AdsPersonViewModel> result = from worker in _context.Workers
                                                     join worker_capability in _context.WorkerCapabilities
                                                     on worker.Id equals worker_capability.WorkerId

                                                     join tax_wage in _context.TaxWages
                                                     on worker_capability.TaxWageId equals tax_wage.Id

                                                     join work_category in _context.WorkCategories
                                                     on worker_capability.WorkCategoryId equals work_category.Id

                                                     join decl_wfree in _context.DeclareWorkerFrees
                                                     on worker_capability.Id equals decl_wfree.WorkerCapabilityId



                                                     join hour_value in _context.WorkStartHours
                                                     on decl_wfree.HourId equals hour_value.Id

                                                     select new AdsPersonViewModel()
                                                     {
                                                         DeclareWorkerFreeID = decl_wfree.Id,
                                                         FName = worker.Fname,
                                                         LName = worker.Lname,
                                                         Phone = worker.Phone,
                                                         Email = worker.Email,
                                                         Photo = worker.Photo,
                                                         Price = Convert.ToDecimal(worker_capability.Price),
                                                         TaxWage = tax_wage.Caption,
                                                         WorkCategory = work_category.Caption,
                                                         AdvText = decl_wfree.AdText,
                                                         DayName = decl_wfree.WatchDate.OnlyDatePart(),
                                                         Hour = hour_value.Shour,
                                                         Minute = hour_value.Sminute

                                                     };
            return result;
        }
        //*****************************************************************
    }
}
