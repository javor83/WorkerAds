namespace GCommon.Models
{
    public class SummaryManageAsk
    {
        public bool EmptyBasket { get; set; }
        public int BasketCount { get; set; }

        public string ClassName()
        {
            
            if (this.EmptyBasket)
            {
                return "badge rounded-pill bg-primary";
            }
            else
            {
                return "badge rounded-pill bg-success";
            }
        }

    }
}
