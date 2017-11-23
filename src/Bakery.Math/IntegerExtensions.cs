using System;

public static class IntegerExtensions
{
	private const Int32
		KILOBYTE = 1024,
		MEGABYTE = 1024 * 1024,
		GIGABYTE = 1024 * 1024 * 1024;

	public static Int32 Kilobytes(this Int32 integer)
	{
		return integer * KILOBYTE;
	}

	public static Int32 Megabytes(this Int32 integer)
	{
		return integer * MEGABYTE;
	}

	public static Int32 Gigabytes(this Int32 integer)
	{
		return integer * GIGABYTE;
	}
}
