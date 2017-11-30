namespace Bakery.Transput
{
	using System.Threading;
	using System.Threading.Tasks;

	public class VoidWriter<T>
		: IWriter<T>
	{
		public Task WriteAsync(T item, CancellationToken cancellationToken) => Task.CompletedTask;
	}
}
