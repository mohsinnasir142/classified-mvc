using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Classified.Models;
using System.IO;
using System.Data;

namespace Classified.Controllers
{
    public class AdsController : Controller
    {
        //
        // GET: /Ads/
        UserManager objUserManager = new UserManager();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult postAd()
        {
            return View();
        }
        [Authorize]
        public ActionResult Autos()
        {
            ViewBag.city = objUserManager.getAllCities();
            ViewBag.warranty = objUserManager.getWarranty();
            ViewBag.userType = objUserManager.getUserType();
            ViewBag.adType = objUserManager.getAdType();
            ViewBag.subCategory = objUserManager.getSubCategories("Autos");
            return View();
        }
        [Authorize]
        [HttpPost]
        public void Autos(AutosModel model , List<HttpPostedFileBase> fileUpload)
        {
            DataTable personalInfoDT = objUserManager.getPersonalInformation(User.Identity.Name);
            string updatedFileName = null;
            foreach (HttpPostedFileBase file in fileUpload)
            {
                if (file !=null && Array.Exists(model.images.Split(','), s => s.Equals(file.FileName)))
                {
                        var filename = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images/DBImages/"), filename);
                        file.SaveAs(path);
                        updatedFileName = updatedFileName + User.Identity.Name + filename + ",";
                }
            }
            // No file Found
            if (fileUpload.Count ==1)
            {
                model.images = "../../Images/DBImages/notfound.jpg";
            }
            model.images = updatedFileName.TrimEnd(',');
            model.postedBy = User.Identity.Name;
            model.category = "Autos";
            model.phone = personalInfoDT.Rows[0]["phoneNo"].ToString();
            model.email = personalInfoDT.Rows[0]["email"].ToString();
            model.postedDate = DateTime.Now.ToString();
            model.latitude = personalInfoDT.Rows[0]["latitude"].ToString();
            model.altitude = personalInfoDT.Rows[0]["longitude"].ToString();
            model.unCommonAttributes = null;
        }
    }
}
