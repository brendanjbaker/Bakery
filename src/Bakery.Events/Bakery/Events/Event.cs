namespace Bakery.Events
{
	using System;

	public abstract class Event
		: IEvent
	{
		public String Type => GetType().Name;
	}
}
