using Bakery.Concurrency;

public static class AutomaticGateExtensions
{
	public static void Open(this AutomaticGate gate)
	{
		gate.Open(1);
	}
}
