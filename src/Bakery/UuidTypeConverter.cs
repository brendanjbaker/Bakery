namespace Bakery
{
	using System;
	using System.ComponentModel;
	using System.Globalization;

	public class UuidTypeConverter
		: TypeConverter
	{
		public override Boolean CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return
				sourceType == typeof(String) ||
				sourceType == typeof(Guid);
		}

		public override Boolean CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return
				destinationType == typeof(Uuid) ||
				destinationType == typeof(Uuid?);
		}

		public override Object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, Object value)
		{
			if (value == null)
				return null;

			if (value.GetType() == typeof(String))
				return FromString(value.ToString());

			if (value.GetType() == typeof(Guid))
				return new Uuid((Guid)value);

			return null;
		}

		public override Object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, Object value, Type destinationType)
		{
			if (value == null)
				return null;

			if (value.GetType() == typeof(Guid))
				return new Uuid((Guid)value);

			return null;
		}

		private static Object FromString(String @string)
		{
			Guid guid;

			if (!Guid.TryParse(@string, out guid))
				return null;

			return new Uuid(guid);
		}
	}
}
