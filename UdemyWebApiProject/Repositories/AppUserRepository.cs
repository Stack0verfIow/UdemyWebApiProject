using UdemyWebApiProject.Data;
using UdemyWebApiProject.Entities;
using UdemyWebApiProject.Interfaces;

namespace UdemyWebApiProject.Repositories
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(DataContext context) : base(context)
        {
        }
    }
}
