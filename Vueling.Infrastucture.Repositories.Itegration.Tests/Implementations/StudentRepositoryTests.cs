

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.Domain.Entities;

namespace Vueling.Infrastucture.Repositories.Implementations.Tests
{
	[TestClass()]
	public class StudentRepositoryTests
	{
		public static Student inputStudent = null;
		public static StudentRepository repository = null;

		[TestInitialize]
		public void Setup() 
		{
			repository = new StudentRepository();
			inputStudent = new Student(4, "David", "Jimenez", new DateTime(1992, 6, 24));
			Student student1 = new Student("Student", "Number 1", DateTime.Now);
			Student student2 = new Student("Student", "Number 2", DateTime.Now);
			Student student3 = new Student("Student", "Number 3", DateTime.Now);
			repository.Create(student1);
			repository.Create(student2);
			repository.Create(student3);
		}

		[TestCleanup]
		public void TearDown() 
		{
			repository.TruncateDB();
		}

		[TestMethod()]
		public void CreateTest()
		{
			var spected = repository.Create(inputStudent);			
			Assert.AreEqual(spected, inputStudent);
		}

		[TestMethod()]
		public void DeleteTest()
		{
			Assert.IsTrue(repository.Delete(1));
		}

		[TestMethod()]
		public void ReadTest()
		{
			var students = repository.Read();
			bool response = students.Count() == 3;
			Assert.IsTrue(response);
		}

		[TestMethod()]
		public void UpdateTest()
		{
			Assert.Fail();
		}
	}
}