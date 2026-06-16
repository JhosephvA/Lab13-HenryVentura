using Lab13_HenryVentura.Domain.Entities;

namespace Lab13_HenryVentura.Domain.Ports;

public interface IClientRepository
{
    Task<IEnumerable<Client>> GetAllWithOrdersAsync();
}