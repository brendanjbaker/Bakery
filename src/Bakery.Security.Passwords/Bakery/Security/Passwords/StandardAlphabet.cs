namespace Bakery.Security.Passwords
{
	public static class StandardAlphabet
	{
		public static readonly IAlphabet
			Letters = new Alphabet("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"),
			LowercaseLetters = new Alphabet("abcdefghijklmnopqrstuvwxyz"),
			Numbers = new Alphabet("0123456789"),
			Symbols = new Alphabet("!\"#$%&\'()*+,-./:;<=>?@[\\]^_`{|}~"),
			UppercaseLetters = new Alphabet("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
	}
}
