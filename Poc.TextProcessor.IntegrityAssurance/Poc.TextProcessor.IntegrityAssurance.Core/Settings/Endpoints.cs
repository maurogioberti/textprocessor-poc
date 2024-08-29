namespace Poc.TextProcessor.IntegrityAssurance.Core.Settings
{
    public static class Endpoints
    {
        public static class Text
        {
            private static string BaseEndpoint => "Text";

            #region Options Endpoints
            public static string OptionsEndpoint => $"{BaseEndpoint}/Options";
            public static string OptionsInvalidEndpoint => $"{BaseEndpoint}/Options/InvalidRequesttt";
            #endregion

            #region Ordered Text Endpoints
            public static string OrderedTextEndpoint(string text, string orderOption) => $"{BaseEndpoint}/OrderedText?textToOrder={text}&orderOption={orderOption}";
            public static string OrderedTextInvalidEndpoint => $"{BaseEndpoint}/OrderedText/1/2";
            public static string OrderedTextBadRequestEndpoint => $"{BaseEndpoint}/OrderedText?textToOrder=&orderOption=";
            #endregion

            #region Get Text Endpoints
            public static string GetEndpoint(int id) => $"{BaseEndpoint}/Get?id={id}";
            public static string GetInvalidEndpointEndpoint => $"{BaseEndpoint}/Get////";
            public static string GetIdTooLongEndpoint => $"{BaseEndpoint}/Get?id=4556566545656655644654656454566545645";
            public static string GetAllEndpoint => $"{BaseEndpoint}/GetAll";
            #endregion

            #region Delete Text Endpoints
            public static string DeleteEndpoint(int id) => $"{BaseEndpoint}/Delete?id={id}";
            public static string DeleteInvalidEndpoint => $"{BaseEndpoint}/Delete////";
            public static string DeleteIdTooLongParametersEndpoint => $"{BaseEndpoint}/Delete?id=4556566545656655644654656454566545645";
            #endregion

            #region Statitics Endpoints
            public static string StatisticsEndpoint(string text) => $"{BaseEndpoint}/Statistics?textToAnalyze={text}";
            public static string StatisticsInvalidEndpoint => $"{BaseEndpoint}/Statistics////";
            public static string StatisticsNoParametersEndpoint => $"{BaseEndpoint}/Statistics";
            #endregion
        }
    }
}