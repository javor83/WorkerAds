using System.ComponentModel.DataAnnotations;
using WebApplication6.Captions;


namespace WebApplication6.Models
{
    /// <summary>
    /// начален час на работа
    /// </summary>
    public class DTO_WorkHour
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
            return $"{this.Hour:D2}:{this.Minute:D2}";
        }
        //***********************************************************************
        public static DTO_WorkHour Empty()
        {
            return new DTO_WorkHour()
            {
                ID = 0,
                Hour = 0,
                Minute = 0
            };
        }
        //***********************************************************************
    }
}
