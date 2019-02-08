using Xunit;

namespace Feree.Option.Tests
{
    public class EqualityTests
    {
        [Fact]
        public void EqualSome_GivenValue_WhenValueIsEqual_ReturnsTrue()
        {
            var some = OptionFactory.Some(15);

            Assert.Equal(15, some);
        }

        [Fact]
        public void EqualOption_GivenValue_WhenValueIsEqual_ReturnsTrue()
        {
            Option<int> some = OptionFactory.Some(15);

            Assert.Equal(15, some);
        }

        [Fact]
        public void EqualSome_GivenSome_WhenValueIsEqual_ReturnsTrue()
        {
            var some = OptionFactory.Some(15);

            Assert.Equal(OptionFactory.Some(15), some);
        }

        [Fact]
        public void EqualOption_GivenOption_WhenValueIsEqual_ReturnsTrue()
        {
            Option<int> some = OptionFactory.Some(15);

            Assert.Equal(OptionFactory.Some(15), some);
        }

        [Fact]
        public void EqualNone_GivenNone_ReturnsTrue()
        {
            var none = OptionFactory.None<int>();

            Assert.Equal(OptionFactory.None<int>(), none);
        }

        [Fact]
        public void EqualNone_GivenSome_ReturnsFalse()
        {
            var none = OptionFactory.None<int>();

            Assert.NotEqual(OptionFactory.Some(15), none);
        }

        [Fact]
        public void EqualNone_GivenValue_ReturnsFalse()
        {
            var none = OptionFactory.None<int>();

            Assert.NotEqual(2, none);
        }

        [Fact]
        public void EqualOptionSome_GivenNone_ReturnsFalse()
        {
            Option<int> some = OptionFactory.Some(15);
            Option<int> none = OptionFactory.None<int>();

            Assert.NotEqual(none, some);
        }
        
        [Fact]
        public void EqualSome_GivenValue_WhenValueIsNotEqual_ReturnsFalse()
        {
            var some = OptionFactory.Some(15);

            Assert.NotEqual(12, some);
        }
        
        [Fact]
        public void EqualOption_GivenValue_WhenValueIsNotEqual_ReturnsFalse()
        {
            Option<int> some = OptionFactory.Some(15);

            Assert.NotEqual(12, some);
        }
        
        [Fact]
        public void EqualOption_GivenOption_WhenValueIsNotEqual_ReturnsFalse()
        {
            Option<int> some = OptionFactory.Some(15);

            Assert.NotEqual(OptionFactory.Some(12), some);
        }
    }
}