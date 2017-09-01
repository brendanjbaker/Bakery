namespace Bakery.Security.Passwords
{
	using System;

	public class Alphabet
		: IAlphabet
	{
		private readonly String characters;

		public Alphabet(String characters)
		{
			this.characters = characters ?? throw new ArgumentNullException(nameof(characters));
		}

		public String Characters => characters;
	}
}
