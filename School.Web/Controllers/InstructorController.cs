using Microsoft.AspNetCore.Mvc;

namespace School.Web.Controllers;

public class InstructorController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
