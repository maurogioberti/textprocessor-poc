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
        [Column(TypeName = "nvarchar(24)")]
        public required string Option { get; set; }

        [NotMapped]
        public SortOption OptionEnum
        {
            get => (SortOption)Enum.Parse(typeof(SortOption), Option, true);
            set => Option = value.ToString();
        }
    }
}