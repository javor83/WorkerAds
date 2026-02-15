using System.ComponentModel.DataAnnotations;
using GCommon.ExtensionAttributes;
using GCommon.Captions;
using GCommon.ExtensionMethods;
using GCommon.ValidationMessage;
using Microsoft.AspNetCore.Http;

namespace GCommon.Models
{
    /// <summary>
    /// обект за вмъкване в базата
    /// </summary>
    public class InsertWorkerViewModel
    {
        public required int? ID { get; set; }
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
        [Required(AllowEmptyStrings = false, ErrorMessage = valid_Worker.Required_Field)]
        [Display(Name = text_Worker.WorkerImage)]
        [UploadFile(BootstrapCSS.image_mime_type, BootstrapCSS.max_upload, valid_Worker.Required_File, BootstrapCSS.image_types, true)]
        public required IFormFile? Preview { get; set; }
        //**********************************************************************

        public static InsertWorkerViewModel Empty()
        {
            return new InsertWorkerViewModel()
            {
                ID = null,
                FName = string.Empty,
                LName = string.Empty,
                Phone = string.Empty,
                Email = string.Empty,
                Preview = null

            };
        }

    }
}
