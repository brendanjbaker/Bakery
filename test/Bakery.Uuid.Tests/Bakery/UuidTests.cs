namespace Bakery
{
	using System;
	using Xunit;

	public class UuidTests
	{
		[Fact]
		public void CanConstructDefault()
		{
			new Uuid();
		}

		[Fact]
		public void CanConstructFromGuid()
		{
			new Uuid(Guid.Empty);
		}

		[Theory]
		[InlineData("00000000-0000-0000-0000-000000000000", "00000000-0000-0000-0000-000000000001")]
		[InlineData("00000000-0000-0000-0000-000000000000", "00000000-0000-0000-0001-000000000000")]
		[InlineData("00000000-0000-0000-0000-000000000000", "00000000-0000-1000-0000-000000000000")]
		[InlineData("00000000-0000-0000-0000-000000000000", "00000000-1000-0000-0000-000000000000")]
		[InlineData("00000000-0000-0000-0000-000000000000", "10000000-0000-0000-0000-000000000000")]
		[InlineData("00000000-0000-0000-0000-000000000000", "80000000-0000-0000-0000-000000000000")]
		[InlineData("FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFE", "FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF")]
		public void LessThanOperator(String lowerText, String higherText)
		{
			var lower = new Uuid(Guid.Parse(lowerText));
			var higher = new Uuid(Guid.Parse(higherText));

			Assert.True(lower < higher);
		}

		[Theory]
		[InlineData("00000000-0000-0000-0000-000000000000", "00000000-0000-0000-0000-000000000001")]
		[InlineData("00000000-0000-0000-0000-000000000000", "00000000-0000-0000-0001-000000000000")]
		[InlineData("00000000-0000-0000-0000-000000000000", "00000000-0000-1000-0000-000000000000")]
		[InlineData("00000000-0000-0000-0000-000000000000", "00000000-1000-0000-0000-000000000000")]
		[InlineData("00000000-0000-0000-0000-000000000000", "10000000-0000-0000-0000-000000000000")]
		[InlineData("00000000-0000-0000-0000-000000000000", "80000000-0000-0000-0000-000000000000")]
		[InlineData("FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFE", "FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF")]
		public void GreaterThanOperator(String lowerText, String higherText)
		{
			var lower = new Uuid(Guid.Parse(lowerText));
			var higher = new Uuid(Guid.Parse(higherText));

			Assert.True(higher > lower);
		}

		[Theory]
		[InlineData("00000000-0000-0000-0000-000000000000", "00000000-0000-0000-0000-000000000000")]
		[InlineData("11112222-3333-4444-5555-666677778888", "11112222-3333-4444-5555-666677778888")]
		public void EqualOperator(String alphaText, String betaText)
		{
			var alpha = new Uuid(Guid.Parse(alphaText));
			var beta = new Uuid(Guid.Parse(betaText));

			Assert.True(alpha == beta);
		}

		[Theory]
		[InlineData("00000000-0000-0000-0000-000000000000", "00000000-0000-0000-0000-000000000000")]
		[InlineData("11112222-3333-4444-5555-666677778888", "11112222-3333-4444-5555-666677778888")]
		public void EqualOperator_UuidToGuid(String alphaText, String betaText)
		{
			var alpha = new Uuid(Guid.Parse(alphaText));
			var beta = Guid.Parse(betaText);

			Assert.True(alpha == beta);
		}

		[Theory]
		[InlineData("00000000-0000-0000-0000-000000000000", "00000000-0000-0000-0000-000000000000")]
		[InlineData("11112222-3333-4444-5555-666677778888", "11112222-3333-4444-5555-666677778888")]
		public void EqualOperator_GuidToUuid(String alphaText, String betaText)
		{
			var alpha = Guid.Parse(alphaText);
			var beta = new Uuid(Guid.Parse(betaText));

			Assert.True(alpha == beta);
		}

		[Theory]
		[InlineData("00000000-0000-0000-0000-000000000000", "00000000-0000-0000-0000-000000000001")]
		[InlineData("00000000-0000-0000-0000-000000000000", "FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF")]
		public void NotEqualOperator(String alphaText, String betaText)
		{
			var alpha = new Uuid(Guid.Parse(alphaText));
			var beta = new Uuid(Guid.Parse(betaText));

			Assert.True(alpha != beta);
		}

		[Theory]
		[InlineData("00000000-0000-0000-0000-000000000000", "00000000-0000-0000-0000-000000000001")]
		[InlineData("00000000-0000-0000-0000-000000000000", "FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF")]
		public void NotEqualOperator_UuidToGuid(String alphaText, String betaText)
		{
			var alpha = new Uuid(Guid.Parse(alphaText));
			var beta = Guid.Parse(betaText);

			Assert.True(alpha != beta);
		}

		[Theory]
		[InlineData("00000000-0000-0000-0000-000000000000", "00000000-0000-0000-0000-000000000001")]
		[InlineData("00000000-0000-0000-0000-000000000000", "FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF")]
		public void NotEqualOperator_GuidToUuid(String alphaText, String betaText)
		{
			var alpha = Guid.Parse(alphaText);
			var beta = new Uuid(Guid.Parse(betaText));

			Assert.True(alpha != beta);
		}

		[Fact]
		public void HashCodesSameForSameValues()
		{
			var alpha = new Uuid(Guid.Parse("11112222-3333-4444-5555-666677778888"));
			var beta = new Uuid(Guid.Parse("11112222-3333-4444-5555-666677778888"));

			Assert.True(alpha.GetHashCode() == beta.GetHashCode());
		}

		[Fact]
		public void HashCodesDifferentForDifferentValues()
		{
			var alpha = new Uuid(Guid.Parse("00000000-0000-0000-0000-000000000000"));
			var beta = new Uuid(Guid.Parse("FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF"));

			Assert.True(alpha.GetHashCode() != beta.GetHashCode());
		}

		[Fact]
		public void ImplicitGuidToUuid()
		{
			Uuid uuid = Guid.Empty;
		}

		[Fact]
		public void ImplicitUuidToGuid()
		{
			Guid guid = Uuid.Zero;
		}

		[Fact]
		public void ZeroIsSameAsGuidEmpty()
		{
			Assert.True(Uuid.Zero == Guid.Empty);
		}

		[Fact]
		public void EqualsMethodTrueForEqualGuid()
		{
			var alpha = new Uuid(Guid.Empty);
			var beta = Guid.Empty;

			Assert.True(alpha.Equals(beta));
		}

		[Fact]
		public void EqualsMethodTrueForEqualUuid()
		{
			var alpha = new Uuid(Guid.Empty);
			var beta = new Uuid(Guid.Empty);

			Assert.True(alpha.Equals(beta));
		}

		[Fact]
		public void EqualsMethodFalseForNull()
		{
			Assert.False(Uuid.Zero.Equals(null));
		}

		[Fact]
		public void EqualsMethodFalseForUnrelatedType()
		{
			Assert.False(Uuid.Zero.Equals(new EventArgs()));
		}

		[Fact]
		public void EqualsMethodFalseForUnequalGuid()
		{
			var alpha = new Uuid(Guid.Parse("00000000-0000-0000-0000-000000000000"));
			var beta = Guid.Parse("88888888-8888-8888-8888-888888888888");

			Assert.False(alpha.Equals(beta));
		}

		[Fact]
		public void EqualsMethodFalseForUnequalUuid()
		{
			var alpha = new Uuid(Guid.Parse("00000000-0000-0000-0000-000000000000"));
			var beta = new Uuid(Guid.Parse("88888888-8888-8888-8888-888888888888"));

			Assert.False(alpha.Equals(beta));
		}

		[Fact]
		public void ToStringIs32CharactersLong()
		{
			Assert.True(Uuid.Zero.ToString().Length == 32);
		}

		[Theory]
		[InlineData("11112222333344445555666677778888")]
		[InlineData("11112222-3333-4444-5555-666677778888")]
		public void Parse(String text)
		{
			var uuid = Uuid.Parse(text);
			var guid = Guid.Parse(text);

			Assert.True(uuid == guid);
		}

		[Fact]
		public void ParseThrowsForNull()
		{
			Assert.Throws<ArgumentNullException>(() => Uuid.Parse(null));
		}

		[Fact]
		public void ParseThrowsForInvalidText()
		{
			Assert.Throws<FormatException>(() => Uuid.Parse("Test"));
		}
	}
}
