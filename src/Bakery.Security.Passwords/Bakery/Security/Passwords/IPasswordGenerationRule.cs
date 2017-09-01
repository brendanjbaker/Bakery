namespace Bakery.Security.Passwords
{
	public interface IPasswordGenerationRule
	{
		void Apply(IPasswordGenerationContext context);
	}
}
