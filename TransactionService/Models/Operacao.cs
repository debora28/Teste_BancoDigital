using TransactionService.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TransactionService.Models
{
    public class Operacao
    {
        [Key]
        public int IdOperacao { get; set; }
        [NotMapped]
        static int nextId;
        [Required]
        public string ? TipoOperacao { get; set; }
        public DateTime DataOperacao { get; set; }
        //[Timestamp]
        //remover versão daqui:
        //public byte[] ? Versao { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Valor { get; set; }
        //[NotMapped]
        //[JsonIgnore]
        //public virtual Conta? Conta { get; set; }
        ////[ForeignKey(nameof(Conta))]
        ////public int? IdConta { get; set; }

        Operacao()
        {
            IdOperacao = Interlocked.Increment(ref nextId);
        }
    }
}
