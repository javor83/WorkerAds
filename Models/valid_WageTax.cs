namespace WebApplication6.Models
{
    public class valid_WageTax
    {
        public const string CapitalLetter = "Полето \"{0}\" започва с главна буква";
        public const string Required_WageTaxName = "Липсва начин на таксуване";
        public const int MaxLength_WageTaxName = 50;
        public const int MinLength_WageTaxName = 3;

        public const string MaxLength_ErrorMessageWageTaxName = "Полето \"{0}\" не повече от {1} знака";
        public const string MinLength_ErrorMessageWageTaxName = "Полето \"{0}\" не по-малко от {1} знака";
    }
}
