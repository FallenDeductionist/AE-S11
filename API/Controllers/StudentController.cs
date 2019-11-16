using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Service;
using Domain;
using API.Models;
using API.Repository;
using System.Web.Http.Results;

namespace API.Controllers
{
    public class StudentController : ApiController
    {
		StudentService Service;
		public StudentController()
		{
			Service = new StudentService();
		}

		// GET: Student
		[HttpGet]
		public JsonResult<List<StudentModel>> GetAllStudents()
		{
			EntityMapper<Student, StudentModel> mapObj = new EntityMapper<Student, StudentModel>();
			List<Student> studentList = Service.Get();
			List<StudentModel> Students = new List<StudentModel>();
			foreach (var item in studentList)
			{
				Students.Add(mapObj.Translate(item));
			}
			return Json<List<StudentModel>>(Students);
		}
		[HttpGet]
		public JsonResult<StudentModel> GetStudent(int id)
		{
			EntityMapper<Student, StudentModel> mapObj = new EntityMapper<Student, StudentModel>();
			Student dalStudent = Service.GetById(id);
			StudentModel Students = new StudentModel();
			Students = mapObj.Translate(dalStudent);
			return Json<StudentModel>(Students);
		}

		[HttpGet]
		public JsonResult<List<StudentModel>> SearchStudent(string keyword)
		{
			EntityMapper<Student, StudentModel> mapObj = new EntityMapper<Student, StudentModel>();
			List<Student> studentList = Service.SearchStudent(keyword);
			List<StudentModel> Students = new List<StudentModel>();
			foreach (var item in studentList)
			{
				Students.Add(mapObj.Translate(item));
			}
			return Json<List<StudentModel>>(Students);
		}

		[HttpPost]
		public bool InsertStudent(StudentModel Student)
		{
			bool status = false;
			if (ModelState.IsValid)
			{
				EntityMapper<StudentModel, Student> mapObj = new EntityMapper<StudentModel, Student>();
				Student StudentObj = new Student();
				StudentObj = mapObj.Translate(Student);
				Service.Insert(StudentObj);
				status = true;
			}
			return status;
		}
		[HttpPost]
		public bool UpdateStudent(StudentModel Student, int id)
		{
			bool status = false;
			EntityMapper<StudentModel, Student> mapObj = new EntityMapper<StudentModel, Student>();
			Student StudentObj = new Student();
			StudentObj = mapObj.Translate(Student);
			Service.Update(StudentObj, id);
			status = true;
			return status;
		}
		[HttpDelete]
		public bool DeleteStudent(int id)
		{
			bool status = false;
			Service.Delete(id);
			status = true;
			return status;
		}
    }
}
