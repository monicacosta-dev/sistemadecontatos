using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; } //gera automaticamente
        [Required(ErrorMessage ="Nome do contato, é obrigatorio!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "E-mail do contato é obrigatorio!")]
        [EmailAddress(ErrorMessage ="E-mail digitado não é valido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Celular do contato é obrigatorio!")]
        [Phone(ErrorMessage ="Celular informado não é valido!")]
        public string Celular { get; set; }

    }
}
