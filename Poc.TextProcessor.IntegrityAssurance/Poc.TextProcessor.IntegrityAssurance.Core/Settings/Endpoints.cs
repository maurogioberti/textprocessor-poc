namespace Poc.TextProcessor.IntegrityAssurance.Core.Settings
{
    public static class Endpoints
    {
        public static string BaseUrl = "https://localhost:44382";

        public static class Text
        {
            private static string BaseEndpoint => "Text";

            #region Options Endpoint
            public static string OptionsEndpoint => $"{BaseEndpoint}/Options";
            public static string OptionsInvalidEndpoint => $"{BaseEndpoint}/Options/InvalidRequesttt";
            #endregion

            #region Ordered Text Endpoint
            public static string OrderedTextEndpoint(string text, string orderOption) => $"{BaseEndpoint}/OrderedText?textToOrder={text}&orderOption={orderOption}";
            public static string OrderedTextInvalidEndpoint => $"{BaseEndpoint}/OrderedText/1/2";
            public static string OrderedTextBadRequestEndpoint => $"{BaseEndpoint}/OrderedText?textToOrder=&orderOption=";
            #endregion

            #region Statitics Endpoint
            public static string StatisticsEndpoint(string text) => $"{BaseEndpoint}/Statistics?textToAnalyze={text}";
            public static string StatisticsInvalidEndpoint => $"{BaseEndpoint}/Statistics////";
            public static string StatisticsNoParametersEndpoint => $"{BaseEndpoint}/Statistics";
            #endregion
        }
    }
}