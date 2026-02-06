using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    /// <summary>
    /// клас за актуализация на работниците
    /// </summary>
    public class DTO_UpdateWorker
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
