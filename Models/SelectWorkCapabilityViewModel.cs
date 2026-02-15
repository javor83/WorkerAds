namespace GCommon.Models
{
    /// <summary>
    /// способностите на екран
    /// </summary>
    public class SelectWorkCapabilityViewModel
    {

        public required int ID { get; set; }


        public required string TaxWage { get; set; }

        public required string Category { get; set; }

        public required decimal? Price { get; set; }



    }
}
