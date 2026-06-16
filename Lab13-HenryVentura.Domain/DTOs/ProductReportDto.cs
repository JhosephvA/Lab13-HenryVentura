namespace Lab13_HenryVentura.Domain.DTOs;

public class ProductReportDto
{
    public string ProductName { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
}