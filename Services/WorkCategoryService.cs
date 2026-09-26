using GCommon.Contracts;
using GCommon.Models;
using WebApplication6.Data;

namespace GCommon.Services
{
    public class WorkCategoryService(MeisterContext _context) : IWorkCategoryService
    {


        //*****************************************************************************************
        async Task IWorkCategoryService.Delete(int id)
        {
            var query = _context.WorkCategories.Where(x => x.Id == id);
            if (query.Any())
            {
                _context.WorkCategories.Remove(query.First());
                await _context.SaveChangesAsync();
            }
        }

        //*****************************************************************************************
        async Task IWorkCategoryService.Insert(Models.TaxCategoryViewModel sender)
        {
            var tc = new WorkCategory()
            {
                Caption = sender.Name.Trim()
            };
            _context.WorkCategories.Add(tc);
            await _context.SaveChangesAsync();

        }
        //*****************************************************************************************
        bool IWorkCategoryService.Exists(int id)
        {
            var query = _context.WorkCategories.Where(x => x.Id == id);
            if (query.Any())
            {
                return true;
            }
            else
                return false;

        }
        //*****************************************************************************************
        Models.TaxCategoryViewModel IWorkCategoryService.To_DTO_WorkCategory(int id)
        {
            var query = _context.WorkCategories.Where(x => x.Id == id).First();

            Models.TaxCategoryViewModel result = new Models.TaxCategoryViewModel()
            {
                ID = query.Id,
                Name = query.Caption

            };
            return result;
        }

        //*****************************************************************************************

        async Task IWorkCategoryService.Update(Models.TaxCategoryViewModel sender)
        {
            var query = _context.WorkCategories.Where(x => x.Id == sender.ID).First(); ;


            query.Caption = sender.Name.Trim();
            await _context.SaveChangesAsync();



        }




        //*****************************************************************************************
        IEnumerable<TaxCategoryViewModel> IWorkCategoryService.Read()
        {
            IEnumerable<TaxCategoryViewModel> query = _context.
                WorkCategories.OrderBy(x => x.Caption).Select
                (
                    x =>
                    new TaxCategoryViewModel()
                    {
                        ID = x.Id,
                        Name = x.Caption


                    }
                );

            return query;
        }
        //*****************************************************************************************

    }
}
