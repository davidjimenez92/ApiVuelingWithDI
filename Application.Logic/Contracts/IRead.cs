using System.Collections.Generic;

namespace Application.Logic.Contracts
{
	public interface IRead<T>
	{
		List<T> Read();
	}
}
