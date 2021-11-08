using System;
using System.Collections.Generic;
using System.Linq;
using static ContentViewTests.UriType;
// ReSharper disable All

namespace ContentViewTests
{
    public class ContentViewCreatorImperative
    {
        public const string ResultStatusPartial = nameof(ResultStatusPartial);
        public const string ResultStatusComplete = nameof(ResultStatusComplete);

        private static readonly ICollection<string> AllSupportedUriTypes = new List<string> { ViewerA, ViewerC, ViewerD };

        // Cyclomatic complexity 11
        public static ContentView GetContentView(string contentId, ICollection<string> requestedUriTypes)
        {
            if (requestedUriTypes.All(uriType => !AllSupportedUriTypes.Contains(uriType))) throw new Exception("message");

            var uris = new List<string>();

            var hasUnsupportedUriTypes = false;
            var addedViewerA = false;
            var addedViewerC = false;
            var addedViewerD = false;

            foreach (var uriType in requestedUriTypes)
            {
                if (IsViewerA(uriType) && !addedViewerA)
                {
                    uris.Add($"https://{ViewerA}/{contentId}");
                    addedViewerA = true;
                }
                else if (IsViewerB(uriType))
                {
                    hasUnsupportedUriTypes = true;
                }
                else if (IsViewerC(uriType) && !addedViewerC)
                {
                    uris.Add($"https://{ViewerC}/{contentId}");
                    addedViewerC = true;
                }
                else if (IsViewerD(uriType) && !addedViewerD)
                {
                    uris.Add($"https://{ViewerD}/{contentId}");
                    addedViewerD = true;
                }
                else
                {
                    // ignore duplicate values
                }
            }

            return new ContentView()
            {
                Uris = uris,
                ResultStatus = hasUnsupportedUriTypes ? ResultStatusPartial : ResultStatusComplete
            };
        }
    }
}
