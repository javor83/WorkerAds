using GCommon.Captions;
using GCommon.Models;
using GCommon.ValidationMessage;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace GCommon.Models
{

    public class ToPost
    {
        [Required]
        public required string ASPNETUSER_ID { get; set; } = "";
        //****************************************************************
        public required int[] AdvID { get; set; } = new int[] { };

        //****************************************************************
        //записва се при потвърждение на поръчката
        [Required(ErrorMessage = @valid_UserAsk.Phone, AllowEmptyStrings = false)]
        [Display(Name = text_UserAsk.Phone)]
        public required string Phone { get; set; } = "";
        //****************************************************************
        //записва се при потвърждение на поръчката
        [Required(ErrorMessage = @valid_UserAsk.Details, AllowEmptyStrings = false)]
        [Display(Name = text_UserAsk.Details)]
        public required string OrderDetails { get; set; } = "";
        //****************************************************************
    }

    
}
