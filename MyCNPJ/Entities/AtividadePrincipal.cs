using Newtonsoft.Json;
using System;

namespace MyCNPJ.Entities
{
    public class AtividadesPrincipais
    {
        public Guid Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
