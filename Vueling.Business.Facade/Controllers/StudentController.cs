using System.Collections.Generic;
using System.Web.Http;
using Application.Logic.Contracts;
using Application.Logic.Implementations;
using Vueling.Domain.Entities;

namespace Vueling.Business.Facade.Controllers
{
    public class StudentController : ApiController
    {
        private readonly IService<Student> studentService;

        public StudentController(IService<Student> studentService)
        {
            this.studentService = studentService;
        }

        [Route("api/get")]
        public List<Student> Get()
        {
            return studentService.Read();
        }

        [Route("api/add")]
        public Student Post(Student model)
        {
            return studentService.Create(model);
        }

        [Route("api/delete")]
        public bool Delete(int id)
        {
            return studentService.Delete(id);
        }
    }
}
