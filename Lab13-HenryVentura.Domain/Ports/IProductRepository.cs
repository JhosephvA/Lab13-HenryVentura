using Lab13_HenryVentura.Domain.Entities;

namespace Lab13_HenryVentura.Domain.Ports;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
}