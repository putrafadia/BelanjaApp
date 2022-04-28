using KatalogProduk.API.DTO;

namespace KatalogProduk.API.SyncDataServices
{
    public interface IProdukDataClient
    {
        Task SendProdukToTransaksi(ProdukDTO plat);
    }
}
