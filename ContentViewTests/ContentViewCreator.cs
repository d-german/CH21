using System;
using System.Collections.Generic;
using System.Linq;

namespace ContentViewTests
{
    public class ContentViewCreator
    {
        private static readonly ICollection<string> AllSupportedUriTypes = new List<string> { UriType.Thumbnail, UriType.Bytes, UriType.FullBytes };

        public ContentView GetContentView(string contentId, ICollection<string> uriTypes)
        {
            if (uriTypes.All(uriType => AllSupportedUriTypes.Contains(uriType, StringComparer.OrdinalIgnoreCase)))
            {
                // If all of the uriTypes requested are not supported, throw an exception
                throw new Exception("message");
            }

            var uris = new List<string>();

            var unsupportedUriTypes = false;
            var isThumbnailAdded = false;
            var isFullBytesAdded = false;
            var isBytesAdded = false;

            foreach (var uriType in uriTypes)
            {
                if (UriType.IsThumbnail(uriType) && !isThumbnailAdded)
                {
                    uris.Add($"/thumbnail/{contentId}");
                    isThumbnailAdded = true;
                }

                if (UriType.IsFullBytes(uriType) && !isFullBytesAdded)
                {
                    uris.Add($"/full-bytes/{contentId}");
                    isFullBytesAdded = true;
                }
                else if (UriType.IsBytes(uriType) && !isBytesAdded)
                {
                    uris.Add($"/bytes/{contentId}");
                    isBytesAdded = true;
                }
                else if (UriType.IsViewer(uriType))
                {
                    unsupportedUriTypes = true;
                }
                else
                {
                    // ignore duplicate values
                }
            }

            return new ContentView()
            {
                Uris = uris,
                ResultStatus = unsupportedUriTypes ? "Partial" : "Complete"
            };
        }
    }
}
