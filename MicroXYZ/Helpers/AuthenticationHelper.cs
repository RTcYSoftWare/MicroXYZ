using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MicroXYZ.Database;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MicroXYZ.Helpers
{
    public class AuthenticationHelper : IAuthenticationHelper
    {        
        private readonly IHttpContextAccessor _contextAccessor;        
        private readonly MicroXYZDBContext _context;


        public AuthenticationHelper(IHttpContextAccessor contextAccessor, MicroXYZDBContext context)
        {
            _contextAccessor = contextAccessor;
            _context = context;
        }

        public async Task<Admin> GetCurrentAdmin()
        {
            Admin admin = new Admin();
            string adminGuid = "";

            var identity = _contextAccessor.HttpContext.User.Claims;

            if (identity != null)
            {
                adminGuid = identity.FirstOrDefault(x => x.Type == "guid")?.Value;
            }


            if (adminGuid != null)
            {
                admin = await _context.Admins.FirstOrDefaultAsync(x=> x.Guid.ToString() == adminGuid && x.IsActive == true);
            }

            return admin;
        }

        public async Task CookieAuthentication(Admin admin)
        {
            var claims = new List<Claim>
                {
                    new Claim("guid", admin.Guid.ToString()),
                    //new Claim("NameSurname", was.NameSurname),
                    //new Claim(ClaimTypes.Role, "Administrator"),
                };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties();

            await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
        }
    }
}
