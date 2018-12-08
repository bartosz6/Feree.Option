using Xunit;

namespace Feree.Option.Tests
{
    public class BindTests
    {
        [Fact]
        public void Bind_OnSome_GivenSome_ReturnsSome()
        {
            var someInt = OptionFactory.Some(1);

            var result = someInt.Bind(one => OptionFactory.Some(one + 1));

            Assert.True(result is Some<int>);
            Assert.Equal(2, (Some<int>) result);
        }
        
        [Fact]
        public void Bind_OnSome_GivenValue_ReturnsSome()
        {
            var someInt = OptionFactory.Some(1);

            var result = someInt.Bind<int>(one => one + 1);

            Assert.True(result is Some<int>);
            Assert.Equal(2, (Some<int>) result);
        }
        
        [Fact]
        public void Bind_OnSome_GivenNone_ReturnsNone()
        {
            var someInt = OptionFactory.Some(1);

            var result = someInt.Bind(one => OptionFactory.None<int>());

            Assert.True(result is None<int>);
        }
        
        [Fact]
        public void Bind_OnSome_GivenNull_ReturnsNone()
        {
            var someInt = OptionFactory.Some(1);

            var result = someInt.Bind<int>(one => null);

            Assert.True(result is None<int>);
        }
    }
}