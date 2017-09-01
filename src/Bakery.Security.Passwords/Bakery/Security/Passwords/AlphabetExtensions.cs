namespace Bakery.Security.Passwords
{
	using System;
	using System.Linq;

	public static class AlphabetExtensions
	{
		public static Char Random(this IAlphabet alphabet, IRandom random)
		{
			if (random == null)
				throw new ArgumentNullException(nameof(random));

			var index = random.GetInt32() % alphabet.Characters.Count();

			return alphabet.Characters[index];
		}
	}
}
