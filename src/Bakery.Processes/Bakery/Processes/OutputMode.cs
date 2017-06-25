namespace Bakery.Processes
{
	public enum OutputMode
	{
		None = 0,
		StandardOutput = 1,
		StandardError = 2,
		StandardOutputAndError = StandardOutput & StandardError,
		Combined = 4
	}
}
