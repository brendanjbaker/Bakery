namespace Bakery.Cqrs
{
	using System;

	public interface ICachingRegistration
	{
		Type QueryType { get; }
	}
}
