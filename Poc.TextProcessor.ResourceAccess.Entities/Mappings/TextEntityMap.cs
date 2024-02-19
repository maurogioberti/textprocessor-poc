using FluentNHibernate.Mapping;
using Poc.TextProcessor.CrossCutting.Configurations.Database;

namespace Poc.TextProcessor.ResourceAccess.Entities.Mappings
{
    public class TextEntityMap : ClassMap<TextEntity>
    {
        public TextEntityMap()
        {
            Table(Tables.Texts);
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Content).Length(1000).Not.Nullable();
        }
    }
}