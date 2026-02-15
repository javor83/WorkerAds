namespace GCommon.ExtensionMethods
{
    /// <summary>
    /// помощни методи за стринговете
    /// </summary>
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

        //**************************************************************************************************************************
        /// <summary>
        /// показва само името на контролера
        /// </summary>
        /// <param name="con_name"></param>
        /// <returns></returns>
        public static string Navigate(this string con_name)
        {

            string result = con_name.Substring(0, con_name.IndexOf("Controller"));
            return result;
        }
        //**************************************************************************
        public static string IncludeLastName(this string sender, string last)
        {
            return $"{sender} {last}";
        }

        //**************************************************************************
        public static string IncludeTaxPrint(this string category_name, string tax_Wage, decimal money)
        {
            return $"{category_name} - {money.ToMoney()} / {tax_Wage}";
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
