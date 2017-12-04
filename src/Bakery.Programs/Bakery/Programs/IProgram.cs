namespace Bakery.Programs
{
	using System.Threading;
	using System.Threading.Tasks;

	public interface IProgram
	{
		Task RunAsync(CancellationToken cancellationToken);
	}
}
