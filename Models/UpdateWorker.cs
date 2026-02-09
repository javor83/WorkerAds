using System.ComponentModel.DataAnnotations;
using WebApplication6.Captions;
using WebApplication6.AppValidationErrorMessage;
using WebApplication6.AppAttributes;
using WebApplication6.ExtensionMethods;

namespace WebApplication6.Models
{
    /// <summary>
    /// клас за актуализация на работниците
    /// </summary>
    public class UpdateWorker
    {
        public required int? ID { get; set; }
        public required string Face { get; set; }
        //**********************************************************************
        [Required(AllowEmptyStrings = false, ErrorMessage = valid_Worker.Required_Field)]
        [Display(Name = text_Worker.WorkerFName)]
        [MaxLength(valid_Worker.MaxLength, ErrorMessage = valid_Worker.MaxLength_Field)]
        public required string? FName { get; set; }
        //**********************************************************************
        [Required(AllowEmptyStrings = false, ErrorMessage = valid_Worker.Required_Field)]
        [Display(Name = text_Worker.WorkerLName)]
        [MaxLength(valid_Worker.MaxLength, ErrorMessage = valid_Worker.MaxLength_Field)]
        public required string? LName { get; set; }
        //**********************************************************************
        [Required(AllowEmptyStrings = false, ErrorMessage = valid_Worker.Required_Field)]
        [Display(Name = text_Worker.WorkerPhone)]
        [MaxLength(valid_Worker.MaxLength, ErrorMessage = valid_Worker.MaxLength_Field)]
        public required string? Phone { get; set; }
        //**********************************************************************
        [Required(AllowEmptyStrings = false, ErrorMessage = valid_Worker.Required_Field)]
        [Display(Name = text_Worker.WorkerEmail)]
        [MaxLength(valid_Worker.MaxLength, ErrorMessage = valid_Worker.MaxLength_Field)]
        public required string? Email { get; set; }
        //**********************************************************************
        [Display(Name = text_Worker.WorkerImage)]
        [UploadFile(BootstrapCSS.image_mime_type, BootstrapCSS.max_upload, valid_Worker.Required_File, BootstrapCSS.image_types,false)]
        public IFormFile? Preview { get; set; }
        //**********************************************************************
    }
}
