using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Mime;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable  ConvertIfStatementToSwitchExpression
// ReSharper disable  ConvertIfStatementToSwitchStatement
// ReSharper disable ConvertSwitchStatementToSwitchExpression
namespace CH21Tests
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public static class MediaTypeToFileName
    {
        public const string Dicom = "application/vnd.hyland.nilread.apiviewer+dicom";
        public const string Excel = "application/vnd.ms-excel";
        public const string Html = MediaTypeNames.Text.Html;
        public const string MultipartForm = "multipart/form-data";
        public const string Pdf = MediaTypeNames.Application.Pdf;
        public const string Word = "application/msword";

        public const string DefaultFileName = "Undefined.png";
        public const string DicomStudyFileName = "DICOMStudy.png";
        public const string MsExcelFileName = "MsExcel.png";
        public const string HtmlFileName = "HTML.png";
        public const string ElectronicFormFileName = "ElectronicForm.png";
        public const string PdfFileName = "Pdf.png";
        public const string MsWordFileName = "MsWord.png";

        private static readonly IDictionary<string, string> ToFileName = new Dictionary<string, string>
        {
            [Dicom] = DicomStudyFileName,
            [Excel] = MsExcelFileName,
            [Html] = HtmlFileName,
            [MultipartForm] = ElectronicFormFileName,
            [Pdf] = PdfFileName,
            [Word] = MsWordFileName
        }.ToImmutableDictionary();

        public static string GetFileNameDeclarative(string mediaType)
        {
            return ToFileName.ContainsKey(mediaType) ? ToFileName[mediaType] : DefaultFileName;
        }

        public static string GetFileNameImperativeSwitchStatement(string mediaType)
        {
            switch (mediaType)
            {
                case Dicom:
                    return DicomStudyFileName;
                case Excel:
                    return MsExcelFileName;
                case Html:
                    return HtmlFileName;
                case MultipartForm:
                    return ElectronicFormFileName;
                case PdfFileName:
                    return PdfFileName;
                case Word:
                    return MsWordFileName;
                default:
                    return DefaultFileName;
            }
        }

        public static string GetFileNameImperativeMultipleIf(string mediaType)
        {
            if (mediaType == Dicom)
                return DicomStudyFileName;
            if (mediaType == Excel)
                return MsExcelFileName;
            if (mediaType == Html)
                return HtmlFileName;
            if (mediaType == MultipartForm)
                return ElectronicFormFileName;
            if (mediaType == PdfFileName)
                return PdfFileName;
            if (mediaType == Word)
                return MsWordFileName;
            return DefaultFileName;
        }

        public static string GetFileNameSwitchExpression(string mediaType)
        {
            // Might prefer this to the dictionary if only using the dictionary in one place
            // Beginning with C# 8.0, you can use the switch expression
            return mediaType switch
            {
                Dicom => DicomStudyFileName,
                Excel => MsExcelFileName,
                Html => HtmlFileName,
                MultipartForm => ElectronicFormFileName,
                PdfFileName => PdfFileName,
                Word => MsWordFileName,
                _ => DefaultFileName
            };
        }

        public static string GetFileNameDeclarativeNoDefault(string mediaType)
        {
            return ToFileName[mediaType];
        }
    }
}
