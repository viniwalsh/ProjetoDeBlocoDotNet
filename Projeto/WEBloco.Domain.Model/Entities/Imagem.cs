using System.ComponentModel;
using System.Text.Json.Serialization;

namespace WEBloco.Domain.Model.Entities
{
    public class Imagem
    {
        public int Id { get; set; }

        [DisplayName("Foto Url")]
        public string FotoUri { get; set; }

        [JsonIgnore]
        public Heroi Heroi { get; set; }

    }
}
