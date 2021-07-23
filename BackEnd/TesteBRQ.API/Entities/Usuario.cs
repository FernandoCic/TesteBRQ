using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBRQ.API.Enums;

namespace TesteBRQ.API.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public ESexo Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
    }
}
