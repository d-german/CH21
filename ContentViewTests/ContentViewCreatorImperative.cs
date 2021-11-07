using System;
using System.Collections.Generic;
using System.Linq;
using static ContentViewTests.UriType;

namespace ContentViewTests
{
    public class ContentViewCreatorImperative
    {
        public const string ResultStatusPartial = nameof(ResultStatusPartial);
        public const string ResultStatusComplete = nameof(ResultStatusComplete);
        private static readonly ICollection<string> AllSupportedUriTypes = new List<string> { ViewerA, ViewerC, ViewerD };

        public ContentView GetContentView(string contentId, ICollection<string> uriTypes)
        {
            if (uriTypes.All(uriType => !AllSupportedUriTypes.Contains(uriType, StringComparer.OrdinalIgnoreCase)))
            {
                // If all of the uriTypes requested are not supported, throw an exception
                throw new Exception("message");
            }

            var uris = new List<string>();

            var hasUnsupportedUriTypes = false;
            var addedViewerA = false;
            var addedViewerC = false;
            var addedViewerD = false;

            foreach (var uriType in uriTypes)
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
