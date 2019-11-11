using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;
using AutoMapper;

namespace API.Repository
{
	public class EntityMapper<TSource, IDestination> where TSource : class where IDestination : class
	{
		public EntityMapper()
		{
			Mapper.CreateMap<Models.StudentModel, Student>();
			Mapper.CreateMap<Student, Models.StudentModel>();
		}
		public IDestination Translate(TSource obj)
		{
			return Mapper.Map<IDestination>(obj);
		}
	}
}