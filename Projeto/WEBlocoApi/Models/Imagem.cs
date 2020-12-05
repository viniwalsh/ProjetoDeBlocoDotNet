using System.ComponentModel;

namespace WEBlocoApi.Models
{
    public class Imagem
    {
        public int Id { get; set; }

        [DisplayName("Foto Url")]
        public string FotoUri { get; set; }

        public int? AmigoId { get; set; }
        public Amigo Amigo { get; set; }
    }
}
