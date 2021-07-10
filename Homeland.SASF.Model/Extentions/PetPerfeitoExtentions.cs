namespace Homeland.SASF.Model
{
    public static class PetPerfeitoExtentions
    {
        public static PetPerfeito ToModel(this PetPerfeitoApi pet)
        {
            return new PetPerfeito
            {
                Nome = pet.nome,
                Especie = pet.especie,
                Sexo = pet.sexo,
                Porte = pet.porte,
                ImagemPrincipal = pet.imagem_principal,
                ImagemLado = pet.imagem_lado,
                ImagemBrincando = pet.imagem_brincando,
                URLPerfil = pet.url_perfil,
                Descricao = pet.descricao,
                NomeOng = pet.nome_ong,
                EnderecoONG = pet.endereco_ong,
                NumeroEnderecoONG = pet.numero_endereco,
                Cidade = pet.cidade,
                Bairro = pet.bairro,
                Estado = pet.estado,
                CEP = pet.cep
            };
        }
    }
}
