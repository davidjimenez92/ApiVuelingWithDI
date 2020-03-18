

using System;
using System.Data.SqlClient;
using System.Linq;
using log4net.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.Domain.Entities;
using Vueling.Infrastucture.Repositories.Contracts;
using Vueling.Infrastucture.Repositories.Itegration.Tests;
using Vueling.Infrastucture.Repositories.Itegration.Tests.AutofacModules;
using Vueling.Test.Framework;

namespace Vueling.Infrastucture.Repositories.Implementations.Tests
{
	[TestClass()]
	public class StudentRepositoryIntegrationTests: 
		IoCSupportedTest<RepositoryModule>
	{
		private static IRepository<Student> repository = null;
		private static Student inputStudent = null;
		private static Student updateStudent = null;

		[ClassInitialize]
		public static void ClassInitialize(TestContext context)
		{
			XmlConfigurator.Configure();
		}
		[TestInitialize]
		public void Setup() 
		{
			repository = Resolve<IRepository<Student>>();
			inputStudent = new Student(4, "David", "Jimenez", new DateTime(1992, 6, 24));
			updateStudent = new Student(2, "Update", "Method", DateTime.Now);
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
			string query = "TRUNCATE TABLE Student";

			using (SqlConnection connnection = new SqlConnection(Resource.ConnectionString))
			using (SqlCommand command = new SqlCommand(query, connnection))
			{
				connnection.Open();
				command.ExecuteNonQuery();
			}
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
			var spected = repository.Update(updateStudent);
			Assert.AreEqual(spected, updateStudent);
		}
	}
}