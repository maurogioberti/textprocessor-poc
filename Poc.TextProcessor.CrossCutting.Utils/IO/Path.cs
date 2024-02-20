namespace Poc.TextProcessor.CrossCutting.Utils.IO
{
    public static class Path
    {
        public static string CurrentDirectory => $"{AppDomain.CurrentDomain.BaseDirectory}{AppDomain.CurrentDomain.RelativeSearchPath}";
    }
}