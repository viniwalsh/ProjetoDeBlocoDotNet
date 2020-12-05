using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBlocoApi.Models
{
    public class Amigo
    {
        public int AmigoId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public ICollection<Imagem> Imagens { get; set; }

        [NotMapped]
        public List<string> ImagensBase64 { get; set; }

    }
}
