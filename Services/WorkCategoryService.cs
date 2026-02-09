using WebApplication6.Interfaces;
using WebApplication6.Data;
using WebApplication6.Models;

namespace WebApplication6.Services
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
        async Task IWorkCategoryService.Insert(Models.TaxCategory sender)
        {
            var tc = new Data.WorkCategory()
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
        Models.TaxCategory IWorkCategoryService.To_DTO_WorkCategory(int id)
        {
            var query = _context.WorkCategories.Where(x => x.Id == id).First();

            Models.TaxCategory result = new Models.TaxCategory()
            {
                ID = query.Id,
                Name = query.Caption

            };
            return result;
        }

        //*****************************************************************************************

        async Task IWorkCategoryService.Update(Models.TaxCategory sender)
        {
            var query = _context.WorkCategories.Where(x => x.Id == sender.ID).First(); ;


            query.Caption = sender.Name.Trim();
            await _context.SaveChangesAsync();



        }




        //*****************************************************************************************
        IEnumerable<TaxCategory> IWorkCategoryService.Read()
        {
            IEnumerable<TaxCategory> query = _context.
                WorkCategories.OrderBy(x => x.Caption).Select
                (
                    x =>
                    new TaxCategory()
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
