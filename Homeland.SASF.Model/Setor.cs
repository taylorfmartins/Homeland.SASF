namespace Homeland.SASF.Model
{
    public class Setor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int MatriculaResponsavel { get; set; }
        public Funcionario Responsavel { get; set; }
    }

    public class SetorApi
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int MatriculaResponsavel { get; set; }
    }
}
