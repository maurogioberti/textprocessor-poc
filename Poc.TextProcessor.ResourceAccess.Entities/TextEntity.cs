using Poc.TextProcessor.CrossCutting.Configurations.Database;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Poc.TextProcessor.ResourceAccess.Entities
{
    [Table(Tables.Texts)]
    public class TextEntity
    {
        [Key]
        public virtual int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        public virtual string Content { get; set; } = string.Empty;
    }
}