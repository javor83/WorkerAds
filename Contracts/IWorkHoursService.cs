using GCommon.Models;

namespace GCommon.Contracts
{
    /// <summary>
    /// интерфейс за работните часове
    /// </summary>
    public interface IWorkHoursService
    {
        /// <summary>
        /// показване на часовете
        /// </summary>
        /// <returns></returns>
        IEnumerable<WorkHourViewModel> Read();
        //******************************************
        /// <summary>
        /// вмъкване на нов час
        /// </summary>
        /// <param name="sender">какво ще вмъкнем</param>
        /// <returns></returns>
        Task Insert(WorkHourViewModel sender);
        //*************************************************************
        /// <summary>
        /// дали съществува
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Exists(int id);
        //*************************************************************
        //актуализация на час
        Task Update(WorkHourViewModel sender);
        //*************************************************************
        WorkHourViewModel To_DTO_WorkHour(int id);
        //*************************************************************
        /// <summary>
        /// изтрий час
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(int id);
        //*************************************************************

    }
}
