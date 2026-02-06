using Microsoft.EntityFrameworkCore;
using WebApplication6.DatabaseModels;

namespace WebApplication6.Models
{
    



    public class ServiceWorkHours(MeisterContext _context) : IServiceWorkHours
    {
        
       
        //********************************************************************************
        async Task IServiceWorkHours.Insert(DTO_WorkHour sender)
        {
            WorkStartHour item = new WorkStartHour()
            {
                Shour = sender.Hour.Value,
                Sminute = sender.Minute.Value
            };
            _context.WorkStartHours.Add(item);
            await _context.SaveChangesAsync();
        }

        //********************************************************************************
        async Task IServiceWorkHours.Update(DTO_WorkHour sender)
        {
            var query = _context.WorkStartHours.Where(x => x.Id == sender.ID).First();

            query.Sminute = sender.Minute.Value;
            query.Shour = sender.Hour.Value;
            await _context.SaveChangesAsync();
        }
        //********************************************************************************
        async Task IServiceWorkHours.Delete(int id)
        {
            bool ok = (this as IServiceWorkHours).Exists(id);
            if (ok)
            {
                var query = _context.WorkStartHours.Where(x => x.Id == id).First();
                _context.Remove(query);
                await _context.SaveChangesAsync();
            }
        }

        //********************************************************************************
        bool IServiceWorkHours.Exists(int id)
        {
            bool query = _context.WorkStartHours.Where(x => x.Id == id).Any();
            return query;
        }

        //********************************************************************************
        DTO_WorkHour IServiceWorkHours.To_DTO_WorkHour(int id)
        {
            DTO_WorkHour result = null;

            var query = _context.WorkStartHours.Where(x => x.Id == id).First();

            result = new DTO_WorkHour()
            {
                ID = query.Id,
                Hour = query.Shour,
                Minute = query.Sminute
            };
            return result;
        }

        


        //********************************************************************************
        IEnumerable<DTO_WorkHour> IServiceWorkHours.Read()
        {
            var query = _context.WorkStartHours.
                OrderBy(x => x.Shour).
                ThenBy(x => x.Sminute).Select
                (
                    x =>
                    new DTO_WorkHour
                    {
                        ID = x.Id,
                        Hour = x.Shour,
                        Minute = x.Sminute
                    }
                );
            return query;

        }
        //********************************************************************************
    }
}
