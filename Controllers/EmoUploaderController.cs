using CognitiveServices.Models;
using CognitiveServicesAzure.Models;
using System;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CognitiveServicesAzure.Controllers
{
    public class EmoUploaderController : Controller
    {
        string serverFolderPath;
        EmoHelper emoHelper;
        string key;
        CognitiveServicesAzureContext db = new CognitiveServicesAzureContext();

        public EmoUploaderController()
        {
            key = ConfigurationManager.AppSettings["SERVICES_KEY"];
            serverFolderPath = ConfigurationManager.AppSettings["UPLOADS_DIR"];
            emoHelper = new EmoHelper(key);
        }
 
        // GET: EmoUploader
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(HttpPostedFileBase file)
        {
            if (file?.ContentLength > 0)
            {
                var pictureName = Guid.NewGuid().ToString();
                pictureName += Path.GetExtension(file.FileName);
                var route = Server.MapPath(serverFolderPath);
                route = route + "/" + pictureName;
                file.SaveAs(route);

                var emoPicture = await emoHelper.DetectAndExtractFacesAsync(file.InputStream);
                emoPicture.Name = file.FileName;
                emoPicture.Path = $"{serverFolderPath}/{pictureName}";

                db.EmoPictures.Add(emoPicture);
                await db.SaveChangesAsync();
                return RedirectToAction("Details", "EmoPictures", new { id = emoPicture.Id });
            }
            else
            {
                ViewBag.Error = "error <br>";
                return View("Index");
            }
        }
    }
}