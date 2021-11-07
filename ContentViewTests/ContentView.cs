using System.Collections.Generic;

namespace ContentViewTests
{
    public sealed record ContentView
    {
        public IEnumerable<string> Uris { get; init; }

        public string ResultStatus { get; init; }
    }
}
