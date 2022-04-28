using KatalogProduk.API.DTO;
using KatalogProduk.API.SyncDataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace ServiceDataService
{
    public class HttpProdukDataClient : IProdukDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpProdukDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task SendProdukToTransaksi(ProdukDTO plat)
        {
            var httpContent = new StringContent(JsonSerializer.Serialize(plat),
             Encoding.UTF8, "aplication/json");

            var response = await _httpClient.PostAsync($"{_configuration["TransaksiService"]}",
            httpContent);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("-->  Sync Post ke Transaksi berhasil  dikirim");
            }
            else
            {
                Console.WriteLine("-->  Sync Post ke Transaksi gagal  dikirim");
            }
        }
    }


}