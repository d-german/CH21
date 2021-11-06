using System.Collections.Generic;

namespace ContentViewTests
{
    public sealed class ContentView
    {
        public IEnumerable<string> Uris { get; set; }

        public string ResultStatus { get; set; }
    }
}