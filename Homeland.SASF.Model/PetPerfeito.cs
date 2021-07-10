namespace Homeland.SASF.Model
{
    public class PetPerfeito
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especie { get; set; }
        public string Sexo { get; set; }
        public string Porte { get; set; }
        public string ImagemPrincipal { get; set; }
        public string ImagemLado { get; set; }
        public string ImagemBrincando { get; set; }
        public string URLPerfil { get; set; }
        public string Descricao { get; set; }
        public string NomeOng { get; set; }
        public string EnderecoONG { get; set; }
        public int NumeroEnderecoONG { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public int CEP { get; set; }

    }

    public class PetPerfeitoApi
    {
        public string nome { get; set; }
        public string especie { get; set; }
        public string sexo { get; set; }
        public string porte { get; set; }
        public string imagem_principal { get; set; }
        public string imagem_lado { get; set; }
        public string imagem_brincando { get; set; }
        public string url_perfil { get; set; }
        public string descricao { get; set; }
        public string nome_ong { get; set; }
        public string endereco_ong { get; set; }
        public int numero_endereco { get; set; }
        public string cidade { get; set; }
        public string bairro { get; set; }
        public string estado { get; set; }
        public int cep { get; set; }
    }


    public class PetRestCharp
    {
        public PetPerfeitoApi[] pets { get; set; }
    }
}
