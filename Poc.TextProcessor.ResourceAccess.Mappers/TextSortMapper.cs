namespace Poc.TextProcessor.ResourceAccess.Mappers
{
    public class TextMapper : ITextMapper
    {
        public Contracts.Text Map(Domains.Text text) => new Contracts.Text
        {
            Id = text.Id,
            Content = text.Content
        };
    }
}