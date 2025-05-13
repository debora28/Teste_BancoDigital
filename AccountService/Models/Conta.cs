using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using AccountService.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace AccountService.Models
{
    public class Conta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerSchema(ReadOnly = true)]
        public int IdConta { get; set; }
        [Required]
        public string Agencia { get; set; } = string.Empty;
        //[Index]
        //[JsonIgnore]
        public int NumConta { get; private set; }
        [NotMapped]
        static int nextConta;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Saldo { get; set; }
        public bool Ativa { get; set; }
        public bool Bloqueada { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal LimiteDiario { get; set; }
        //[NotMapped]
        //[JsonIgnore]
        //public virtual Usuario? Usuario { get; set; }
        //[ForeignKey(nameof(Usuario))]
        //public int? UsuarioId { get; set; }
        //[JsonIgnore]
        //public ICollection<Operacao>? Operacoes { get; set; }
        //public Conta(Usuario usuario, string agencia, int numConta, decimal saldo, bool ativa, bool flagBloqueio, decimal limiteDiario)
        //{
        //    this.Usuario = usuario;
        //    this.Agencia = agencia;
        //    this.NumConta = numConta;
        //    this.Saldo = saldo;
        //    this.Ativa = ativa;
        //    this.Bloqueada = flagBloqueio;
        //    this.LimiteDiario = limiteDiario;
        //}
        public Conta()
        {
            NumConta = Interlocked.Increment(ref nextConta);
        }

        //public decimal ConsultarSaldo()
        //{
        //    return this.Saldo;
        //}

        //public void ExibirDadosConta()
        //{
        //    Console.WriteLine($"Agência: {this.Agencia}\n" +
        //        $"Conta: {this.NumConta}\n" +
        //        //$"Cliente: {this.Cliente.Nome}\n" +
        //        $"Saldo: {this.Saldo}\n" +
        //        $"Limite Diário: {this.LimiteDiario}\n" +
        //        $"Aviso: {(this.Bloqueada == true ? "Conta Desbloqueada" : "Conta Bloqueada")}\n"
        //        );
        //}
        ////Colocar os métodos separados em "Serviços".
        //public decimal Sacar(decimal valor, Conta conta)
        //{
        //    if (conta.Ativa == true && conta.Bloqueada == false && (conta.Saldo - valor) >= 0 && valor <= conta.LimiteDiario)
        //    {
        //        this.Saldo -= valor;
        //    }
        //    else if (conta.Ativa == false)
        //    {
        //        Console.WriteLine("Operação indisponível. Esta conta está inativa.");
        //    }
        //    else if (conta.Bloqueada == true)
        //    {
        //        Console.WriteLine("Operação indisponível. Esta conta está bloqueada.");
        //    }
        //    else if ((conta.Saldo - valor) < 0)
        //    {
        //        Console.WriteLine("Saldo insuficiente.");
        //    }
        //    else if (valor > conta.LimiteDiario)
        //    {
        //        Console.WriteLine("Operação não realizada. Esse valor excede o limite diário de movimentação.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Não foi possível realizar esta operação. Por favor, entre em contato com a instituição financeira.");
        //    }
        //    return conta.Saldo;
        //}

        //public decimal Depositar(decimal valor, Conta conta)
        //{
        //    if (conta.Ativa == true && conta.Bloqueada == false && valor > 0)
        //    {
        //        conta.Saldo += valor;
        //    }
        //    else if (conta.Ativa == false)
        //    {
        //        Console.WriteLine("Operação indisponível. Esta conta está inativa.");
        //    }
        //    else if (conta.Bloqueada == true)
        //    {
        //        Console.WriteLine("Operação indisponível. Esta conta está bloqueada.");
        //    }
        //    else if (valor <= 0)
        //    {
        //        Console.WriteLine("Valor insuficiente.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Não foi possível realizar esta operação. Por favor, entre em contato com a instituição financeira.");
        //    }
        //    return conta.Saldo;
        //}

        //public string BloquearConta(Conta conta)
        //{
        //    conta.Bloqueada = !conta.Bloqueada;

        //    if (conta.Bloqueada)
        //    {
        //        return "Conta bloqueada para sua segurança.";
        //    }
        //    else
        //    {
        //        return "Conta desbloqueada e pronta para uso.";
        //    }
        //}

        //public decimal DefinirLimite(decimal limite, Conta conta)
        //{
        //    if (limite >= 0)
        //    {
        //        conta.LimiteDiario = limite;
        //        return conta.LimiteDiario;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Valor não permitido.");
        //        return conta.LimiteDiario;
        //    }
        //}
    }
}
