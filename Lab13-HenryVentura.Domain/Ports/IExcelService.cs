namespace Lab13_HenryVentura.Domain.Ports;

public interface IExcelService
{
    byte[] GenerateClientsReport(IEnumerable<object> data);
    byte[] GenerateProductsReport(IEnumerable<object> data);
}