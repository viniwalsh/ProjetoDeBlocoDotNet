using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace WEBloco.Domain.Model.Entities
{
    public class Heroi
    {
        public int HeroiId { get; set; }
        public string Nome { get; set; }

        public string Codinome { get; set; }

        public string Poder { get; set; }

        [DataType(DataType.Date)]
        public DateTime Lancamento { get; set; }
        public ICollection<Imagem> Imagens { get; set; }

        [NotMapped]
        public List<string> ImagensBase64 { get; set; } = new List<string>();
    }
}
