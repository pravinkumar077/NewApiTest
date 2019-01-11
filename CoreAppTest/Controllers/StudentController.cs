using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAppTest.DataManager;
using CoreAppTest.Models;
using CoreAppTest.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoreAppTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private IDataRepository<Student, long> _iRepo;
        //private readonly ApplicationContext _iRepo;
        public StudentController(IDataRepository<Student, long> repo)
        {
            _iRepo = repo;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            var data = _iRepo.GetAll();
            return data;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return _iRepo.Get(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Student student)
        {
            _iRepo.Add(student);
        }

        //// POST api/values
        //[HttpPut]
        //public void Put([FromBody]Student student)
        //{
        //    _iRepo.Update(student.StudentId, student);
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public long Delete(int id)
        //{
        //    return _iRepo.Delete(id);
        //}
    }
}