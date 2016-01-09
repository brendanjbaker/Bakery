namespace Bakery.Mail
{
	using System.Threading.Tasks;

	public interface IEmailClient
	{
		Task SendAsync(IEmail email);
	}
}
