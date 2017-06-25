namespace Bakery.Processes.Specification.Builder
{
	using System;

	public class ProcessSpecificationBuilder
		: IProcessSpecificationBuilder
		, IProcessSpecificationBuilderComplete
		, IProcessSpecificationBuilderWithArguments
		, IProcessSpecificationBuilderWithEnvironment
		, IProcessSpecificationBuilderWithProgram
		, IProcessSpecificationBuilderWithStandardError
		, IProcessSpecificationBuilderWithStandardInput
		, IProcessSpecificationBuilderWithStandardOutput
	{
		private readonly String program;
		private readonly String[] arguments;
		private readonly Boolean isEnvironmentEnabled;
		private readonly Boolean isStandardInputEnabled;
		private readonly OutputMode outputMode;

		private ProcessSpecificationBuilder()
		{
			program = null;
			arguments = new String[0];
			isEnvironmentEnabled = false;
			isStandardInputEnabled = false;
			outputMode = OutputMode.None;
		}

		private ProcessSpecificationBuilder(
			String program,
			String[] arguments,
			Boolean isEnvironmentEnabled,
			Boolean isStandardInputEnabled,
			OutputMode outputMode)
		{
			if (program == null)
				throw new ArgumentNullException(nameof(program));

			if (arguments == null)
				throw new ArgumentNullException(nameof(arguments));

			this.program = program;
			this.arguments = arguments;
			this.isEnvironmentEnabled = isEnvironmentEnabled;
			this.isStandardInputEnabled = isStandardInputEnabled;
			this.outputMode = outputMode;
		}

		public static IProcessSpecificationBuilder Create()
		{
			return new ProcessSpecificationBuilder();
		}

		public IProcessSpecification Build()
		{
			return new ProcessSpecification(program, arguments, isEnvironmentEnabled, isStandardInputEnabled, outputMode);
		}

		public IProcessSpecificationBuilderWithArguments WithArguments(params String[] arguments)
		{
			if (arguments == null)
				throw new ArgumentNullException(nameof(arguments));

			return new ProcessSpecificationBuilder(program, arguments, isEnvironmentEnabled, isStandardInputEnabled, outputMode);
		}

		public IProcessSpecificationBuilderComplete WithCombinedOutput()
		{
			return new ProcessSpecificationBuilder(program, arguments, isEnvironmentEnabled, isStandardInputEnabled, OutputMode.Combined);
		}

		public IProcessSpecificationBuilderWithEnvironment WithEnvironment()
		{
			return new ProcessSpecificationBuilder(program, arguments, true, isStandardInputEnabled, OutputMode.Combined);
		}

		public IProcessSpecificationBuilderWithProgram WithProgram(String program)
		{
			if (program == null)
				throw new ArgumentNullException(nameof(program));

			return new ProcessSpecificationBuilder(program, arguments, isEnvironmentEnabled, isStandardInputEnabled, OutputMode.Combined);
		}

		public IProcessSpecificationBuilderWithStandardError WithStandardError()
		{
			return new ProcessSpecificationBuilder(program, arguments, isEnvironmentEnabled, isStandardInputEnabled, outputMode & OutputMode.StandardError);
		}

		public IProcessSpecificationBuilderWithStandardInput WithStandardInput()
		{
			return new ProcessSpecificationBuilder(program, arguments, isEnvironmentEnabled, true, outputMode & OutputMode.StandardError);
		}

		public IProcessSpecificationBuilderWithStandardOutput WithStandardOutput()
		{
			return new ProcessSpecificationBuilder(program, arguments, isEnvironmentEnabled, isStandardInputEnabled, OutputMode.StandardOutput);
		}
	}
}
