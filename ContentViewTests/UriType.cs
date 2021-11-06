using System;

namespace ContentViewTests
{
    public static class UriType
    {
        public const string Bytes = "Bytes";
        public const string Viewer = "Viewer";
        public const string FullBytes = "FullBytes";
        public const string Thumbnail = "Thumbnail";

        public static bool IsValid(string uriType)
        {
            return IsViewer(uriType) || IsBytes(uriType) || IsFullBytes(uriType) || IsThumbnail(uriType);
        }

        public static bool IsThumbnail(string uriType)
        {
            return string.Equals(uriType, Thumbnail, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsFullBytes(string uriType)
        {
            return string.Equals(uriType, FullBytes, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsViewer(string uriType)
        {
            return string.Equals(uriType, Viewer, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsBytes(string uriType)
        {
            return string.Equals(uriType, Bytes, StringComparison.OrdinalIgnoreCase);
        }
    }
}