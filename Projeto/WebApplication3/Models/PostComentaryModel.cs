using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class PostComentaryModel
    {
        [Key]
        public Guid PostComentaryId { get; set; }
        public DateTime PostComentaryCreationTime { get; set; }
        public string PostComentaryCreator { get; set; }
        public string PostComentaryContent { get; set; }
        public int PostComentaryLikes { get; set; }
    }
}