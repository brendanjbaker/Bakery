namespace Bakery.Security.Passwords.Rule
{
	using System;

	public class AddNumbersPasswordGenerationRule
		: AddCharactersPasswordGenerationRule
	{
		public AddNumbersPasswordGenerationRule(Int32 count)
			: base(count, StandardAlphabet.Numbers) { }
	}
}
