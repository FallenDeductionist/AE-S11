using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAjax.Models;
//using Domain;
//using Service;
using System.Threading.Tasks;

namespace MVCAjax.Controllers
{
    public class StudentController : Controller
    {
		Proxy.StudentProxy proxy = new Proxy.StudentProxy();
        // GET: Student

        public ActionResult IndexRazor()
        {
			var response = Task.Run(() => proxy.GetStudentsAsync());

            return View(response.Result.listado);
        }

		/*
		public ActionResult Index()
		{
			return View();
		}
		*/

		public JsonResult getStudent(string id)
		{
			var response = Task.Run(() => proxy.GetStudentsAsync());

			return Json(response.Result.listado, JsonRequestBehavior.AllowGet);
		}

		/*
		public JsonResult getStudentById(int id)
		{
			return Json(service.GetById(id), JsonRequestBehavior.AllowGet);
		}

		public JsonResult searchStudent(string keyword)
		{
			return Json(service.SearchStudent(keyword), JsonRequestBehavior.AllowGet);
		}

		*/
		[HttpPost]
		public ActionResult createStudent(StudentModel std)
		{
			// service.Insert(std);
			var response = Task.Run(() => proxy.InsertAsync(std));
			string message = response.Result.Mensaje;
			return Json(new { Message = message, JsonRequestBehavior.AllowGet });
		}

		/*
		[HttpPost]
		public ActionResult editStudent(Student std, int id)
		{
			service.Update(std, id);
			string message = "SUCCESS";
			return Json(new { Message = message, JsonRequestBehavior.AllowGet });
		}

		[HttpPost]
		public ActionResult deleteStudent(int id)
		{
			service.Delete(id);
			string message = "SUCCESS";
			return Json(new { Message = message, JsonRequestBehavior.AllowGet });
		}
		*/
	}
}