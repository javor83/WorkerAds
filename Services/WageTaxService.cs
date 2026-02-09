using WebApplication6.Data;
using WebApplication6.Interfaces;

using WebApplication6.Models;

namespace WebApplication6.Services
{
    /// <summary>
    /// управление на методите за начини на таксуване
    /// </summary>
    public class WageTaxService(MeisterContext _context) : IWageTaxService
    {


        //*****************************************************************************************
        IEnumerable<WageTax> IWageTaxService.Read()
        {
            var query = _context.TaxWages.OrderBy(x => x.Caption).Select
                (
                    x =>
                    new WageTax()
                    {
                        ID = x.Id,
                        Name = x.Caption
                    }
                );
            return query;
        }
        //*****************************************************************************************
        async Task IWageTaxService.Create(WageTax entity)
        {
            TaxWage twage = new TaxWage()
            {
                Caption = entity.Name.Trim()
            };
            _context.TaxWages.Add(twage);
            await _context.SaveChangesAsync();

        }
        //*****************************************************************************************
        async Task IWageTaxService.Delete(int id)
        {
            var item = (this as IWageTaxService).Exists(id);
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
        bool IWageTaxService.Exists(int id)
        {
            var query = this.ElementInDatabase(id);
            return query != null;
        }
        //*****************************************************************************************
        WageTax IWageTaxService.To_DTO_WageTax(int id)
        {
            TaxWage db = this.ElementInDatabase(id);

            var result = new WageTax()
            {
                ID = db.Id,
                Name = db.Caption
            };

            return result;
        }

        //*****************************************************************************************
        async Task IWageTaxService.Update(WageTax entity)
        {

            TaxWage db = this.ElementInDatabase(entity.ID.Value);
            db.Caption = entity.Name.Trim();
            await _context.SaveChangesAsync();

        }
        //*****************************************************************************************

    }
}
