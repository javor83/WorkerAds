using GCommon.ExtensionMethods;

namespace GCommon.Models
{
    /// <summary>
    /// това са обявите , които е въвел конкретният работник
    /// </summary>
    public class SelectPublishAdsItemViewModel
    {
        public required int ID { get; set; }

        public required string AdvText;
        public int Hour { get; set; }//за сортиране по час

        public int Minute { get; set; }//за сортиране по минута

        public required DateTime StartDay { get; set; }//за сортиране по ден-месец-година

        public required string CategoryName { get; set; }

        public required string TaxWage { get; set; }

        public required decimal Money { get; set; }

        
        //********************************************************************************
        public string AdsDate()
        {
            return $"{this.StartDay.OnlyDatePart()} - {this.Hour.PrintableHour(this.Minute)}";   
        }

        //********************************************************************************

        public string PrintCategoryTax()
        {

            return this.CategoryName.IncludeTaxPrint(this.TaxWage, this.Money);

        }
       
        //********************************************************************************


    }
}
