using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WebApplication6.Models
{
    public static class ExtensionString
    {
        /// <summary>
        /// png;jpg;jpeg => [.png,.jpg,.jpeg]
        /// </summary>
        /// <param name="combined_ext"></param>
        /// <returns></returns>
        public static string HtmlFileAccept(this string combined_ext)
        {
            //accept=".xls,.xlsx"
            List<string> dots = new List<string>();
            string[] extensions = combined_ext.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < extensions.Length; i++)
            {
                dots.Add($".{extensions[i].Trim().ToLower()}");
                
            }
            string result = string.Join(", ", dots.ToArray());
            return result;
        }

        //**************************************************************************
        /// <summary>
        /// тексът трябва да почва с главна буква
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static bool IsFirstLetterUpper(this string sender)
        {
            bool result = false;
            if (string.IsNullOrEmpty(sender) == false)
            {
                sender = sender.Trim();
                if (sender.Length > 0)
                {
                    if (Char.IsUpper(sender[0]))
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
        //**************************************************************************
        /// <summary>
        /// снимката на работника в изгледа
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static string ImgSrc_PreviewWorker(this string sender)
        {
            return $"/{BootstrapCSS.worker_folder}/{sender}";
        }
        //**************************************************************************


    }
}
