﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using static ContentViewTests.UriType;

namespace ContentViewTests
{
    public class ContentViewCreatorDeclarative
    {
        public const string ResultStatusPartial = nameof(ResultStatusPartial);
        public const string ResultStatusComplete = nameof(ResultStatusComplete);

        private static readonly ImmutableHashSet<string> AllSupportedUriTypes = ImmutableHashSet.Create(ViewerA, ViewerC, ViewerD);

        public ContentView GetContentView(string contentId, IReadOnlyCollection<string> requestedUriTypes)
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

                    return IsViewerC(uriType) ? $"https://{ViewerC}/{contentId}" : $"https://{ViewerD}/{contentId}";
                })
            };
        }
    }
}
