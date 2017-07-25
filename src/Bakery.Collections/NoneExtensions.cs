using System;
using System.Collections.Generic;
using System.Linq;

public static class NoneExtensions
{
	public static Boolean None<T>(this IEnumerable<T> items)
	{
		return !items.Any();
	}
}
