using WebApplication6.Interfaces;
using WebApplication6.Data;
using WebApplication6.Models;

namespace WebApplication6.Services
{
    public class WorkHoursService(MeisterContext _context) : IWorkHoursService
    {


        //********************************************************************************
        async Task IWorkHoursService.Insert(WorkHour sender)
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
        async Task IWorkHoursService.Update(WorkHour sender)
        {
            var query = _context.WorkStartHours.Where(x => x.Id == sender.ID).First();

            query.Sminute = sender.Minute.Value;
            query.Shour = sender.Hour.Value;
            await _context.SaveChangesAsync();
        }
        //********************************************************************************
        async Task IWorkHoursService.Delete(int id)
        {
            bool ok = (this as IWorkHoursService).Exists(id);
            if (ok)
            {
                var query = _context.WorkStartHours.Where(x => x.Id == id).First();
                _context.Remove(query);
                await _context.SaveChangesAsync();
            }
        }

        //********************************************************************************
        bool IWorkHoursService.Exists(int id)
        {
            bool query = _context.WorkStartHours.Where(x => x.Id == id).Any();
            return query;
        }

        //********************************************************************************
        WorkHour IWorkHoursService.To_DTO_WorkHour(int id)
        {
            WorkHour result = null;

            var query = _context.WorkStartHours.Where(x => x.Id == id).First();

            result = new WorkHour()
            {
                ID = query.Id,
                Hour = query.Shour,
                Minute = query.Sminute
            };
            return result;
        }




        //********************************************************************************
        IEnumerable<WorkHour> IWorkHoursService.Read()
        {
            var query = _context.WorkStartHours.
                OrderBy(x => x.Shour).
                ThenBy(x => x.Sminute).Select
                (
                    x =>
                    new WorkHour
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
