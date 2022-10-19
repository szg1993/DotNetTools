namespace ExGuard
{
    public static class ExGuard
    {
        private static TException GetException<TException>(string message) where TException : Exception, new()
            => (TException)Activator.CreateInstance(typeof(TException), message);
    }
}