using Poc.TextProcessor.CrossCutting.Configurations.Database;
using Poc.TextProcessor.CrossCutting.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poc.TextProcessor.ResourceAccess.Entities
{
    [Table(Tables.TextSorts)]
    public class TextSortEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public SortOption Option { get; set; }
    }
}