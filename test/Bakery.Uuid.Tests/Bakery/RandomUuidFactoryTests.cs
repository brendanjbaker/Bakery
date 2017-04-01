namespace Bakery
{
	using Security;
	using System.Security.Cryptography;
	using Xunit;

	public class RandomUuidFactoryTests
	{
		[Fact]
		public void Create()
		{
			CreateTestInstance().Create();
		}

		[Fact]
		public void NoDuplicates()
		{
			var factory1 = CreateTestInstance();
			var factory2 = CreateTestInstance();

			Assert.True(factory1.Create() != factory2.Create());
		}

		private static RandomUuidFactory CreateTestInstance()
		{
			return new RandomUuidFactory(new SystemCryptographicRandom(RandomNumberGenerator.Create()));
		}
	}
}
