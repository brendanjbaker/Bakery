namespace Bakery.Security.Passwords.Rule
{
	using System;

	public class AddLowercaseLettersPasswordGenerationRule
		: AddCharactersPasswordGenerationRule
	{
		public AddLowercaseLettersPasswordGenerationRule(Int32 count)
			: base(count, StandardAlphabet.LowercaseLetters) { }
	}
}
