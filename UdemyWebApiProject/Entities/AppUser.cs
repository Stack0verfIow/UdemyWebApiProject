using System.ComponentModel.DataAnnotations;

namespace UdemyWebApiProject.Entities
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
