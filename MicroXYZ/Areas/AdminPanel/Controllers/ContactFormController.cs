using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MicroXYZ.Database;
using System.Linq;
using System.Threading.Tasks;

namespace MicroXYZ.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]
    public class ContactFormController : Controller
    {
        private readonly MicroXYZDBContext _context;


        public ContactFormController(MicroXYZDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var contactForms = await _context.ContactForms.OrderByDescending(x => x.CreatedAt).ToListAsync();

            ViewBag.IsActive = true;

            return View(contactForms);
        }
    }
}
