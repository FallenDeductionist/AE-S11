using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAjax.Models;
using Domain;
using Service;

namespace MVCAjax.Controllers
{
    public class StudentController : Controller
    {
		private StudentService service = new StudentService();
        // GET: Student

        public ActionResult IndexRazor()
        {
			var model = (from c in service.Get()
						 select new StudentModel
						 {
							 ID = c.studentID,
							 Address = c.studentAddress,
							 Name = c.studentName,
							 LastName = c.lastName,
							 StudentCode = c.studentCode,
							 CreationDate = c.creationDate,
							 EditDate = c.editDate,
							 State = c.state
						 }).ToList();

            return View(model);
        }

		public ActionResult Index()
		{
			return View();
		}

		public JsonResult getStudent(string id)
		{
			return Json(service.Get(), JsonRequestBehavior.AllowGet);
		}

		public JsonResult getStudentById(int id)
		{
			return Json(service.GetById(id), JsonRequestBehavior.AllowGet);
		}


		public JsonResult searchStudent(string keyword)
		{
			return Json(service.SearchStudent(keyword), JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public ActionResult createStudent(Student std)
		{
			service.Insert(std);
			string message = "SUCCESS";
			return Json(new { Message = message, JsonRequestBehavior.AllowGet });
		}

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
	}
}