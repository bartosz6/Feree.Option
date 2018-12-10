using System.Threading.Tasks;
using Xunit;

namespace Feree.Option.Tests
{
    public class MapTests
    {
        [Fact]
        public void Map_OnSome_ReturnsOnSomeCallback()
        {
            var someOne = OptionFactory.Some(1);

            var result = someOne.Map(one => one, () => -1);
            
            Assert.Equal(1, result);
        }
        
        [Fact]
        public void Map_OnNone_ReturnsOnNoneCallback()
        {
            var none = OptionFactory.None<int>();

            var result = none.Map(one => one, () => -1);
            
            Assert.Equal(-1, result);
        } 
        
        [Fact]
        public async Task MapAsync_OnSome_ReturnsOnSomeCallback()
        {
            var someOne = OptionFactory.Some(1);

            var result = await someOne.MapAsync(Task.FromResult, () => Task.FromResult(-1));
            
            Assert.Equal(1, result);
        }
        
        [Fact]
        public async Task MapAsync_OnNone_ReturnsOnNoneCallback()
        {
            var none = OptionFactory.None<int>();

            var result = await none.MapAsync(Task.FromResult, () => Task.FromResult(-1));
            
            Assert.Equal(-1, result);
        } 
        
        [Fact]
        public async Task MapAsync_OnSomeAsync_ReturnsOnSomeCallback()
        {
            var someOne = Task.FromResult(OptionFactory.Some(1));

            var result = await someOne.MapAsync(Task.FromResult, () => Task.FromResult(-1));
            
            Assert.Equal(1, result);
        }
        
        [Fact]
        public async Task MapAsync_OnNoneAsync_ReturnsOnNoneCallback()
        {
            var none = Task.FromResult(OptionFactory.None<int>());

            var result = await none.MapAsync(Task.FromResult, () => Task.FromResult(-1));
            
            Assert.Equal(-1, result);
        } 
        
        [Fact]
        public async Task MapAsync_OnSomeAsync_ReturnsOnSomeCallbackSync()
        {
            var someOne = Task.FromResult(OptionFactory.Some(1));

            var result = await someOne.MapAsync(one => one, () => -1);
            
            Assert.Equal(1, result);
        }
        
        [Fact]
        public async Task MapAsync_OnNoneAsync_ReturnsOnNoneCallbackSync()
        {
            var none = Task.FromResult(OptionFactory.None<int>());

            var result = await none.MapAsync(one => one, () => -1);
            
            Assert.Equal(-1, result);
        } 
    }
}