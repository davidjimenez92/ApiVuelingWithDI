using System;
using System.Collections.Generic;
using Application.Logic.Contracts;
using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vueling.Domain.Entities;

namespace Application.Logic.Implementations.Tests
{
	[TestClass()]
	public class StudentServiceTests
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
				mock.Mock<IService<Student>>().Setup(service => service.Create(inputStudent)).Returns(inputStudent);

				var sut = mock.Create<IService<Student>>();
				var spected = sut.Create(inputStudent);

				Assert.AreEqual(spected, inputStudent);
			}
		}

		[TestMethod]
		[ExpectedException(typeof(NullReferenceException))]
		public void CreateWithNullParameterThrowsNullReferenceException()
		{
			using (var mock = AutoMock.GetLoose())
			{
				mock.Mock<IService<Student>>().Setup(service => service.Create(null)).Throws(new NullReferenceException());

				var sut = mock.Create<IService<Student>>();
				sut.Create(null);
			}
		}

		[TestMethod()]
		public void DeleteTest()
		{
			var id = 1;
			using (var mock = AutoMock.GetLoose())
			{
				mock.Mock<IService<Student>>().Setup(service => service.Delete(id)).Returns(true);

				var sut = mock.Create<IService<Student>>();
				var spected = sut.Delete(id);

				Assert.IsTrue(spected);
			}
		}

		[TestMethod()]
		public void ReadTest()
		{
			using (var mock = AutoMock.GetLoose())
			{
				mock.Mock<IService<Student>>().Setup(service => service.Read()).Returns(new List<Student>());

				var sut = mock.Create<IService<Student>>();
				var spected = sut.Read();

				Assert.AreEqual(spected.GetType(), typeof(List<Student>));
			}
		}

		[TestMethod()]
		public void UpdateTest()
		{
			using (var mock = AutoMock.GetLoose())
			{
				mock.Mock<IService<Student>>().Setup(service => service.Update(inputStudent)).Returns(inputStudent);

				var sut = mock.Create<IService<Student>>();
				var spected = sut.Update(inputStudent);

				Assert.AreEqual(spected, inputStudent);
			}
		}
	}
}