using System.ComponentModel.DataAnnotations;
using WebApplication6.Captions;
using WebApplication6.AppValidationErrorMessage;
using WebApplication6.ExtensionMethods;

namespace WebApplication6.Models
{
    /// <summary>
    /// DTO обект за работните категории
    /// </summary>
    public class TaxCategory:IValidatableObject
    {
        //***********************************************************************
        public int? ID { get; set; }

        //***********************************************************************
        [Required(AllowEmptyStrings = false, ErrorMessage = valid_WorkCategory.Reqired_WorkCategory)]
     

        [MaxLength(valid_WorkCategory.MaxLength_WorkCategory, ErrorMessage = valid_WorkCategory.MaxLength_ErrorMessageWorkCategory)]
        [MinLength(valid_WorkCategory.MinLength_WorkCategory, ErrorMessage = valid_WorkCategory.MinLength_ErrorMessageWorkCategory)]
        [Display(Name = text_WorkCategory.LabelWorkCategory)]


        public string Name { get; set; }
        //***********************************************************************
        public static TaxCategory Empty()
        {
            return new TaxCategory()
            {
                ID = null,
                Name = string.Empty
            };
        }
        //***********************************************************************
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            if (this.Name.IsFirstLetterUpper() == false)
            {
                yield return new ValidationResult(
                    string.Format(

                        valid_WorkCategory.CapitalLetter,
                        text_WorkCategory.LabelWorkCategory),
                    new string[] { nameof(this.Name) });
            }
        }
        //***********************************************************************
    }
}
