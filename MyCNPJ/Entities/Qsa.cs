using Newtonsoft.Json;
using System;

namespace MyCNPJ.Entities
{
    public class Qsa
    {
        public Guid Id { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("qual")]
        public string Qual { get; set; }

        [JsonProperty("pais_origem")]
        public string PaisOrigem { get; set; }

        [JsonProperty("nome_rep_legal")]
        public string NomeRepLegal { get; set; }

        [JsonProperty("qual_rep_legal")]
        public string QualRepLegal { get; set; }
    }
}
