using System;
using System.Collections.Generic;
using Application.Logic.Contracts;
using log4net;
using Vueling.Domain.Entities;
using Vueling.Infrastucture.Repositories.Contracts;

namespace Application.Logic.Implementations
{
	public class StudentService : IService<Student>
	{

		private readonly IRepository<Student> repository = null;
		private readonly ILog logger = null;

		public StudentService(ILog logger, IRepository<Student> repository)
		{
			this.logger = logger;
			this.repository = repository;
		}

		public StudentService()
		{
		}

		public Student Create(Student model)
		{
			if (model == null)
				throw new NullReferenceException();
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
			if (model == null)
				throw new NullReferenceException();
			return repository.Update(model);
		}
	}
}
