using UdemyWebApiProject.Entities;

namespace UdemyWebApiProject.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser appUser);
    }
}
