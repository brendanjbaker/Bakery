namespace Bakery.Security.Passwords.Rule
{
	using System;

	public class AddLettersPasswordGenerationRule
		: AddCharactersPasswordGenerationRule
	{
		public AddLettersPasswordGenerationRule(Int32 count)
			: base(count, StandardAlphabet.Letters) { }
	}
}
