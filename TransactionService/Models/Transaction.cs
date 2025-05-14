using TransactionService.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace TransactionService.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerSchema(ReadOnly = true)]
        public int TransactionId{ get; set; }
        public DateTime TransactionDate { get; set; } =  DateTime.Now;
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Amount { get; set; }
        [Required]
        public int AccountId { get; set; }
        [Required]
        public int TypeTransactionId { get; set; }
    }
}
