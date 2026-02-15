using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCommon.ValidationMessage
{
    /// <summary>
    /// съобщенията за грешка при работната категория
    /// </summary>
    public class valid_WorkCategory
    {
        public const string CapitalLetter = "Полето \"{0}\" започва с главна буква";
        public const string Reqired_WorkCategory = "Липсва работна категория";
        public const int MaxLength_WorkCategory = 50;
        public const int MinLength_WorkCategory = 3;

        public const string MaxLength_ErrorMessageWorkCategory = "Полето \"{0}\" не повече от {1} знака";
        public const string MinLength_ErrorMessageWorkCategory = "Полето \"{0}\" не по-малко от {1} знака";
    }
}
