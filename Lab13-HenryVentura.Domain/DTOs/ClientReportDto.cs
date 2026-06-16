namespace Lab13_HenryVentura.Domain.DTOs;

public class ClientReportDto
{
    public string ClientName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int TotalOrders { get; set; }
    public DateTime? LastOrderDate { get; set; }
}