using Lab13_HenryVentura.Domain.Entities;
using Lab13_HenryVentura.Domain.Ports;
using Lab13_HenryVentura.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Lab13_HenryVentura.Infrastructure.Adapters;

public class ClientRepository : IClientRepository
{
    private readonly AppDbContext _context;

    public ClientRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Client>> GetAllWithOrdersAsync() =>
        await _context.Clients
            .Include(c => c.Orders)
            .AsNoTracking()
            .ToListAsync();
}