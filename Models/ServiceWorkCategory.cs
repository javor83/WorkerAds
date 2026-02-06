using WebApplication6.DatabaseModels;

namespace WebApplication6.Models
{
    public class ServiceWorkCategory(MeisterContext _context) : IServiceWorkCategory
    {
        
        
        //*****************************************************************************************
        async Task IServiceWorkCategory.Delete(int id)
        {
            var query = _context.WorkCategories.Where(x => x.Id == id);
            if (query.Any())
            {
                _context.WorkCategories.Remove(query.First());
                await _context.SaveChangesAsync();
            }
        }

        //*****************************************************************************************
        async Task IServiceWorkCategory.Insert(DTO_WorkCategory sender)
        {
            WorkCategory tc = new WorkCategory()
            {
                Caption = sender.Name.Trim()
            };
            _context.WorkCategories.Add(tc);
            await _context.SaveChangesAsync();

        }
        //*****************************************************************************************
        bool IServiceWorkCategory.Exists(int id)
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
        DTO_WorkCategory IServiceWorkCategory.To_DTO_WorkCategory(int id)
        {
            var query = _context.WorkCategories.Where(x => x.Id == id).First();

            DTO_WorkCategory result = new DTO_WorkCategory()
            {
                ID = query.Id,
                Name = query.Caption

            };
            return result;
        }

        //*****************************************************************************************

        async Task IServiceWorkCategory.Update(DTO_WorkCategory sender)
        {
            var query = _context.WorkCategories.Where(x => x.Id == sender.ID).First(); ;


            query.Caption = sender.Name.Trim();
            await _context.SaveChangesAsync();



        }




        //*****************************************************************************************
        IEnumerable<DTO_WorkCategory> IServiceWorkCategory.Read()
        {
            IEnumerable<DTO_WorkCategory> query = _context.
                WorkCategories.OrderBy(x => x.Caption).Select
                (
                    x =>
                    new DTO_WorkCategory()
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
