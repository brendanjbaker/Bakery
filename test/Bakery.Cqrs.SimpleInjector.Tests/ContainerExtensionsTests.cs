using Bakery.Cqrs;
using SimpleInjector;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

public class ContainerExtensionsTests
{
	[Fact]
	public void RegisterCommandHandler()
	{
		var container = new Container();

		container.RegisterCqrs(options =>
		{
			options.ScanAssembly(typeof(ContainerExtensionsTests).GetTypeInfo().Assembly);
		});

		container.Verify();

		var handler = container.GetInstance<TestCommandHandler>();
		var dispatcher = container.GetInstance<IDispatcher>();

		dispatcher.CommandAsync(new TestCommand()).Wait();

		Assert.True(handler.HasReceivedCommand);
	}

	[Fact]
	public async Task RegisterQueryHandler()
	{
		var container = new Container();

		container.RegisterCqrs(options =>
		{
			options.ScanAssembly(typeof(ContainerExtensionsTests).GetTypeInfo().Assembly);
		});

		container.Verify();

		var handler = container.GetInstance<TestQueryHandler>();
		var dispatcher = container.GetInstance<IDispatcher>();

		var result = await dispatcher.QueryAsync(new TestQuery());

		Assert.True(handler.HasReceivedQuery);
	}
}
