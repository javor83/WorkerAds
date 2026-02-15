using System.Collections;

namespace GCommon.Models
{
    /// <summary>
    /// какво ще покажем на страницата със способностите
    /// </summary>
    public class CapabilityDetailsViewModel : IEnumerable<CapabilityDetailsViewModel>
    {
        public required int WorkerID { get; set; }
        public required string WorkerName { get; set; }
        public required IEnumerable<SelectWorkCapabilityViewModel> Actions { get; set; }
        //****************************************************
        public IEnumerator<CapabilityDetailsViewModel> GetEnumerator()
        {
            return (IEnumerator<CapabilityDetailsViewModel>)this.Actions.GetEnumerator();
        }
        //****************************************************
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Actions.GetEnumerator();
        }
        //****************************************************
    }
}
