using EMS.IBLL;
using EMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS.WebServer.Controllers
{
    public class DeptController : Controller
    {
        // GET: Dept
        private IDepartmentService service = BLLContainer.Container.Resolve<IDepartmentService>();
        public ActionResult Index()
        {
            List<Department> list = service.GetModels(p => true).ToList();
            return View(list);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Department obj)
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
        public ActionResult Update(Department obj)
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
            var obj = service.GetModels(p => p.Id == Id).FirstOrDefault();
            if (service.Delete(obj))
            {
                return Redirect("/Dept/Index");
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