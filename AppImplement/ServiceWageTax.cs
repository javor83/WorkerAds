using WebApplication6.AppInterface;
using WebApplication6.DatabaseModels;
using WebApplication6.Models;

namespace WebApplication6.AppImplement
{
    /// <summary>
    /// управление на методите за начини на таксуване
    /// </summary>
    public class ServiceWageTax(MeisterContext _context) : IServiceWageTax
    {


        //*****************************************************************************************
        IEnumerable<DTO_WageTax> IServiceWageTax.Read()
        {
            var query = _context.TaxWages.OrderBy(x => x.Caption).Select
                (
                    x =>
                    new DTO_WageTax()
                    {
                        ID = x.Id,
                        Name = x.Caption
                    }
                );
            return query;
        }
        //*****************************************************************************************
        async Task IServiceWageTax.Create(DTO_WageTax entity)
        {
            TaxWage twage = new TaxWage()
            {
                Caption = entity.Name.Trim()
            };
            _context.TaxWages.Add(twage);
            await _context.SaveChangesAsync();

        }
        //*****************************************************************************************
        async Task IServiceWageTax.Delete(int id)
        {
            var item = (this as IServiceWageTax).Exists(id);
            if (item)
            {
                var TaxWage = this.ElementInDatabase(id);
                _context.TaxWages.Remove(TaxWage);
                await _context.SaveChangesAsync();
            }
        }
        //*****************************************************************************************
        private TaxWage ElementInDatabase(int id)
        {
            var result = _context.TaxWages.Where(x => x.Id == id).First();
            return result;
        }
        //*****************************************************************************************
        bool IServiceWageTax.Exists(int id)
        {
            var query = this.ElementInDatabase(id);
            return query != null;
        }
        //*****************************************************************************************
        DTO_WageTax IServiceWageTax.To_DTO_WageTax(int id)
        {
            TaxWage db = this.ElementInDatabase(id);

            var result = new DTO_WageTax()
            {
                ID = db.Id,
                Name = db.Caption
            };

            return result;
        }

        //*****************************************************************************************
        async Task IServiceWageTax.Update(DTO_WageTax entity)
        {

            TaxWage db = this.ElementInDatabase(entity.ID.Value);
            db.Caption = entity.Name.Trim();
            await _context.SaveChangesAsync();

        }
        //*****************************************************************************************

    }
}
