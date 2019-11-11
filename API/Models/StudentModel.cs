using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Models
{
	public class StudentModel
	{
		[Key]
		public int studentID { get; set; }
		public string studentName { get; set; }
		public string studentAddress { get; set; }
	}
}