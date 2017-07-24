﻿using Bakery.Cqrs;
using SimpleInjector;
using System;

public static class ContainerExtensions
{
	public static void RegisterCqrs(this Container container)
	{
		container.RegisterCqrs(options => { });
	}

	public static void RegisterCqrs(this Container container, Action<RegistrationOptions> options)
	{
		if (options == null)
			throw new ArgumentNullException(nameof(options));

		container.RegisterSingleton<IDispatcher, SimpleInjectorDispatcher>();

		options.Invoke(new RegistrationOptions(container));
	}
}