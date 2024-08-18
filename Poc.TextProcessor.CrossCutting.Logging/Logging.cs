using Poc.TextProcessor.CrossCutting.Configurations;
using Poc.TextProcessor.CrossCutting.Utils.Date;
using Serilog;
using Serilog.Formatting.Compact;

namespace Poc.TextProcessor.CrossCutting.Logging
{
    public static class Logging
    {
        private static readonly DateTime CurrentDateTime = DateTimeManager.ApplicationServerDateTime;
        public static string LogFilePath => $"{Utils.IO.Path.CurrentDirectory}/{Logs.Directory}_{CurrentDateTime.ToString(Culture.FileDateFormat)}.json";

        public static void Initialize()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(new CompactJsonFormatter(), LogFilePath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public static void LogError(Exception exception, string message) => Log.Error(exception, message);


        //TODO: Improve Logging // Use a better implementation
        // Consider adding methods for other log levels if needed
        // public static void LogError(string message) => Log.Error(message);
        // public static void LogInformation(string message) => Log.Information(message);
        // public static void LogWarning(string message) => Log.Warning(message);
        // public static void LogDebug(string message) => Log.Debug(message);
    }
}