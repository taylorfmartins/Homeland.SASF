using System;
using System.Collections.Generic;

namespace Homeland.SASF.Model
{
    public class Funcionario
    {
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public int Setor { get; set; }
        public bool Gestor { get; set; }
        public DateTime DataAdmissao { get; set; }
        public string Cargo { get; set; }
        public TipoNotificacao TipoNotificacao { get; set; }
        public ICollection<Setor> Setores { get; set; }
    }

    public class FuncionarioApi
    {
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public int Setor { get; set; }
        public bool Gestor { get; set; }
        public DateTime DataAdmissao { get; set; }
        public string Cargo { get; set; }
        public string TipoNotificacao { get; set; }
    }
}
