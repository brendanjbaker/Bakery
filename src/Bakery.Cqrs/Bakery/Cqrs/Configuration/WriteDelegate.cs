namespace Bakery.Cqrs.Configuration
{
	using System;

	public delegate void WriteDelegate(Object query, Object result, TimeSpan lifetime, Priority priority);
}
