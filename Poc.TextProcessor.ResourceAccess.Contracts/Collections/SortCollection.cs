namespace Poc.TextProcessor.ResourceAccess.Contracts.Collections
{
    public class SortCollection
    {
        public SortCollection(IEnumerable<Sort> items, int totalCount)
        {
            Items = items;
            TotalCount = totalCount;
        }

        public IEnumerable<Sort> Items { get; private set; }
        public int TotalCount { get; private set; }
    }
}