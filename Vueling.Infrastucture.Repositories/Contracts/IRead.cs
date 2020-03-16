using System.Collections.Generic;

namespace Vueling.Infrastucture.Repositories.Contracts
{
	public interface IRead<T>
	{
		List<T> Read();
	}
}
