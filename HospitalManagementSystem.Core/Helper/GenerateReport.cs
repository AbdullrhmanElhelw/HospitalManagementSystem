using HospitalManagementSystem.DataService.DTOs.Report;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;

namespace HospitalManagementSystem.Core.Helper;

public  class GenerateReport
{
    public static byte[] GenereatePatientReport(ReportCreateDTO reportCreateDTO)
    {
        using var excel = new ExcelPackage();
        var workSheet = excel.Workbook.Worksheets.Add("Patient Report");

        // Add headers
        workSheet.Cells[1, 1].Value = "Patient Id";
        workSheet.Cells[1, 2].Value = "Patient Name";
        workSheet.Cells[1, 3].Value = "Date Of Birth";
        workSheet.Cells[1, 4].Value = "Address";
        workSheet.Cells[1, 5].Value = "Report Type";
        workSheet.Cells[1, 6].Value = "Report Name";
        workSheet.Cells[1, 7].Value = "Report Description";
        workSheet.Cells[1, 8].Value = "Created Date";

        // Apply formatting to headers
        workSheet.Cells["A1:H1"].Style.Font.Bold = true;
        workSheet.Cells["A1:H1"].Style.Font.Size = 16;
        workSheet.Cells["A1:H1"].Style.Font.Color.SetColor(Color.Black);
        // center the text
        workSheet.Cells["A1:H1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        // Add data
        workSheet.Cells[2, 1].Value = reportCreateDTO.PatientId;
        workSheet.Cells[2, 2].Value = reportCreateDTO.PatientName;
        workSheet.Cells[2, 3].Value = reportCreateDTO.DateOfBirth.ToString("dd/MM/yyyy");
        workSheet.Cells[2, 4].Value = reportCreateDTO.Address;
        workSheet.Cells[2, 5].Value = reportCreateDTO.ReportType;
        workSheet.Cells[2, 6].Value = reportCreateDTO.ReportName;
        workSheet.Cells[2, 7].Value = reportCreateDTO.ReportDescription;
        workSheet.Cells[2, 8].Value = reportCreateDTO.CreatedDate.ToString("dd/MM/yyyy");

        // Apply formatting to data
        workSheet.Cells["A2:H2"].Style.Font.Bold = false;
        workSheet.Cells["A2:H2"].Style.Font.Size = 14;
        workSheet.Cells["A2:H2"].Style.Font.Color.SetColor(Color.Red);
        // center the text
        workSheet.Cells["A2:H2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

        // Auto-fit columns
        workSheet.Cells.AutoFitColumns();

        // Save to memory stream and return as byte array
        using var memoryStream = new MemoryStream(excel.GetAsByteArray());
        memoryStream.Position = 0;
        return memoryStream.ToArray();
    }

    public static byte[] GenereatePatientReport(List<ReportCreateDTO> reportCreateDTOs)
    {
        using var excel = new ExcelPackage();
        var workSheet = excel.Workbook.Worksheets.Add("Patient Report");

        // Add headers
        workSheet.Cells[1, 1].Value = "Patient Id";
        workSheet.Cells[1, 2].Value = "Patient Name";
        workSheet.Cells[1, 3].Value = "Date Of Birth";
        workSheet.Cells[1, 4].Value = "Address";
        workSheet.Cells[1, 5].Value = "Report Type";
        workSheet.Cells[1, 6].Value = "Report Name";
        workSheet.Cells[1, 7].Value = "Report Description";
        workSheet.Cells[1, 8].Value = "Created Date";

        // Apply formatting to headers
        workSheet.Cells["A1:H1"].Style.Font.Bold = true;
        workSheet.Cells["A1:H1"].Style.Font.Size = 16;
        workSheet.Cells["A1:H1"].Style.Font.Color.SetColor(Color.Black);
        // center the text
        workSheet.Cells["A1:H1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        // Add data
        for (int i = 0; i < reportCreateDTOs.Count; i++)
        {
            workSheet.Cells[i + 2, 1].Value = reportCreateDTOs[i].PatientId;
            workSheet.Cells[i + 2, 2].Value = reportCreateDTOs[i].PatientName;
            workSheet.Cells[i + 2, 3].Value = reportCreateDTOs[i].DateOfBirth.ToString("dd/MM/yyyy");
            workSheet.Cells[i + 2, 4].Value = reportCreateDTOs[i].Address;
            workSheet.Cells[i + 2, 5].Value = reportCreateDTOs[i].ReportType;
            workSheet.Cells[i + 2, 6].Value = reportCreateDTOs[i].ReportName;
            workSheet.Cells[i + 2, 7].Value = reportCreateDTOs[i].ReportDescription;
            workSheet.Cells[i + 2, 8].Value = reportCreateDTOs[i].CreatedDate.ToString("dd/MM/yyyy");
        }

        // Apply formatting to data
        workSheet.Cells["A2:H2"].Style.Font.Bold = false;
        workSheet.Cells["A2:H2"].Style.Font.Size = 14;
        workSheet.Cells["A2:H2"].Style.Font.Color.SetColor(Color.Red);
        // center the text
        workSheet.Cells["A2:H2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

        // Auto-fit columns
        workSheet.Cells.AutoFitColumns();

        // Save to memory stream and return as byte array
        using var memoryStream = new MemoryStream(excel.GetAsByteArray());
        memoryStream.Position = 0;
        return memoryStream.ToArray();
    }

}
