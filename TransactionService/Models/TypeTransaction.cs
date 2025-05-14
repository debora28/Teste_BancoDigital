using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TransactionService.Models
{
    public class TypeTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerSchema(ReadOnly = true)]
        public int TypeTransactionId { get; set; }
        [Required]
        [StringLength(300)]
        public string? TypeTransactionName { get; set; }
    }
}
