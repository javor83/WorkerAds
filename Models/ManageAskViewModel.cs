using GCommon.Captions;
using GCommon.ValidationMessage;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GCommon.Models
{



    public class SM
    {
      
        //****************************************************************
      

        [Display(Name = "Phone")]

        public required string Phone { get; set; } = "";
        //****************************************************************
        //записва се при потвърждение на поръчката
      
        [Display(Name = "Details")]

        public required string OrderDetails { get; set; } = "";
    }

    public class ManageAskViewModel
    {
        [Required]
        
        public required string ASPNETUSER_ID { get; set; } = "";
        //****************************************************************
        [Required]
        public required int[] AdvID { get; set; } = new int[] { };

        //****************************************************************
        //записва се при потвърждение на поръчката
        [Required(ErrorMessage = @valid_UserAsk.Phone, AllowEmptyStrings = false)]
        
        [Display(Name = "Phone")]
       
        public required string Phone { get; set; } = "";
        //****************************************************************
        //записва се при потвърждение на поръчката
        [Required(ErrorMessage = @valid_UserAsk.Details, AllowEmptyStrings = false)]
        [Display(Name = "Details")]
        
        public required string OrderDetails { get; set; } = "";
        //****************************************************************
    }

    
}
