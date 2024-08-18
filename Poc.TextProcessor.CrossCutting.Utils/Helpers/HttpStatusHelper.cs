namespace Poc.TextProcessor.CrossCutting.Utils.Helpers
{
    public static class HttpStatusHelper
    {
        public static void NotFoundException(object entity, string entityName)
        {
            if (entity == null)
            {
                throw new KeyNotFoundException($"{entityName} not found.");
            }
        }
    }
}
