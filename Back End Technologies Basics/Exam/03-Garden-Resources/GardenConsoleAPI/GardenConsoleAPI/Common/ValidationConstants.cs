namespace GardenConsoleAPI.Common
{
    public class ValidationConstants
    {
        public const int NameMaxLength = 70;
        public const string CatalogNumberFormat = @"^([0-9A-Z]{12})$";
        public const int TypeMaxLength = 30;
        public const int QuantityMinValue = 0;
        public const int QuantityMaxValue = 1000;
    }
}
