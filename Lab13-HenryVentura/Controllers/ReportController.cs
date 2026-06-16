using Lab13_HenryVentura.Application.UseCases.ClientUseCases.Queries;
using Lab13_HenryVentura.Application.UseCases.ProductUseCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab13_HenryVentura.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReportController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // Reporte 1: Clientes con sus pedidos
    [HttpGet("clients")]
    public async Task<IActionResult> GetClientsReport()
    {
        var file = await _mediator.Send(new GetClientsReportQuery());
        return File(file, 
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "ReporteClientes.xlsx");
    }

    // Reporte 2: Productos con precios
    [HttpGet("products")]
    public async Task<IActionResult> GetProductsReport()
    {
        var file = await _mediator.Send(new GetProductsReportQuery());
        return File(file,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "ReporteProductos.xlsx");
    }
}