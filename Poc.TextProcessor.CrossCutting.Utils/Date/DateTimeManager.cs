namespace Poc.TextProcessor.CrossCutting.Utils.Date
{
    public static class DateTimeManager
    {
        private static readonly string _timestampMask = "yyyyMMddHHmmssffff";

        /// <summary>
        /// Get App Server Date Time.
        /// </summary>
        public static DateTime ApplicationServerDateTime => DateTime.Now;

        /// <summary>
        /// Get App Server Date Time expressed as the Coordinated Universal Time (UTC).
        /// </summary>
        public static DateTime ApplicationServerDateTimeUtc => DateTime.UtcNow;

        public static string TimeStamp(DateTime date)
        {
            return date.ToString(_timestampMask);
        }

        public static string TimeStamp(string date)
        {
            return Convert.ToDateTime(date).ToString(_timestampMask);
        }
    }
}