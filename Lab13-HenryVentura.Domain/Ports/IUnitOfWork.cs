namespace Lab13_HenryVentura.Domain.Ports;

public interface IUnitOfWork
{
    IClientRepository Clients { get; }
    IProductRepository Products { get; }
    Task<int> SaveChangesAsync();
}