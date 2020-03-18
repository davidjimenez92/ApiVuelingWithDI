using System.Collections.Generic;
using System.Web.Http;
using Application.Logic.Contracts;
using log4net;
using Vueling.Domain.Entities;

namespace Vueling.Business.Facade.Controllers
{
    public class StudentController : ApiController
    {
        private readonly ILog logger = null;
        private readonly IService<Student> service = null;

        public StudentController()
        {
        }

        public StudentController(ILog logger, IService<Student> service)
        {
            this.logger = logger;
            this.service = service;
        }

        [HttpGet]
        public List<Student> Get()
        {
            return service.Read();
        }

        [HttpPost]
        public Student Post(Student model)
        {
            return service.Create(model);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            return service.Delete(id);
        }

        [HttpPut]
        public Student Update(Student model)
        {
            return service.Update(model);
        }
    }
}
