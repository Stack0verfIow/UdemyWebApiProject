using System.ComponentModel.DataAnnotations;

namespace UdemyWebApiProject.Entities
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
    }
}
