namespace Application.Logic.Contracts{
	public interface IUpdate<T>
	{
		T Update(T model);
	}
}
