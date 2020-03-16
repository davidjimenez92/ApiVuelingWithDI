namespace Vueling.Infrastucture.Repositories.Contracts
{
	public interface ICreate<T>
	{
		T Create(T model);
	}
}
