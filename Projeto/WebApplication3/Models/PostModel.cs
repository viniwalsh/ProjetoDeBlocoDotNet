using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class PostModel
    {
        [Key]
        public Guid PostId { get; set; }
        public DateTime PostCreationTime { get; set; }
        public string PostCreator { get; set; }
        public string PostDetails { get; set; }
        public string PostPicture { get; set; }
        public int PostLikes { get; set; }
        public virtual ICollection<PostComentaryModel> PostComentaries { get; set; }

        public PostModel()
        {
            this.PostComentaries = new List<PostComentaryModel>();
        }
    }
}