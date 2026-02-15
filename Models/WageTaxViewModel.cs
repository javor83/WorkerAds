using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;
using GCommon.Captions;
using GCommon.ValidationMessage;
using GCommon.ExtensionMethods;

namespace GCommon.Models
{
    

    /// <summary>
    /// DTO обект за начините на плащане
    /// </summary>
    public class WageTaxViewModel:IValidatableObject
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
        public static WageTaxViewModel Empty()
        {
            return new WageTaxViewModel()
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
