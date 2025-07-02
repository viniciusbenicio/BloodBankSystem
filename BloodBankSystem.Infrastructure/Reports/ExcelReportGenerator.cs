using BloodBankSystem.Core.Services;
using ClosedXML.Excel;

namespace BloodBankSystem.Infrastructure.Reports
{
    public class ExcelReportGenerator : IReportGenerator
    {
        public async Task<byte[]> GenerateReportAsync<T>(IEnumerable<T> data)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Relatório");

            worksheet.Cell(1, 1).InsertTable(data);

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }
    }
}
