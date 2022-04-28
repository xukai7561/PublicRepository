namespace FilterTest
{
    [AttributeUsage(AttributeTargets.Method)]
    public class NotTransactionalAttribute : Attribute
    {
    }
}
