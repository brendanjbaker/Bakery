namespace Bakery.Security.Passwords.Rule
{
	using System;

	public class AddUppercaseLettersPasswordGenerationRule
		: AddCharactersPasswordGenerationRule
	{
		public AddUppercaseLettersPasswordGenerationRule(Int32 count)
			: base(count, StandardAlphabet.UppercaseLetters) { }
	}
}
