namespace Bakery.Security.Passwords
{
	using System;
	using System.Text;

	public interface IPasswordGenerationContext
	{
		IRandom Random { get; }

		void Transform(Action<StringBuilder> transform);
	}
}
