﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using log4net;
using Vueling.Domain.Entities;
using Vueling.Infrastucture.Repositories.Contracts;

namespace Vueling.Infrastucture.Repositories.Implementations
{
	public class StudentRepository : IRepository<Student>
	{
		//implementar logger
		private readonly ILog logger = null;

		public StudentRepository()
		{
		}

		public StudentRepository(ILog logger)
		{
			this.logger = logger;
		}
		public Student Create(Student model)
		{
			if (model == null)
				throw new NullReferenceException();
			try
			{
				using (var connection = new SqlConnection(Resource.ConnectionString))
				{
					var id = SqlMapper.Query<int>(connection,
						"INSERT INTO Student VALUES(@Name, @Surname, @DateOfBirth); SELECT CAST(SCOPE_IDENTITY() as int)",
						new { model.Name, model.Surname, model.DateOfBirth }).Single();

					return SqlMapper.Query<Student>(connection, "SELECT * FROM Student WHERE Id = @Id", new { id }).Single();
				}
			}
			catch (InvalidOperationException ioe)
			{
				logger.Error(ioe.Message, ioe);
				throw;
			}
		}

		public bool Delete(int id)
		{
			using (var connection = new SqlConnection(Resource.ConnectionString))
			{
				SqlMapper.Query<bool>(connection, "DELETE FROM Student Where Id = @Id", new { id });

				return true;
			}

		}

		public List<Student> Read()
		{
			logger.Info("Get all method started");
			try
			{
				using (IDbConnection connection = new SqlConnection(Resource.ConnectionString))
				{
					return SqlMapper.Query<Student>(connection, "SELECT * FROM Student").ToList();
				}
			}
			catch (ArgumentNullException ane)
			{
				logger.Error(ane.Message, ane);
				throw;
			}
		}

		public Student Update(Student model)
		{
			if (model == null)
				throw new NullReferenceException();
			logger.Info("Get all method started");

			using (IDbConnection connection = new SqlConnection(Resource.ConnectionString))
			{
				connection.Query<Student>("UPDATE Student set Name = @Name , Surname = @Surname, DateOfBirth = @DateOfBirth WHERE Id = @Id",
						new { model.Name, model.Surname, model.DateOfBirth, model.Id });

				return SqlMapper.Query<Student>(connection, "SELECT * FROM Student WHERE id = @id", new { model.Id }).Single();
			}

		}

	}
}
