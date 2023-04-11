using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApiEF.Models
{
    [Table("[User]")]
    public class User
    {
        public User()
        {
            Roles = new List<Role>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
        //Na hora de salvar não inclui
        //[Write(false)]
        public List<Role> Roles { get; set; }
    }
}