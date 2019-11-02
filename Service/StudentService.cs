using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Infraestructure;

namespace Service
{
	public class StudentService
	{
		public List<Student> Get()
		{
			List<Student> students = null;
			using (var context = new SchoolContext())
			{
				students = context.Students.Where(s => s.state).ToList();
			}
			return students;
		}

		public Student GetById(int ID)
		{
			Student student = null;
			using (var context = new SchoolContext())
			{
				student = context.Students.Find(ID);
			}
			return student;
		}

		public void Insert(Student student)
		{
			using (var context = new SchoolContext())
			{
				var newStudent = new Student();

				newStudent.studentName = student.studentName;
				newStudent.studentAddress = student.studentAddress;
				newStudent.lastName = student.lastName;
				newStudent.studentCode = student.studentCode;
				newStudent.creationDate = DateTime.Now;
				newStudent.editDate = DateTime.Now;
				newStudent.state = true;

				context.Students.Add(newStudent);
				context.SaveChanges();
			}
		}

		public void Update(Student student, int ID)
		{
			using(var context = new SchoolContext())
			{
				var newStudent = context.Students.Find(ID);

				newStudent.studentName = student.studentName;
				newStudent.studentAddress = student.studentAddress;
				newStudent.lastName = student.lastName;
				newStudent.studentCode = student.studentCode;
				newStudent.editDate = DateTime.Now;

				context.SaveChanges();
			}
		}

		public List<Student> SearchStudent(string keyword)
		{
			using (var context = new SchoolContext())
			{
				var data = context.Students.Where(f =>
				f.studentName.StartsWith(keyword) || f.lastName.StartsWith(keyword) && f.state).ToList();
				return data;
			}
			
		}

		public void Delete(int ID)
		{
			using ( var context = new SchoolContext())
			{
				var newStudent = context.Students.Find(ID);
				newStudent.state = false;
				newStudent.editDate = DateTime.Now;
				context.SaveChanges();
			}
		}

	}
}
