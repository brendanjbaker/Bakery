namespace Bakery.Processes.Specification
{
	using System;

	public class ProcessSpecification
		: IProcessSpecification
	{
		private readonly String program;
		private readonly String[] arguments;
		private readonly Boolean isEnvironmentEnabled;
		private readonly Boolean isStandardInputEnabled;
		private readonly OutputMode outputMode;

		public ProcessSpecification(
			String program,
			String[] arguments,
			Boolean isEnvironmentEnabled,
			Boolean isStandardInputEnabled,
			OutputMode outputMode)
		{
			this.program = program;
			this.arguments = arguments;
			this.isEnvironmentEnabled = isEnvironmentEnabled;
			this.isStandardInputEnabled = isStandardInputEnabled;
			this.outputMode = outputMode;
		}

		public String[] Arguments => arguments;

		public Boolean IsEnvironmentEnabled => isEnvironmentEnabled;

		public Boolean IsStandardInputEnabled => isEnvironmentEnabled;

		public OutputMode OutputMode => outputMode;

		public String Program => program;
	}
}
