using Bakery.Cqrs;
using System;
using System.Threading.Tasks;

public class TestCommandHandler
	: ICommandHandler<TestCommand>
{
	public Boolean HasReceivedCommand { get; private set; } = false;

	public Task HandleAsync(TestCommand command)
	{
		HasReceivedCommand = true;

		return Task.CompletedTask;
	}
}
