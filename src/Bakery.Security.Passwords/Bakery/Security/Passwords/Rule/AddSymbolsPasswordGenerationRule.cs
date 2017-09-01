namespace Bakery.Security.Passwords.Rule
{
	using System;

	public class AddSymbolsPasswordGenerationRule
		: AddCharactersPasswordGenerationRule
	{
		public AddSymbolsPasswordGenerationRule(Int32 count)
			: base(count, StandardAlphabet.Symbols) { }
	}
}
