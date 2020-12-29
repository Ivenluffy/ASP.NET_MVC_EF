using EMS.IBLL;
using EMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS.WebServer.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        private IUserInfoService service = BLLContainer.Container.Resolve<IUserInfoService>();
        public ActionResult Index()
        {
            List<UserInfo> list = service.GetModels(p => true).ToList();
            return View(list);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(UserInfo obj)
        {
            if (service.Add(obj))
            {
                return Redirect("Index");
            }
            else
            {
                return Content("failure");
            }
        }
        public ActionResult Edit(int Id)
        {
            return View(service.GetModels(p => p.Id == Id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Update(UserInfo obj)
        {
            if (service.Update(obj))
            {
                return Redirect("Index");
            }
            else
            {
                return Content("failure");
            }
        }
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            var staff = service.GetModels(p => p.Id == Id).FirstOrDefault();
            if (service.Delete(staff))
            {
                return Redirect("/User/Index");
            }
            else
            {
                return Content("failure");
            }
        }
        public ActionResult Detail(int Id)
        {
            return View(service.GetModels(p => p.Id == Id).FirstOrDefault());
        }

    }
}