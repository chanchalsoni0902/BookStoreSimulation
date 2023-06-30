public static class ExtentionMethods
{
    public static DateOnly GetDate(this DateTime dateTime)
    {
        DateTime dt = DateTime.Now;
        return DateOnly.FromDateTime(dt);
    }
}