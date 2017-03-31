namespace Bakery
{
	using System;
	using System.ComponentModel;

	[TypeConverter(typeof(UuidTypeConverter))]
	public struct Uuid
	{
		public static readonly Uuid Zero;

		private readonly Guid guid;

		static Uuid()
		{
			Zero = new Uuid(Guid.Empty);
		}

		public Uuid(Guid guid)
		{
			this.guid = guid;
		}

		public static implicit operator Guid(Uuid uuid)
		{
			return uuid.guid;
		}

		public static implicit operator Uuid(Guid guid)
		{
			return new Uuid(guid);
		}

		public static Boolean operator ==(Uuid alpha, Uuid omega)
		{
			return alpha.guid == omega.guid;
		}

		public static Boolean operator ==(Uuid alpha, Guid omega)
		{
			return alpha.guid == omega;
		}

		public static Boolean operator ==(Guid alpha, Uuid omega)
		{
			return alpha == omega.guid;
		}

		public static Boolean operator !=(Uuid alpha, Uuid omega)
		{
			return alpha.guid != omega.guid;
		}

		public static Boolean operator !=(Uuid alpha, Guid omega)
		{
			return alpha.guid != omega;
		}

		public static Boolean operator !=(Guid alpha, Uuid omega)
		{
			return alpha != omega.guid;
		}

		public static Boolean operator <(Uuid alpha, Uuid omega)
		{
			return alpha.guid.CompareTo(omega.guid) < 0;
		}

		public static Boolean operator >(Uuid alpha, Uuid omega)
		{
			return alpha.guid.CompareTo(omega.guid) > 0;
		}

		public static Uuid Parse(String @string)
		{
			return new Uuid(Guid.Parse(@string));
		}

		public override Boolean Equals(Object @object)
		{
			if (@object == null)
				return false;

			if (@object.GetType() == typeof(Guid))
				@object = new Uuid((Guid)@object);

			if (@object.GetType() != typeof(Uuid))
				return false;

			var uuid = (Uuid)@object;

			return guid == uuid.guid;
		}

		public override Int32 GetHashCode()
		{
			return guid.GetHashCode();
		}

		public override String ToString()
		{
			return guid.ToString("N");
		}
	}
}
