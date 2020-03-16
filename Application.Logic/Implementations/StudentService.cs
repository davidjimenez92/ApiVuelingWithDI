using System.Collections.Generic;
using Application.Logic.Contracts;
using Vueling.Domain.Entities;
using Vueling.Infrastucture.Repositories.Contracts;
using Vueling.Infrastucture.Repositories.Implementations;

namespace Application.Logic.Implementations
{
	public class StudentService : IService<Student>
	{

		public readonly IRepository<Student> repository = null;

		public StudentService(IRepository<Student> repository)
		{
			this.repository = repository;
		}
		public Student Create(Student model)
		{
			return repository.Create(model);	
		}

		public bool Delete(int id)
		{
			return repository.Delete(id);
		}

		public List<Student> Read()
		{
			return repository.Read();
		}

		public Student Update(Student model)
		{
			return repository.Update(model);
		}
	}
}
