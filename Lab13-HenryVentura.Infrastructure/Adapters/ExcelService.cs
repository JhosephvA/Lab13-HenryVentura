using ClosedXML.Excel;
using Lab13_HenryVentura.Domain.DTOs;
using Lab13_HenryVentura.Domain.Ports;

namespace Lab13_HenryVentura.Infrastructure.Adapters;

public class ExcelService : IExcelService
{
    public byte[] GenerateClientsReport(IEnumerable<object> data)
    {
        var clients = data.Cast<ClientReportDto>().ToList();

        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Clientes");

        // Encabezados con estilo
        var headerRow = worksheet.Row(1);
        headerRow.Style.Font.Bold = true;
        headerRow.Style.Fill.BackgroundColor = XLColor.CornflowerBlue;
        headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

        worksheet.Cell(1, 1).Value = "Cliente";
        worksheet.Cell(1, 2).Value = "Email";
        worksheet.Cell(1, 3).Value = "Total Pedidos";
        worksheet.Cell(1, 4).Value = "Último Pedido";

        // Datos
        int row = 2;
        foreach (var client in clients)
        {
            worksheet.Cell(row, 1).Value = client.ClientName;
            worksheet.Cell(row, 2).Value = client.Email;
            worksheet.Cell(row, 3).Value = client.TotalOrders;
            worksheet.Cell(row, 4).Value = client.LastOrderDate?.ToString("dd/MM/yyyy") ?? "Sin pedidos";
            row++;
        }

        // Crear tabla
        var range = worksheet.Range(1, 1, row - 1, 4);
        range.CreateTable();

        // Ajustar columnas
        worksheet.Columns().AdjustToContents();

        using var memoryStream = new MemoryStream();
        workbook.SaveAs(memoryStream);
        return memoryStream.ToArray();
    }

    public byte[] GenerateProductsReport(IEnumerable<object> data)
    {
        var products = data.Cast<ProductReportDto>().ToList();

        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Productos");

        // Encabezados con estilo
        var headerRow = worksheet.Row(1);
        headerRow.Style.Font.Bold = true;
        headerRow.Style.Fill.BackgroundColor = XLColor.LightGreen;
        headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

        worksheet.Cell(1, 1).Value = "Producto";
        worksheet.Cell(1, 2).Value = "Descripción";
        worksheet.Cell(1, 3).Value = "Precio";

        // Datos
        int row = 2;
        foreach (var product in products)
        {
            worksheet.Cell(row, 1).Value = product.ProductName;
            worksheet.Cell(row, 2).Value = product.Description ?? "Sin descripción";
            worksheet.Cell(row, 3).Value = product.Price;
            row++;
        }

        // Crear tabla
        var range = worksheet.Range(1, 1, row - 1, 3);
        range.CreateTable();

        // Ajustar columnas
        worksheet.Columns().AdjustToContents();

        using var memoryStream = new MemoryStream();
        workbook.SaveAs(memoryStream);
        return memoryStream.ToArray();
    }
}