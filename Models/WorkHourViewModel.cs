using System.ComponentModel.DataAnnotations;
using GCommon.ValidationMessage;
using GCommon.Captions;
using GCommon.ExtensionMethods;

namespace GCommon.Models
{
    /// <summary>
    /// начален час на работа
    /// </summary>
    public class WorkHourViewModel
    {
       
        //***********************************************************************
        public int? ID { get; set; }
        //***********************************************************************
        [Required(AllowEmptyStrings =false,ErrorMessage = valid_WorkHour.Required_WorkHour)]
        [Range(0,24,ErrorMessage = valid_WorkHour.Range_WorkHour,MaximumIsExclusive = false)]
        [Display(Name = text_WorkHour.LabelPHour)]
       
        public int? Hour { get; set; }
        //***********************************************************************
        [Required(AllowEmptyStrings = false, ErrorMessage = valid_WorkHour.Required_WorkHour)]
        [Range(0, 59, ErrorMessage = valid_WorkHour.Range_WorkHour, MaximumIsExclusive = false)]
        [Display(Name = text_WorkHour.LabelPMinute)]
       
        public int? Minute { get; set; }
        //***********************************************************************
        public string Printable()
        {

            return this.Hour.PrintableHour(this.Minute);
        }
        //***********************************************************************
        public static WorkHourViewModel Empty()
        {
            return new WorkHourViewModel()
            {
                ID = 0,
                Hour = 0,
                Minute = 0
            };
        }
        //***********************************************************************
    }
}
