using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Vueling.Domain.Entities;
using Vueling.Infrastucture.Repositories.Contracts;

namespace Vueling.Infrastucture.Repositories.Implementations
{
	public class StudentRepository : IRepository<Student>
	{
		public Student Create(Student model)
		{
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
			catch (ArgumentNullException ane)
			{
				throw;
			}
			catch (InvalidOperationException ioe)
			{
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
			try
			{
				using (IDbConnection connection = new SqlConnection(Resource.ConnectionString))
				{
					return SqlMapper.Query<Student>(connection, "SELECT * FROM Student").ToList();
				}
			}
			catch (ArgumentNullException ane)
			{
				throw;
			}
		}

		public Student Update(Student model)
		{
			throw new NotImplementedException();
		}
	}
}
