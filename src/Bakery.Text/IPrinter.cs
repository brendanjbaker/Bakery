namespace Bakery.Text
{
	using System;

	public interface IPrinter<T>
	{
		String Print(T instance);
	}
}
