using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    /// <summary>
    /// клас за способностите на работниците
    /// </summary>
    public class DTO_WorkCapability
    {
        //не е задължително за попълване
        public IEnumerable<SelectListItem>? ListCategory { get; set; }
        //*********************************************************************************************
        //не е задължително за попълване
        public IEnumerable<SelectListItem>? ListTaxWage { get; set; }
        //*********************************************************************************************
        public required int WorkerID { get; set; }
        //*********************************************************************************************
        public required string WorkerName { get; set; }
        //*********************************************************************************************
        public required int? ID { get; set; }

        


        //*********************************************************************************************
        [Required(ErrorMessage = valid_Worker.Required_Field)]
        [Display(Name = text_WageTax.LabelWageTaxUnit)]
        public required int? TaxWageID { get; set; }
        //*********************************************************************************************
        [Required(ErrorMessage = valid_Worker.Required_Field)]
        [Display(Name = text_WorkCategory.LabelWorkCategory)]
        public required int? CategoryID { get; set; }
        //*********************************************************************************************
        [Required(ErrorMessage = valid_Worker.Required_Field)]
        [Display(Name = text_Worker.Price)]
        [Range(valid_Worker.MinPrice,valid_Worker.MaxPrice,ErrorMessage = valid_Worker.Range_Price)]
        public required decimal? Price { get; set; }
       
        //*********************************************************************************************
    }
}
