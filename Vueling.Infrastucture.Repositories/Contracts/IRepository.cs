namespace Vueling.Infrastucture.Repositories.Contracts
{
	public interface IRepository<T>: ICreate<T>, IRead<T>, IUpdate<T>, IDelete
	{

	}
}
