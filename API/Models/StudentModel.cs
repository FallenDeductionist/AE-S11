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
		[Required]
		public string studentName { get; set; }
		[Required]
		public string studentAddress { get; set; }
		public string LastName { get; set; }
		public int StudentCode { get; set; }
		public DateTime CreationDate { get; set; }
		public DateTime EditDate { get; set; }
		public bool State { get; set; }
	}
}