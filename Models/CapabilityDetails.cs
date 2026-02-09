using System.Collections;

namespace WebApplication6.Models
{
    /// <summary>
    /// какво ще покажем на страницата със способностите
    /// </summary>
    public class CapabilityDetails : IEnumerable<CapabilityDetails>
    {
        public required int WorkerID { get; set; }
        public required string WorkerName { get; set; }
        public required IEnumerable<SelectWorkCapability> Actions { get; set; }
        //****************************************************
        public IEnumerator<CapabilityDetails> GetEnumerator()
        {
            return (IEnumerator<CapabilityDetails>)this.Actions.GetEnumerator();
        }
        //****************************************************
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Actions.GetEnumerator();
        }
        //****************************************************
    }
}
