using HospitalManagementSystem.DataService.DTOs.Report;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using Document = iText.Layout.Document;

namespace HospitalManagementSystem.Core.Helper;

public class PDFReport
{
    public static byte[] GeneratePdfReport(ReportCreateDTO report)
    {
        using (var stream = new MemoryStream())
        {
            using (var pdfWriter = new PdfWriter(stream))
            {
                using (var pdfDocument = new PdfDocument(pdfWriter))
                {
                    var document = new Document(pdfDocument);

                    // Add title
                    document.Add(new Paragraph($"Patient Report - {report.ReportName} - {report.ReportType} - {report.CreatedDate}")
                            .SetFontColor(iText.Kernel.Colors.Color
                            .ConvertRgbToCmyk(new iText.Kernel.Colors.DeviceRgb(0, 123, 255)))
                            .SetFontSize(14)
                            .SetBold());

                    // Add patient information
                    document.Add(new Paragraph($"Patient Report for {report.PatientId} - {report.PatientName}")
                            .SetFontColor(iText.Kernel.Colors.Color
                            .ConvertRgbToCmyk(new iText.Kernel.Colors.DeviceRgb(40, 167, 69)))
                            .SetFontSize(12)
                            .SetBold());

                    document.Add(new Paragraph($"Date of Birth: {report.DateOfBirth}"));

                    document.Add(new Paragraph($"Address: {report.Address}"));

                    // Add separator
                    document.Add(new Paragraph("\n") // Add some space
                            .SetFontColor(iText.Kernel.Colors.Color
                            .ConvertRgbToCmyk(new iText.Kernel.Colors.DeviceRgb(0, 0, 0)))
                            .SetFontSize(1)); // Font size 1 creates a thin line

                    // Add report description
                    document.Add(new Paragraph("Report Description:")
                            .SetFontColor(iText.Kernel.Colors.Color
                            .ConvertRgbToCmyk(new iText.Kernel.Colors.DeviceRgb(255, 0, 0)))
                            .SetFontSize(12)
                            .SetBold());

                    document.Add(new Paragraph(report.ReportDescription));

                    // Close the document
                    document.Close();
                }
            }

            return stream.ToArray();
        }

    }
}