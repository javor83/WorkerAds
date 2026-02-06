using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;
using WebApplication6.Captions;
using WebApplication6.ValidationErrorMessage;
using WebApplication6.ExtensionMethods;

namespace WebApplication6.Models
{
    

    /// <summary>
    /// DTO обект за начините на плащане
    /// </summary>
    public class DTO_WageTax:IValidatableObject
    {

        //***********************************************************************
        public int? ID { get; set; }
        //***********************************************************************
        [Required(AllowEmptyStrings = false,ErrorMessage = valid_WageTax.Required_WageTaxName)]
        [MaxLength(valid_WageTax.MaxLength_WageTaxName,ErrorMessage = valid_WageTax.MaxLength_ErrorMessageWageTaxName)]
        [MinLength(valid_WageTax.MinLength_WageTaxName, ErrorMessage = valid_WageTax.MinLength_ErrorMessageWageTaxName)]
        [Display(Name= text_WageTax.LabelWageTaxUnit)]
        
        public string? Name { get; set; }
        //***********************************************************************
        public static DTO_WageTax Empty()
        {
            return new DTO_WageTax()
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

                        valid_WageTax.CapitalLetter,
                        text_WageTax.LabelWageTaxUnit),
                    new string[] { nameof(this.Name) });
            }
        }
        //***********************************************************************

    }
}
