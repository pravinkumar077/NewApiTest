using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CoreAppTest.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreAppTest.Controllers
{
    public class StudentsController : Controller
    {
        StudentAPI _studentAPI = new StudentAPI();

        public async Task<IActionResult> Index()
        {
            List<StudentDTO> dto = new List<StudentDTO>();

            HttpClient client = _studentAPI.InitializeClient();

            HttpResponseMessage res = await client.GetAsync("api/student");

            //Checking the response is successful or not which is sent using HttpClient  
            if (res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var result = res.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Employee list  
                dto = JsonConvert.DeserializeObject<List<StudentDTO>>(result);

            }
            //returning the employee list to view  
            return View(dto);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("StudentId,FirstName,LastName,Gender,DateOfBirth,DateOfRegistration,PhoneNumber,Email,Address1,Address2,City,State,Zip")] StudentDTO student)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _studentAPI.InitializeClient();

                var content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PostAsync("api/student", content).Result;
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(student);
        }


    }
}