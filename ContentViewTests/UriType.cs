using System;

namespace ContentViewTests
{
    public static class UriType
    {
        public const string ViewerA = nameof(ViewerA);
        public const string ViewerB = nameof(ViewerB);
        public const string ViewerC = nameof(ViewerC);
        public const string ViewerD = nameof(ViewerD);

        public static bool IsValid(string uriType)
        {
            return IsViewerB(uriType) || IsViewerA(uriType) || IsViewerC(uriType) || IsViewerD(uriType);
        }

        public static bool IsViewerA(string uriType)
        {
            return string.Equals(uriType, ViewerA, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsViewerB(string uriType)
        {
            return string.Equals(uriType, ViewerB, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsViewerC(string uriType)
        {
            return string.Equals(uriType, ViewerC, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsViewerD(string uriType)
        {
            return string.Equals(uriType, ViewerD, StringComparison.OrdinalIgnoreCase);
        }
    }
}
