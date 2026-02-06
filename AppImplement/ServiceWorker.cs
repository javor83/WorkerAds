using WebApplication6.AppInterface;
using WebApplication6.DatabaseModels;
using WebApplication6.ExtensionMethods;
using WebApplication6.Models;

namespace WebApplication6.AppImplement
{
    public class ServiceWorker(MeisterContext _context, IWebHostEnvironment appEnvironment) : IServiceWorker
    {



        //********************************************************************************
        async Task IServiceWorker.Update(DTO_UpdateWorker sender)
        {
            Worker? query = _context.Workers.Find(sender.ID);
            if (query != null)
            {
                var wwwroot = appEnvironment.WebRootPath;

                query.Fname = sender.FName;
                query.Lname = sender.LName;
                query.Email = sender.Email;
                query.Phone = sender.Phone;
                if (sender.Preview != null)
                {
                    string save_as = sender.Preview.Upload(wwwroot, BootstrapCSS.worker_folder);
                    query.Photo = Path.GetFileName(save_as);
                }
                await _context.SaveChangesAsync();
            }
        }
        //********************************************************************************
        DTO_UpdateWorker IServiceWorker.Find(int id)
        {
            DTO_UpdateWorker result = null;

            Worker? query = _context.Workers.Find(id);
            if (query != null)
            {
                result = new DTO_UpdateWorker()
                {
                    ID = query.Id,
                    FName = query.Fname,
                    LName = query.Lname,
                    Email = query.Email,
                    Phone = query.Phone,
                    Face = query.Photo,
                    Preview = null

                };

            }

            return result;
        }
        //********************************************************************************
        async Task<bool> IServiceWorker.Delete(int id)
        {
            bool result = false;
            Worker? query = _context.Workers.Find(id);
            if (query != null)
            {
                _context.Workers.Remove(query);
                await _context.SaveChangesAsync();
                result = true;
            }
            return result;

        }
        //********************************************************************************
        async Task IServiceWorker.Insert(DTO_InsertWorker sender)
        {
            var wwwroot = appEnvironment.WebRootPath;

            string save_as = sender.Preview.Upload(wwwroot, BootstrapCSS.worker_folder);

            Worker db_worker = new Worker()
            {
                Fname = sender.FName,
                Lname = sender.LName,
                Phone = sender.Phone,
                Email = sender.Email,
                Photo = Path.GetFileName(save_as)
            };

            _context.Workers.Add(db_worker);

            await _context.SaveChangesAsync();
        }
        //********************************************************************************
        IEnumerable<DTO_WorkerSelect> IServiceWorker.Read()
        {

            List<DTO_WorkerSelect> result = new List<DTO_WorkerSelect>();
            var grouped_list = (from worker in _context.Workers
                                join capability in _context.WorkerCapabilities
                                on worker.Id equals capability.WorkerId into group_worker_category
                                from item_worker_category in group_worker_category.DefaultIfEmpty()

                                join tax_wage in _context.TaxWages
                                on item_worker_category.TaxWageId equals tax_wage.Id into group_tax_wage
                                from item_tax_wage in group_tax_wage.DefaultIfEmpty()

                                join work_category in _context.WorkCategories
                                on item_worker_category.WorkCategoryId equals work_category.Id into group_wcategory
                                from item_wcategory in group_wcategory.DefaultIfEmpty()


                                orderby worker.Fname, worker.Lname
                                select new
                                {
                                    worker.Id,
                                    worker.Fname,
                                    worker.Lname,
                                    worker.Phone,
                                    worker.Email,
                                    worker.Photo,
                                    WorkCategory = item_wcategory.Caption,
                                    TaxWage = item_tax_wage.Caption,
                                    item_worker_category.Price

                                });

            foreach (var worker in grouped_list)
            {

                if (result.Any(x => x.ID == worker.Id) == false)
                {
                    var item = new DTO_WorkerSelect()
                    {
                        ID = worker.Id,
                        FName = worker.Fname,
                        LName = worker.Lname,
                        Phone = worker.Phone,
                        Photo = worker.Photo,
                        Email = worker.Email
                    };

                    if (worker.TaxWage != null)
                    {
                        item.Insert
                        (
                            new DTO_WorkerSelect_Capability()
                            {
                                Price = Convert.ToDecimal(worker.Price),
                                TaxWage = worker.TaxWage,
                                WorkCategory = worker.WorkCategory
                            }
                        );
                    }
                    result.Add(item);
                }
                else
                {
                    var element_id = result.Find
                        (
                            delegate (DTO_WorkerSelect x)
                            {
                                return x.ID == worker.Id;
                            }
                        );
                    if (worker.TaxWage != null)
                    {
                        element_id.Insert
                        (
                            new DTO_WorkerSelect_Capability()
                            {
                                Price = Convert.ToDecimal(worker.Price),
                                TaxWage = worker.TaxWage,
                                WorkCategory = worker.WorkCategory
                            }
                        );
                    }
                }
            }
            return result;
        }
    }
}
