using System;

public static class ObjectExtensions
{
	public static T Cast<T>(this Object @object)
	{
		// Casting a null instance is usually permissible, but since we're using extension method
		// syntax, we'll disallow it here.

		if (@object == null)
			throw new ArgumentNullException(nameof(@object));

		return (T)@object;
	}

	public static Boolean Is<T>(this Object @object)
	{
		if (@object == null)
			throw new ArgumentNullException(nameof(@object));

		return @object.GetType().IsAssignableFrom(typeof(T));
	}
}
