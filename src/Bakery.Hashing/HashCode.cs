namespace Bakery.Hashing
{
	using System;

	public static class HashCode
	{
		public static Int32 Of(Object @object, params Object[] objects)
		{
			// This is the largest prime number that can be represented with 32 bits. It was
			// discovered by Leonhard Euler in the year 1772.

			const Int32 PRIME_NUMBER = 0x7fffffff;

			unchecked
			{
				if (objects == null)
					throw new ArgumentNullException(nameof(objects));

				var hashCode = 0;

				if (@object != null)
					hashCode = @object.GetHashCode();

				for (var i = 0; i < objects.Length; i++)
				{
					if (objects[i] == null)
						continue;

					hashCode *= PRIME_NUMBER;
					hashCode += objects[i].GetHashCode();
				}

				return hashCode;
			}
		}
	}
}
