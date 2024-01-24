using ArticleShop.Models.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArticleShop.Controllers
{
    [Authorize(Roles = "SysOp")]
    public class UsersController : Controller
    {
        private readonly ShopDbContext _context;

        public UsersController(ShopDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }
    }
}
