using MicroXYZ.Database;
using System.Threading.Tasks;

namespace MicroXYZ.Helpers
{
    public interface IAuthenticationHelper
    {
        public Task<Admin> GetCurrentAdmin();
        public Task CookieAuthentication(Admin admin);
    }
}
