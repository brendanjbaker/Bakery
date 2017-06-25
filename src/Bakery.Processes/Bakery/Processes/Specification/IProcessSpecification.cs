namespace Bakery.Processes.Specification
{
	using System;

	public interface IProcessSpecification
	{
		String Program { get; }
		String[] Arguments { get; }
		Boolean IsEnvironmentEnabled { get; }
		Boolean IsStandardInputEnabled { get; }
		OutputMode OutputMode { get; }
	}
}
