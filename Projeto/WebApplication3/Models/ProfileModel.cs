using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Models
{
    public class ProfileModel
    {
        [Key]
        public Guid ProfileId { get; set; }
        public string ProfileLoginId { get; set; }
        [Display(Name = "Nome de usuário")]
        public string ProfileUserName { get; set; }
        [Display(Name = "Foto de perfil")]
        public string ProfilePicture { get; set; }
        [Display(Name = "Foto de capa")]
        public string ProfileBackgroundPicture { get; set; }
        [Display(Name = "Gênero")]
        public string ProfileGender { get; set; }
        [Display(Name = "Data e hora da criação")]
        public DateTime ProfileCreationTime { get; set; }
        [Display(Name = "E-mail do perfil")]
        public string ProfileEmail { get; set; }

        public virtual ICollection<ProfileModel> ProfileFollowing { get; set; }

        public virtual ICollection<PostModel> ProfilePosts { get; set; }

        public ProfileModel()
        {
            this.ProfileFollowing = new List<ProfileModel>();
            this.ProfilePosts = new List<PostModel>();
        }
        [NotMapped]
        public List<SelectListItem> ProfileGenderList { get; set; } = new List<SelectListItem>() {
                new SelectListItem()
                {
                    Text = "Masculino",
                    Value = "Masculino",
                },
                new SelectListItem()
                {
                    Text = "Feminino",
                    Value = "Feminino",
                },
                new SelectListItem()
                {
                    Text = "Outros",
                    Value = "Outros",
                }
            }
            ;
    }
}