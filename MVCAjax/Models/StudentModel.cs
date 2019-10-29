﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAjax.Models
{
	public class StudentModel
	{
		[Key]
		public int ID { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Address { get; set; }
	}
}