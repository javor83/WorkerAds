using GCommon.ExtensionMethods;

namespace GCommon.Models
{
    /// <summary>
    /// описва какво може всеки работник
    /// </summary>
    public class WorkerSelect_Capability
    {

        //************************************************************************************
        /// <summary>
        /// цена на труда
        /// </summary>
        public required decimal Price { get; set; }
        //************************************************************************************
        /// <summary>
        /// какво може да прави точно - вик/ел и т.н
        /// </summary>
        public required string WorkCategory { get; set; }
        //************************************************************************************
        /// <summary>
        /// как се таксува труда - л.м/кв.м и т.н
        /// </summary>
        public required string TaxWage { get; set; }
        //************************************************************************************
        /// <summary>
        /// показва хубав надпис как се таксува труда
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            return this.WorkCategory.IncludeTaxPrint(this.TaxWage,this.Price);
        }
        //************************************************************************************
        public WorkerSelect_Capability()
        {
            this.Price = 0;
            this.WorkCategory = string.Empty;
            this.TaxWage = string.Empty;
        }
        //************************************************************************************
    }
}
