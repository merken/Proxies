using System;

namespace ForeignLibrary
{
    public class ForeignService
    {
        public string Foo()
        {
            return "bar";
        }

        public override string ToString() => $"{nameof(ForeignService)}";
    }
}
