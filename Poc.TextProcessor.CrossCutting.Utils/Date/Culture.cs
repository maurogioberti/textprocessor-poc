using System.Globalization;

namespace Poc.TextProcessor.CrossCutting.Utils.Date
{
    public static class Culture
    {
        public const string DateTimeFormat = "dd-MM-yyyy hh:mm:ss";
        public const string DateFormat = "dd-MM-yyyy";
        public const string FileDateFormat = "yyyyMMdd";
        public const string UtcDateTimeFormat = "yyyy-MM-dd hh:mm:ss";
        public const string TimeFormat = "hh:mm:ss";
        public const string DataBaseDateFormat = "yyyy-MM-dd";

        public static CultureInfo Info = CultureInfo.InvariantCulture;
    }
}