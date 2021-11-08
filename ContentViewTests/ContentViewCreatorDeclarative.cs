using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using static ContentViewTests.UriType;

// ReSharper disable All

namespace ContentViewTests
{
    public class ContentViewCreatorDeclarative
    {
        public const string ResultStatusPartial = nameof(ResultStatusPartial);
        public const string ResultStatusComplete = nameof(ResultStatusComplete);

        private static readonly ImmutableHashSet<string> AllSupportedUriTypes = ImmutableHashSet.Create(ViewerA, ViewerC, ViewerD);

        public static ContentView GetContentView(string contentId, IReadOnlyCollection<string> requestedUriTypes)
        {
            ImmutableHashSet<string> subsetUriTypes = AllSupportedUriTypes.Intersect(requestedUriTypes);

            if (!subsetUriTypes.Any()) throw new Exception("message");

            return new ContentView
            {
                ResultStatus = AllSupportedUriTypes.SetEquals(subsetUriTypes) ? ResultStatusComplete : ResultStatusPartial,
                Uris = subsetUriTypes.Select(uriType =>
                {
                    if (IsViewerA(uriType))
                    {
                        return $"https://{ViewerA}/{contentId}";
                    }
                    else if (IsViewerC(uriType))
                    {
                        return $"https://{ViewerC}/{contentId}";
                    }
                    else
                    {
                        return $"https://{ViewerD}/{contentId}";
                    }
                })
            };
        }
    }
}
