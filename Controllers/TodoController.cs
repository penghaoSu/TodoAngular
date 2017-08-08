using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoAngular.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoAngular.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        HttpClient client = new HttpClient();

        //private static readonly List<Todo> List = new List<Todo>
        //{
        //    new Todo{Id=1,Title="test",Status="1"},
        //    new Todo{Id=2,Title="test2",Status="1"},
        //    new Todo{Id=3,Title="test3",Status="1"},
        //};


        // GET: /<controller>/
        [HttpGet]
        public async Task<string> Get()
        {
            //string response = string.Empty;
            

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Add("authorization", "token 98e841f0-1023-4217-add0-e1d4244eca40");
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("98e841f0-1023-4217-add0-e1d4244eca40");

            try
            {
                var responseM = await client.GetStringAsync("https://jsonbin.org/penghaosu/todo");

                //if (responseM.IsSuccessStatusCode)
                //{
                //    var response = await responseM.Content.ReadAsStringAsync().Result.ToList();
                //    var data = JsonConvert.DeserializeObject<TodoList>(response);

                //    return data;
                //}

                return responseM;
            }
            catch (Exception ex)
            {
                throw new Exception("錯誤代碼：" + ex);
            }
        }

        [HttpGet("{id}")]
        public Todo Get(int id)
        {
            return null;//List.FirstOrDefault(t => t.Id == id);
        }

        [HttpPost]
        public async Task<string> Post([FromBody]dynamic body)
        {
            var result = Content(JsonConvert.SerializeObject(body), "application/json");

            var xxx = result.Content;

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Add("authorization", "token 98e841f0-1023-4217-add0-e1d4244eca40");

            try
            {
                var responseM = await client.PostAsync("https://jsonbin.org/penghaosu/todo" , new StringContent(result.Content, Encoding.UTF8, "application/json"));

                //if (responseM.IsSuccessStatusCode)
                //{
                //    var response = await responseM.Content.ReadAsStringAsync().Result.ToList();
                //    var data = JsonConvert.DeserializeObject<TodoList>(response);

                //    return data;
                //}

                return result.Content;
            }
            catch (Exception ex)
            {
                throw new Exception("錯誤代碼：" + ex);
            }
            
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Todo value)
        {
            /*
            var result = List.FirstOrDefault(l => l.Id == id);

            if (result != null)
            {
                List.Remove(result);
                List.Add(value);
            }*/
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var result = "";// List.FirstOrDefault(l => l.Id == id);

            if (result != null)
            {
                //List.Remove(result);

            }
        }

        /*
        public async Task<string> CallApi(string apiName, T instance)
        {
            string response = string.Empty;

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                //HttpResponseMessage responseM = await client.PostAsync("https://jsonbin.org/me/test", new StringContent(JsonConvert.SerializeObject(instance), Encoding.UTF8, "application/json"));
                HttpResponseMessage responseM = await client.GetAsync("https://jsonbin.org/me/test");


                if (responseM.IsSuccessStatusCode)
                {
                    response = await responseM.Content.ReadAsStringAsync();
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("錯誤代碼：" + apiName + ex);
            }

        }*/
    }
}
