using System;
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
            Assert.Equal(2, (Some<int>)result);
        }
    }
}
