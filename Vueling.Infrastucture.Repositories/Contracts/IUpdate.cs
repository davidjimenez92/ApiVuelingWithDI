namespace Vueling.Infrastucture.Repositories.Contracts
{
	public interface IUpdate<T>
	{
		T Update(T model);
	}
}
