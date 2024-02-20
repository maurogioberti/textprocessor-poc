using FluentNHibernate.Mapping;
using Poc.TextProcessor.CrossCutting.Configurations.Database;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poc.TextProcessor.ResourceAccess.Entities.Mappings
{
    [Table(Tables.TextSorts)]
    public class TextSortEntityMap : ClassMap<TextSortEntity>
    {
        public TextSortEntityMap()
        {
            Table(Tables.TextSorts);
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Option).Column("`Option`").CustomType<string>().Length(24).Not.Nullable();
        }
    }
}