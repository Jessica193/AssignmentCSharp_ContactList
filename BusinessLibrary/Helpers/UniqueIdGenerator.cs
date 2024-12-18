namespace BusinessLibrary.Helpers;

public static class UniqueIdGenerator
{
    public static string GenerateUniqueId()
    {
        return Guid.NewGuid().ToString();
    }
}
