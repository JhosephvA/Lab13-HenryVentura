using Lab13_HenryVentura.Domain.DTOs;
using Lab13_HenryVentura.Domain.Ports;
using MediatR;
namespace Lab13_HenryVentura.Application.UseCases.ClientUseCases.Queries;
public record GetClientsReportQuery : IRequest<byte[]>;

internal sealed class GetClientsReportQueryHandler : IRequestHandler<GetClientsReportQuery, byte[]>
{
    private readonly IUnitOfWork _uow;
    private readonly IExcelService _excelService;

    public GetClientsReportQueryHandler(IUnitOfWork uow, IExcelService excelService)
    {
        _uow = uow;
        _excelService = excelService;
    }

    public async Task<byte[]> Handle(GetClientsReportQuery request, CancellationToken cancellationToken)
    {
        var clients = await _uow.Clients.GetAllWithOrdersAsync();

        var data = clients.Select(c => new ClientReportDto
        {
            ClientName = c.Name,
            Email = c.Email,
            TotalOrders = c.Orders.Count,
            LastOrderDate = c.Orders
                .OrderByDescending(o => o.Orderdate)
                .FirstOrDefault()?.Orderdate
        }).ToList();

        return _excelService.GenerateClientsReport(data.Cast<object>());
    }
}