using Lab13_HenryVentura.Domain.DTOs;
using Lab13_HenryVentura.Domain.Ports;
using MediatR;

namespace Lab13_HenryVentura.Application.UseCases.ProductUseCases.Queries;

public record GetProductsReportQuery : IRequest<byte[]>;

internal sealed class GetProductsReportQueryHandler : IRequestHandler<GetProductsReportQuery, byte[]>
{
    private readonly IUnitOfWork _uow;
    private readonly IExcelService _excelService;

    public GetProductsReportQueryHandler(IUnitOfWork uow, IExcelService excelService)
    {
        _uow = uow;
        _excelService = excelService;
    }

    public async Task<byte[]> Handle(GetProductsReportQuery request, CancellationToken cancellationToken)
    {
        var products = await _uow.Products.GetAllAsync();

        var data = products.Select(p => new ProductReportDto
        {
            ProductName = p.Name,
            Description = p.Description,
            Price = p.Price
        }).ToList();

        return _excelService.GenerateProductsReport(data.Cast<object>());
    }
}