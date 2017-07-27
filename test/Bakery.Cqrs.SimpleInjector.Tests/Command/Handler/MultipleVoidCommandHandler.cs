namespace Command.Handler
{
	using Bakery.Cqrs;
	using System;
	using System.Threading.Tasks;

	public class MultipleVoidCommandHandler
		: ICommandHandler<VoidCommand1>
		, ICommandHandler<VoidCommand2>
	{
		public Boolean
			HasReceivedVoidCommand1,
			HasReceivedVoidCommand2;

		public Task HandleAsync(VoidCommand1 command)
		{
			HasReceivedVoidCommand1 = true;

			return Task.CompletedTask;
		}

		public Task HandleAsync(VoidCommand2 command)
		{
			HasReceivedVoidCommand2 = true;

			return Task.CompletedTask;
		}
	}
}
