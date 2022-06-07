using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;
using Insomnia.Agreemod.Data.Dto;
using Insomnia.Agreemod.Data.Base;
using Insomnia.Agreemod.General.Expansions;
using Insomnia.Agreemod.Data.Attributes;
using Insomnia.Agreemod.BI.Interfaces;
using System.Globalization;
using System.IO;
using System.Drawing;

namespace Insomnia.Agreemod.BI.Services
{
    public class ExcelService : IExcel
    {
        private Dictionary<int, string> Headers = new Dictionary<int, string>();

        private int _startRow = 1;
        private int _startElementsRow => _startRow + 1;

        public ExcelService()
        {

        }

        private string GetHeader(int id)
        {
            var h = Headers.FirstOrDefault(x => x.Key == id);

            if (h.Value is null)
                return null;

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(h.Value);
        }

        private int AddHeader(string header)
        {
            var h = Headers.FirstOrDefault(x => x.Value == header.ToLower());

            if (h.Value is null)
            {
                var id = Headers.Count;

                Headers.Add(id, header);

                return id;
            }
            return h.Key;
        }

        public byte[] ExcelFileGenerate<T>(List<T> report) where T : ExportModel
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(new FileInfo("MyWorkbook.xlsx")))
            {
                var sheet = package.Workbook.Worksheets
                    .Add("Лист1");

                var properties = typeof(T).GetProperties().Select(x =>
                {
                    var headerAttribute = x.GetCustomAttributes(typeof(HeaderNamingAttribute), false);
                    if (headerAttribute.Length != 1)
                        return null;

                    var header = AddHeader(((HeaderNamingAttribute)headerAttribute[0]).Header);

                    return new
                    {
                        PropertyInfo = x,
                        Header = header
                    };
                }).Where(x => x != null).ToList();

                int row = _startRow;

                foreach (var key in Headers.Keys)
                {
                    sheet.Cells[row, key+1].Value = GetHeader(key);
                }

                row = _startElementsRow;

                foreach (var item in report)
                {
                    Type t = item.GetType();

                    foreach (var p in t.GetProperties())
                    {
                        var pInfo = properties.FirstOrDefault(x => x.PropertyInfo?.Name == p.Name);
                        if (pInfo is null)
                            continue;

                        sheet.Cells[row, pInfo.Header+1].Value = pInfo.PropertyInfo.GetValue(item);
                    }

                    row++;
                }

                for(var col = 1; col <= Headers.Count; col++)
                    sheet.Column(col).Width = 22;

                var lastRowNumber = report.Count + 1;
                var lastColNumber = Headers.Count;
                var headerCells = sheet.Cells[_startRow, 1, 1, lastColNumber];
                var allCells = sheet.Cells[_startRow, 1, lastRowNumber, lastColNumber];
                var elementsCells = sheet.Cells[_startElementsRow, 1, lastRowNumber, lastColNumber];

                headerCells.Style.Font.Bold = true;

                headerCells.Style.Fill.PatternType = ExcelFillStyle.Solid;
                headerCells.Style.Fill.BackgroundColor.SetColor(Color.LightGray);

               /* headerCells.Style.Border.Top.Style = ExcelBorderStyle.Thick;
                headerCells.Style.Border.Left.Style = ExcelBorderStyle.Thick;
                headerCells.Style.Border.Right.Style = ExcelBorderStyle.Thick;
                headerCells.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;

                elementsCells.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                elementsCells.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                elementsCells.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                elementsCells.Style.Border.Bottom.Style = ExcelBorderStyle.Thin; */

                allCells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                return package.GetAsByteArray();
            }
        }
    }
}
