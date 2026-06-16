using Lab13_HenryVentura.Domain.Entities;
using Lab13_HenryVentura.Domain.Ports;
using Lab13_HenryVentura.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Lab13_HenryVentura.Infrastructure.Adapters;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync() =>
        await _context.Products
            .AsNoTracking()
            .ToListAsync();
}