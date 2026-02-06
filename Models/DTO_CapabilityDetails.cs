using System.Collections;

namespace WebApplication6.Models
{
    /// <summary>
    /// какво ще покажем на страницата със способностите
    /// </summary>
    public class DTO_CapabilityDetails : IEnumerable<DTO_CapabilityDetails>
    {
        public required int WorkerID { get; set; }
        public required string WorkerName { get; set; }
        public required IEnumerable<DTO_SelectWorkCapability> Actions { get; set; }
        //****************************************************
        public IEnumerator<DTO_CapabilityDetails> GetEnumerator()
        {
            return (IEnumerator<DTO_CapabilityDetails>)this.Actions.GetEnumerator();
        }
        //****************************************************
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Actions.GetEnumerator();
        }
        //****************************************************
    }
}
