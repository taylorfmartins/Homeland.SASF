namespace Homeland.SASF.Model
{
    public static class FuncionarioExtentions
    {
        public static FuncionarioApi ToApi(this Funcionario funcionario)
        {
            return new FuncionarioApi
            {
                Matricula = funcionario.Matricula,
                Nome = funcionario.Nome,
                Telefone = funcionario.Telefone,
                Email = funcionario.Email,
                CPF = funcionario.CPF,
                Endereco = funcionario.Endereco,
                Setor = funcionario.Setor,
                Gestor = funcionario.Gestor,
                DataAdmissao = funcionario.DataAdmissao,
                Cargo = funcionario.Cargo,
                TipoNotificacao = funcionario.TipoNotificacao.ParaString()
            };
        }
    }
}
