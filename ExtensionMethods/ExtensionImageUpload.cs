using Microsoft.AspNetCore.Http;

namespace GCommon.ExtensionMethods
{
    /// <summary>
    /// улеснение за качване на изображение
    /// </summary>
    public static class ExtensionImageUpload
    {

        public static string Upload(this IFormFile sender, string wwwroot, string worker_folder)
        {
            string main_folder = $"{wwwroot}/{worker_folder}";
            string save_as = $"{main_folder}/{Guid.NewGuid().ToString()}.jpg";

            using (var x = File.OpenWrite(save_as))
            {

                using (var input_stream = sender.OpenReadStream())
                {
                    if (input_stream != null)
                    {
                        input_stream.CopyTo(x);
                    }
                }
            }

            return save_as;
        }


    }
}
