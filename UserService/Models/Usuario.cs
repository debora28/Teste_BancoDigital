﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserService.CustomValidations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UserService.Model
{
    public class Usuario(string nome, string cpf, DateTime dataNasc)
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //Nas propriedades que não precisam de tabela no banco, coloca-se a anotação [NotMapped]
        public string? Nome { get; set; } = nome;
        [Key, MaxLength(11), MinLength(11)]
        public string? Cpf { get; set; } = cpf;
        [Required]
        public DateTime DataNasc { get; set; } = dataNasc;
    }
}
