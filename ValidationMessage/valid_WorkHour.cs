using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCommon.ValidationMessage
{
    /// <summary>
    /// валидации при работните часове
    /// </summary>
    public class valid_WorkHour
    {
        public const string Required_WorkHour = "Полето \"{0}\" e задължително";
        public const string Range_WorkHour = "Полето \"{0}\" e в обхват {1} .. {2}";
    }
}
