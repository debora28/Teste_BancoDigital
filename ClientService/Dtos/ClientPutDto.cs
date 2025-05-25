using System.ComponentModel.DataAnnotations;

namespace ClientService.Dtos
{
    public class ClientPutDto
    {
        [Required]
        [StringLength(500)]
        public string? ClientName { get; set; }
        [Required]
        public DateTime DateBirth { get; set; }
    }
}
