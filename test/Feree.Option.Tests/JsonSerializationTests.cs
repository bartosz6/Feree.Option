using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace Feree.Option.Tests
{
    public class JsonSerializationTests
    {
        [Fact]
        public void Some_shouldBeSerializableToJson()
        {
            var someString = OptionFactory.Some("test");

            var serialized = JsonConvert.SerializeObject(someString);
            
            serialized.ShouldBe("{\"Value\":\"test\"}");
        }
        
        [Fact]
        public void None_shouldBeSerializableToJson()
        {
            var noneString = OptionFactory.None<string>();

            var serialized = JsonConvert.SerializeObject(noneString);
            
            serialized.ShouldBe("{}");
        }
        
    }
}