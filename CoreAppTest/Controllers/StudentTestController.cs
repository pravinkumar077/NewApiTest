using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAppTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreAppTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentTestController : ControllerBase
    {
        //private IDataRepository<Student, long> _iRepo;
        private readonly ApplicationContext _iRepo;
        public StudentTestController(ApplicationContext repo)
        {
            _iRepo = repo;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            var data = _iRepo.Students.ToList();
            return data;
        }

        [HttpPost]
        public void Post([FromBody]Student student)
        {
            _iRepo.Add(student);
            //abc new 
            //abc again new 
            //djfggirfgj
        }
        public long Add(Student stundent)
        {
            _iRepo.Students.Add(stundent);
            long studentID = _iRepo.SaveChanges();
            return studentID;
        }
    }
}