using System;
using System.Collections.Generic;
using System.Linq;

public static class MultipleExtensions
{
	public static Boolean Multiple<T>(this ICollection<T> items)
	{
		return items.Count > 1;
	}

	public static Boolean Multiple<T>(this IEnumerable<T> items)
	{
		return items.Skip(1).Any();
	}
}
