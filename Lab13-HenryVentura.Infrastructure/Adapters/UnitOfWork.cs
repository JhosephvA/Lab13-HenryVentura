using Lab13_HenryVentura.Domain.Ports;
using Lab13_HenryVentura.Infrastructure.Context;

namespace Lab13_HenryVentura.Infrastructure.Adapters;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IClientRepository Clients { get; }
    public IProductRepository Products { get; }

    public UnitOfWork(AppDbContext context,
        IClientRepository clients,
        IProductRepository products)
    {
        _context = context;
        Clients = clients;
        Products = products;
    }

    public async Task<int> SaveChangesAsync() =>
        await _context.SaveChangesAsync();
}