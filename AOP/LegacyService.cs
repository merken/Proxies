namespace AOP
{
    // Dealing with legacy code using Interfaces and Proxies
    public class LegacyService
    {
        protected string DoLegacyStuff(string input)
        {
            return $"Legacy: {input}";
        }
    }
}