using MVCAjax.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MVCAjax.Proxy
{
	public class StudentProxy
	{
		public async Task<ResponseProxy<StudentModel>> GetStudentsAsync()
		{
			var client = new HttpClient();
			var urlBase = "https://localhost:44301";
			client.BaseAddress = new Uri(urlBase);

			var url = string.Concat(urlBase, "/Api", "/Student", "/GetAllStudents");
			var response = client.GetAsync(url).Result;
			if (response.StatusCode == HttpStatusCode.OK)
			{
				var result = await response.Content.ReadAsStringAsync();
				var students = JsonConvert.DeserializeObject<List<StudentModel>>(result);
				return new ResponseProxy<StudentModel>
				{
					Exitoso = true,
					Codigo = (int)HttpStatusCode.OK,
					Mensaje = "Exito",
					listado = students
				};
			}
			else
			{
				return new ResponseProxy<StudentModel>
				{
					Codigo = (int)response.StatusCode,
					Mensaje = "Error"
				};
			}
		}

		public async Task<ResponseProxy<StudentModel>> GetByIdAsync(int id)
		{
			var client = new HttpClient();
			var urlBase = "https://localhost:44301";
			client.BaseAddress = new Uri(urlBase);

			var url = string.Concat(urlBase, "/Api", "/Student", "/GetStudent/", id);
			var response = client.GetAsync(url).Result;
			if (response.StatusCode == HttpStatusCode.OK)
			{
				var result = await response.Content.ReadAsStringAsync();
				var student = JsonConvert.DeserializeObject<List<StudentModel>>(result);
				return new ResponseProxy<StudentModel>
				{
					Exitoso = true,
					Codigo = (int)HttpStatusCode.OK,
					Mensaje = "Exito",
					listado = student
				};
			}
			else
			{
				return new ResponseProxy<StudentModel>
				{
					Codigo = (int)response.StatusCode,
					Mensaje = "Error"
				};
			}
		}

		public async Task<ResponseProxy<StudentModel>> SearchAsync(string keyword)
		{
			var client = new HttpClient();
			var urlBase = "https://localhost:44301";
			client.BaseAddress = new Uri(urlBase);

			var url = string.Concat(urlBase, "/Api", "/Student", "/SearchStudent?keyword", keyword);
			var response = client.GetAsync(url).Result;

			if (response.StatusCode == HttpStatusCode.OK)
			{
				var result = await response.Content.ReadAsStringAsync();
				var students = JsonConvert.DeserializeObject<List<StudentModel>>(result);
				return new ResponseProxy<StudentModel>
				{
					Exitoso = true,
					Codigo = (int)HttpStatusCode.OK,
					Mensaje = "Exito",
					listado = students
				};
			}
			else
			{
				return new ResponseProxy<StudentModel>
				{
					Codigo = (int)response.StatusCode,
					Mensaje = "Error"
				};
			}
		}

		public async Task<ResponseProxy<StudentModel>> UpdateAsync(int id, StudentModel model)
		{
			var request = JsonConvert.SerializeObject(model);
			var content = new StringContent(request, Encoding.UTF8, "application/json");

			var client = new HttpClient();
			var urlBase = "https://localhost:44301";
			client.BaseAddress = new Uri(urlBase);

			var url = string.Concat(urlBase, "/Api", "/Student", "/UpdateStudent/", id);
			var response = client.PostAsync(url, content).Result;

			if (response.StatusCode == HttpStatusCode.OK)
			{
				var result = await response.Content.ReadAsStringAsync();
				var student = JsonConvert.DeserializeObject<List<StudentModel>>(result);
				return new ResponseProxy<StudentModel>
				{
					Exitoso = true,
					Codigo = (int)HttpStatusCode.OK,
					Mensaje = "Exito",
					listado = student
				};
			}
			else
			{
				return new ResponseProxy<StudentModel>
				{
					Codigo = (int)response.StatusCode,
					Mensaje = "Error"
				};
			}
		}
		public async Task<ResponseProxy<StudentModel>> InsertAsync(StudentModel model)
		{
			var request = JsonConvert.SerializeObject(model);
			var content = new StringContent(request, Encoding.UTF8, "application/json");

			var client = new HttpClient();
			var urlBase = "https://localhost:44301";
			client.BaseAddress = new Uri(urlBase);
			var url = string.Concat(urlBase, "/Api", "/Student", "/InsertStudent");

			var response = client.PostAsync(url, content).Result;
			if (response.StatusCode == HttpStatusCode.OK)
			{
				var result = await response.Content.ReadAsStringAsync();
				var exito = JsonConvert.DeserializeObject<bool>(result);
				return new ResponseProxy<StudentModel>
				{
					Exitoso = exito,
					Codigo = 0,
					Mensaje = "Exito"
				};
			}
			else
			{
				return new ResponseProxy<StudentModel>
				{
					Exitoso = false,
					Codigo = (int)response.StatusCode,
					Mensaje = "Error"
				};
			}
		}

		public async Task<ResponseProxy<StudentModel>> DeleteAsync(int id)
		{
			var client = new HttpClient();
			var urlBase = "https://localhost:44301";
			client.BaseAddress = new Uri(urlBase);

			var url = string.Concat(urlBase, "/Api", "/Student", "/DeleteStudent/", id);
			var response = client.DeleteAsync(url).Result;

			if (response.StatusCode == HttpStatusCode.OK)
			{
				var result = await response.Content.ReadAsStringAsync();
				var student = JsonConvert.DeserializeObject<List<StudentModel>>(result);
				return new ResponseProxy<StudentModel>
				{
					Exitoso = true,
					Codigo = (int)HttpStatusCode.OK,
					Mensaje = "Exito",
					listado = student
				};
			}
			else
			{
				return new ResponseProxy<StudentModel>
				{
					Codigo = (int)response.StatusCode,
					Mensaje = "Error"
				};
			}
		}
	}
}