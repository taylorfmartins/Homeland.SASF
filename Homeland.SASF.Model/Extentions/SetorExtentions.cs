namespace Homeland.SASF.Model
{
    public static class SetorExtentions
    {
        public static SetorApi ToApi(this Setor setor)
        {
            return new SetorApi
            {
                Id = setor.Id,
                Nome = setor.Nome,
                MatriculaResponsavel = setor.MatriculaResponsavel
            };
        }
    }
}
