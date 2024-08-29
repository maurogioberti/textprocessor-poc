namespace Poc.TextProcessor.IntegrityAssurance.Tests.Helpers
{
    public static class ValidationHelper
    {
        public static void AssertIntegrityScriptNotNull<T>(T textItem, int expectedId) where T : class
        {
            Assert.That(textItem, Is.Not.Null, $"Integrity Assurance Test Script with Id {expectedId} could not be found.");
        }
    }
}