using System.Collections;

namespace GCommon.Models
{
    /// <summary>
    /// описва всеки работник
    /// </summary>
    public class WorkerSelectViewModel:IEnumerable<WorkerSelect_Capability>
    {
        public string FullName()
        {
            return $"{this.FName} {this.LName}";
        }

        //*********************************************************************************************
        public required int ID { get; set; }

        //*********************************************************************************************
        public required string FName { get; set; }
        //*********************************************************************************************
        public required string LName { get; set; }
        //*********************************************************************************************
        public required string Phone { get; set; }
        //*********************************************************************************************
        public required string Email { get; set; }
        //*********************************************************************************************
        public required string Photo { get; set; }
        //*********************************************************************************************

        public List<WorkerSelect_Capability> Capability { get; set; } = new List<WorkerSelect_Capability>();
        
        //*********************************************************************************************

        public void Insert(WorkerSelect_Capability item)
        {
            this.Capability.Add(item);
        }
        //*********************************************************************************************
        public IEnumerator<WorkerSelect_Capability> GetEnumerator()
        {
            return ((IEnumerable<WorkerSelect_Capability>)Capability).GetEnumerator();
        }
        //*********************************************************************************************
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Capability).GetEnumerator();
        }
        //*********************************************************************************************
    }


}
