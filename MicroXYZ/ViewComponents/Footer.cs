using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MicroXYZ.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroXYZ.ViewComponents
{
    public class Footer : ViewComponent
    {
        private readonly MicroXYZDBContext _context;

        public Footer(MicroXYZDBContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            List<SocialMediaLink> socialMediaLinks = _context.SocialMediaLinks.Where(x => x.IsActive == true).ToList();

            //PaginationModel paginationModel = new PaginationModel();
            //paginationModel.Page = page;
            //paginationModel.TotalPageQuantity = CalculateTotalPageNumber(totalObjectNumber, quantityToDisplay);
            //paginationModel.PageRoute = pageRoute;
            //paginationModel.NextPage = CalculateNextPage(page, paginationModel.TotalPageQuantity);
            //paginationModel.PreviousPage = CalculatePreviousPage(page);
            //paginationModel.ShowedPages = CalculatePageList(page, paginationModel.TotalPageQuantity);

            return View(socialMediaLinks);
        }
    }
}
