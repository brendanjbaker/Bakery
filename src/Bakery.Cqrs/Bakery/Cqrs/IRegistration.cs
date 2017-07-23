namespace Bakery.Cqrs
{
	using System;
	using System.Threading.Tasks;

	public interface IRegistration
	{
		Type Type { get; }

		Task<Object> ExecuteAsync(Object @object);
	}
}
