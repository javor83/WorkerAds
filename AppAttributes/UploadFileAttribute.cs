using System.ComponentModel.DataAnnotations;

namespace WebApplication6.AppAttributes
{
    public class UploadFileAttribute : ValidationAttribute
    {
        /// <summary>
        /// валидация на файловете по тип - примерно jpeg;jpg;png 
        /// </summary>
        /// <param name="list"></param>
        /// 

        private readonly string mime_type = null;
        private readonly long max_bytes = 0;
        private bool mRequired = false;
        //*****************************************************
        public UploadFileAttribute(string mtype, long _bytes, string mask, string ext, bool requested) : base()
        {
            this.mRequired = requested;
            this.mime_type = mtype;
            this.max_bytes = _bytes;
            this.ErrorMessage = string.Format(mask, this.max_bytes / 1024, ext);
        }
        //*****************************************************

        public override bool IsValid(object? value)
        {

            bool result = false;
            if (this.mRequired)
            {
                IFormFile input_file = value as IFormFile;
                if (input_file != null)
                {
                    string input_mime = input_file.ContentType;
                    long input_long = input_file.Length;
                    if (input_mime.Equals(this.mime_type, StringComparison.OrdinalIgnoreCase))
                    {
                        if (input_long <= this.max_bytes)
                        {
                            result = true;
                        }
                    }
                }
            }
            else result = true;

            return result;
        }
        //*****************************************************
    }
}
