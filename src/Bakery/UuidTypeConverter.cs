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
			return sourceType == typeof(String);
		}

		public override Object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, Object value)
		{
			Guid guid;

			if (value == null)
				return null;

			if (value.GetType() != typeof(String))
				return null;

			var valueText = value.ToString();

			if (!Guid.TryParse(valueText, out guid))
				return null;

			return new Uuid(guid);
		}
	}
}
