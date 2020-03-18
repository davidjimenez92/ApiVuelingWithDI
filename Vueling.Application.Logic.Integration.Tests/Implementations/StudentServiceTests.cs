using System;
using Application.Logic.Contracts;
using log4net.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.Application.Logic.Integration.Tests.AutofacModules;
using Vueling.Domain.Entities;
using Vueling.Test.Framework;

namespace Application.Logic.Implementations.Tests
{
	[TestClass()]
	public class StudentServiceTests: IoCSupportedTest<ApplicationModule>
	{
		private static IService<Student> service = null;
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
			service = Resolve<IService<Student>>();
			inputStudent = new Student(4, "David", "Jimenez", new DateTime(1992, 6, 24));
			updateStudent = new Student(2, "Update", "Method", DateTime.Now);
			Student student1 = new Student("Student", "Number 1", DateTime.Now);
			Student student2 = new Student("Student", "Number 2", DateTime.Now);
			Student student3 = new Student("Student", "Number 3", DateTime.Now);
			service.Create(student1);
			service.Create(student2);
			service.Create(student3);
		}

		[TestMethod()]
		public void CreateTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void DeleteTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void ReadTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void UpdateTest()
		{
			Assert.Fail();
		}
	}
}