using System;

namespace Homeland.SASF.Model
{
    public class Ocorrencia
    {
        public int numero { get; set; }
        public int matricula { get; set; }
        public DateTime data { get; set; }
        public string respostaEstado { get; set; }
        public string respostaSintomas { get; set; }
        public string respostaVacina { get; set; }
        public bool solicitarHistorico { get; set; }
    }
}