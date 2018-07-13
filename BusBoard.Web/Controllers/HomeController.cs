using System.Web.Mvc;
using BusBoard.Web.Models;
using BusBoard.Web.ViewModels;

namespace BusBoard.Web.Controllers
{
    public class HomeController : Controller
    {
    public ActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public ActionResult BusInfo(PostcodeSelection selection)
    {
            try
            {
                var info = new BusInfo(selection.Postcode);
                return View(info);
            }
            catch
            {
                return View("Error");
            }
    }


    public ActionResult About()
    {
        ViewBag.Message = "Information about this site";

        return View();
    }

    public ActionResult Contact()
    {
        ViewBag.Message = "Contact us!";

        return View();
    }
    }
}