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
			return new Uuid(Guid.Parse((String)value));
		}
	}
}
