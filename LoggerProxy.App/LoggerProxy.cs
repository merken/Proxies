using System;
using System.Reflection;

namespace LoggerProxy.App
{
    public class LoggerProxy : DispatchProxy
    {
        private object remote;
        public LoggerProxy SetRemoteObject(object remote)
        {
            this.remote = remote;
            return this;
        }

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            var originalConsoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;

            var now = DateTime.Now;
            Console.WriteLine($"Calling method {targetMethod.Name} on {this.remote} at {now.ToLongTimeString()}:{now.Millisecond}");
            var methodOnRemote = this.remote.GetType().GetMethod(targetMethod.Name);
            var remoteResult = methodOnRemote.Invoke(this.remote, args);
            var elapsed = DateTime.Now;
            Console.WriteLine($"Called method {targetMethod.Name} on {this.remote} and result was {remoteResult} at {elapsed.ToLongTimeString()}:{elapsed.Millisecond}. Total time in ms: {(elapsed - now).TotalMilliseconds}");

            Console.ForegroundColor = originalConsoleColor;
            return remoteResult;
        }
    }
}