using GCommon.Contracts;
using GCommon.Data;
using GCommon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCommon.Services
{
    /// <summary>
    /// управление на методите за начини на таксуване
    /// </summary>
    public class WageTaxService(MeisterContext _context) : IWageTaxService
    {


        //*****************************************************************************************
        IEnumerable<WageTaxViewModel> IWageTaxService.Read()
        {
            var query = _context.TaxWages.OrderBy(x => x.Caption).Select
                (
                    x =>
                    new WageTaxViewModel()
                    {
                        ID = x.Id,
                        Name = x.Caption
                    }
                );
            return query;
        }
        //*****************************************************************************************
        async Task IWageTaxService.Create(WageTaxViewModel entity)
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
        WageTaxViewModel IWageTaxService.To_DTO_WageTax(int id)
        {
            TaxWage db = this.ElementInDatabase(id);

            var result = new WageTaxViewModel()
            {
                ID = db.Id,
                Name = db.Caption
            };

            return result;
        }

        //*****************************************************************************************
        async Task IWageTaxService.Update(WageTaxViewModel entity)
        {

            TaxWage db = this.ElementInDatabase(entity.ID.Value);
            db.Caption = entity.Name.Trim();
            await _context.SaveChangesAsync();

        }
        //*****************************************************************************************

    }
}
