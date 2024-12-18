using BusinessLibrary.Helpers;

namespace BusinessLibrary.Tests.Helpers;

public class UniqueIdGenerator_Tests
{
    [Fact]
    public void GenerateUniqueId_ShouldGenerateGuidOfTypeString()
    {
        //act
        string result = UniqueIdGenerator.GenerateUniqueId();

        //assert
        Assert.IsType<string>(result);
        Assert.NotNull(result);
        Assert.True(Guid.TryParse(result, out _));
    }
}
