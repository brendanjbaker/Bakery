using Bakery.Cqrs;
using System;
using System.Reflection;

internal static class TypeExtensions
{
	public static Boolean IsCommand(this Type type)
	{
		return type.ImplementsInterface(typeof(ICommand));
	}

	public static Boolean IsCommandHandler(this Type type)
	{
		return type.ImplementsInterface(typeof(ICommandHandler<>));
	}

	public static Boolean IsQuery(this Type type)
	{
		return type.ImplementsInterface(typeof(IQuery<>));
	}

	public static Boolean IsQueryHandler(this Type type)
	{
		return type.ImplementsInterface(typeof(IQueryHandler<,>));
	}

	public static void AssertImplementsInterface(this Type type, Type interfaceType)
	{
		if (!type.ImplementsInterface(interfaceType))
			throw new InvalidOperationException($"Type {type.Name} does not implement interface {interfaceType.Name}.");
	}

	private static Boolean ImplementsInterface(this Type type, Type interfaceType)
	{
		// To-do: This should be exposed publicly... Somewhere else.

		if (!interfaceType.GetTypeInfo().IsInterface)
			throw new ArgumentException($"Type {interfaceType.Name} is not an interface.");

		foreach (var @interface in type.GetTypeInfo().GetInterfaces())
			if (@interface.GetTypeInfo().IsGenericType)
				if (@interface.GetTypeInfo().GetGenericTypeDefinition() == interfaceType)
					return true;

		return false;
	}
}
