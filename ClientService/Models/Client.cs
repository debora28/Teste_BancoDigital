using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

namespace ClientService.Model
{
    public class Client(string clientName, string cpfCnpj, DateTime dateBirth)
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerSchema(ReadOnly = true)]
        public int ClientId { get; set; }
        [Required]
        [StringLength(500)]
        public string? ClientName { get; set; } = clientName;
        [Required]
        [Key, MaxLength(14), MinLength(11)]
        public string? CpfCnpj { get; set; } = cpfCnpj;
        [Required]
        public DateTime DateBirth { get; set; } = dateBirth;
    }
}
