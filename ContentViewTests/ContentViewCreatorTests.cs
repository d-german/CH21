using System;
using System.Collections.Generic;
using NUnit.Framework;
using static ContentViewTests.ContentViewCreatorImperative;
using static ContentViewTests.UriType;

namespace ContentViewTests
{
    public class ContentViewCreatorTests
    {
        private const string ContentId = nameof(ContentId);

        [Test]
        public void GetContentViewImperativePartialDuplicatesTest()
        {
            var actual = GetContentView(ContentId, new List<string> { ViewerA, ViewerA, ViewerB }); // viewerB is not supported
            var expected = new ContentView
            {
                ResultStatus = ResultStatusPartial,
                Uris = new List<string> { $"https://{ViewerA}/{ContentId}" }
            };

            Assert.AreEqual(actual.ResultStatus, expected.ResultStatus);
            CollectionAssert.AreEqual(actual.Uris, expected.Uris);
        }

        [Test]
        public void GetContentViewImperativeCompleteTest()
        {
            var actual = GetContentView(ContentId, new List<string> { ViewerA, ViewerC, ViewerD }); // viewerB is not supported
            var expected = new ContentView
            {
                ResultStatus = ResultStatusComplete,
                Uris = new List<string>
                {
                    $"https://{ViewerA}/{ContentId}",
                    $"https://{ViewerC}/{ContentId}",
                    $"https://{ViewerD}/{ContentId}"
                }
            };

            Assert.AreEqual(actual.ResultStatus, expected.ResultStatus);
            CollectionAssert.AreEquivalent(actual.Uris, expected.Uris);
        }

        [Test]
        public void GetContentViewImperativeExceptionTest()
        {
            Assert.Throws<Exception>(() =>
            {
                _ = GetContentView(ContentId, new List<string> { ViewerB }); // viewerB is not supported
            });
        }

        [Test]
        public void GetContentViewDeclarativePartialDuplicatesTest()
        {
            var actual = ContentViewCreatorDeclarative.GetContentView(ContentId, new List<string> { ViewerA, ViewerA, ViewerB }); // viewerB is not supported
            var expected = new ContentView
            {
                ResultStatus = ResultStatusPartial,
                Uris = new List<string> { $"https://{ViewerA}/{ContentId}" }
            };

            Assert.AreEqual(actual.ResultStatus, expected.ResultStatus);
            CollectionAssert.AreEqual(actual.Uris, expected.Uris);
        }

        [Test]
        public void GetContentViewDeclarativeCompleteTest()
        {
            var actual = GetContentView(ContentId, new List<string> { ViewerA, ViewerC, ViewerD }); // viewerB is not supported
            var expected = new ContentView
            {
                ResultStatus = ResultStatusComplete,
                Uris = new List<string>
                {
                    $"https://{ViewerA}/{ContentId}",
                    $"https://{ViewerC}/{ContentId}",
                    $"https://{ViewerD}/{ContentId}"
                }
            };

            Assert.AreEqual(actual.ResultStatus, expected.ResultStatus);
            CollectionAssert.AreEquivalent(actual.Uris, expected.Uris);
        }

        [Test]
        public void GetContentViewDeclarativeExceptionTest()
        {
            Assert.Throws<Exception>(() =>
            {
                _ = GetContentView(ContentId, new List<string> { ViewerB }); // viewerB is not supported
            });
        }
    }
}
