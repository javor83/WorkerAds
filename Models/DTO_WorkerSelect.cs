using System.Collections;

namespace WebApplication6.Models
{
    /// <summary>
    /// описва всеки работник
    /// </summary>
    public class DTO_WorkerSelect:IEnumerable<DTO_WorkerSelect_Capability>
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

        public List<DTO_WorkerSelect_Capability> Capability { get; set; } = new List<DTO_WorkerSelect_Capability>();
        
        //*********************************************************************************************

        public void Insert(DTO_WorkerSelect_Capability item)
        {
            this.Capability.Add(item);
        }
        //*********************************************************************************************
        public IEnumerator<DTO_WorkerSelect_Capability> GetEnumerator()
        {
            return ((IEnumerable<DTO_WorkerSelect_Capability>)Capability).GetEnumerator();
        }
        //*********************************************************************************************
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Capability).GetEnumerator();
        }
        //*********************************************************************************************
    }


}
