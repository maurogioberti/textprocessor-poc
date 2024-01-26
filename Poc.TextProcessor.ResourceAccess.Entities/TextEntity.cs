using Poc.TextProcessor.CrossCutting.Configurations.Database;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poc.TextProcessor.ResourceAccess.Entities
{
    [Table(Tables.Texts)]
    public class TextEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; } = string.Empty;
    }
}