using DataTablesParser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhotoAlbum.Models;
using PhotoAlbum.Services;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAlbum.Controllers
{
    public class HomeController : Controller
    {
        public IDataService DataService { get; }
        public ILogger<HomeController> Logger { get; }

        public HomeController(IDataService dataService, ILogger<HomeController> logger)
        {
            DataService = dataService;
            Logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Data()
        {
            try
            {
                var photoalbums = await DataService.GetPhotosAsync();

                var parser = new Parser<PhotoAlbumModel>(Request.Form, photoalbums.AsQueryable());

                return Json(parser.Parse());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex.InnerException);
                throw ex;
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
