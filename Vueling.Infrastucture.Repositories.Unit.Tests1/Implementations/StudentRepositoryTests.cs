using System;
using System.Collections.Generic;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Vueling.Domain.Entities;
using Vueling.Infrastucture.Repositories.Contracts;

namespace Vueling.Infrastucture.Repositories.Implementations.Tests
{
	[TestClass()]
	public class StudentRepositoryTests
	{
		public static Student inputStudent = null;

		[TestInitialize]
		public void Setup()
		{
			inputStudent = new Student(1, "David", "Jimenez", new DateTime(1992, 6, 24));
		}

		[TestMethod()]
		public void CreateTest()
		{
			using (var mock = AutoMock.GetLoose())
			{
				mock.Mock<IRepository<Student>>().Setup(repository => repository.Create(inputStudent)).Returns(inputStudent);
				var sut = mock.Create<IRepository<Student>>();

				var spected = sut.Create(inputStudent);

				mock.Mock<IRepository<Student>>().Verify(repository => repository.Create(inputStudent));
				Assert.AreEqual(spected, inputStudent);
			}
		}

		[TestMethod]
		[ExpectedException(typeof(NullReferenceException))]
		public void CreateWithNullParameterThrowsNullReferenceException()
		{
			using (var mock = AutoMock.GetLoose())
			{
				//Arrange - configure the mock
				mock.Mock<IRepository<Student>>().Setup(repository => repository.Create(null)).Throws(new NullReferenceException());
				var sut = mock.Create<IRepository<Student>>();
				
				sut.Create(null);
			}
		}

		[TestMethod()]
		public void DeleteTest()
		{
			var id = 1;
			using (var mock = AutoMock.GetLoose())
			{
				//Arrange - configure the mock
				mock.Mock<IRepository<Student>>().Setup(repository => repository.Delete(id)).Returns(true);
				var sut = mock.Create<IRepository<Student>>();

				var spected = sut.Delete(id);

				mock.Mock<IRepository<Student>>().Verify(repository => repository.Delete(id));
				Assert.IsTrue(spected);
			}
		}

		[TestMethod()]
		public void ReadTest()
		{
			using (var mock = AutoMock.GetLoose())
			{
				mock.Mock<IRepository<Student>>().Setup(repository => repository.Read()).Returns(new List<Student>());
				var sut = mock.Create<IRepository<Student>>();

				var spected = sut.Read();

				mock.Mock<IRepository<Student>>().Verify(repository => repository.Read());
				Assert.AreEqual(spected.GetType(), typeof(List<Student>));
			}
		}

		[TestMethod()]
		public void UpdateTest()
		{
			using (var mock = AutoMock.GetLoose())
			{
				mock.Mock<IRepository<Student>>().Setup(repository => repository.Update(inputStudent)).Returns(inputStudent);
				var sut = mock.Create<IRepository<Student>>();

				var spected = sut.Update(inputStudent);

				mock.Mock<IRepository<Student>>().Verify(repository => repository.Update(inputStudent));
				Assert.AreEqual(spected, inputStudent);
			}
		}

		[TestMethod]
		[ExpectedException(typeof(NullReferenceException))]
		public void UpdateWithNullParameterThrowsNullReferenceException()
		{
			using (var mock = AutoMock.GetLoose())
			{
				mock.Mock<IRepository<Student>>().Setup(repository => repository.Update(null)).Throws(new NullReferenceException());
				var sut = mock.Create<IRepository<Student>>();

				sut.Update(null);
			}
		}
	}
}