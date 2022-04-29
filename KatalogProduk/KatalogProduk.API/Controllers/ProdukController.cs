using AutoMapper;
using KatalogProduk.API.DTO;
using KatalogProduk.API.SyncDataServices;
using KatalogProduk.Data.Interface;
using KatalogProduk.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KatalogProduk.API.Controllers
{
    [Route("api/category/{categoryId}/[controller]")]
    [ApiController]
    public class ProdukController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProduk _produk;
        private readonly IProdukDataClient _produkDataClient;

        public ProdukController(IProduk produk, IMapper mapper, IProdukDataClient produkDataClient )
        {
            _mapper = mapper;
            _produk = produk;
            _produkDataClient =produkDataClient;
        }
        // GET: api/<ProdukController>
        [HttpGet]
        public async Task<IEnumerable<ProdukDTO>> Get(int categoryId)
        {
            var result = await _produk.GetAllProduk(categoryId);
            var output = _mapper.Map<IEnumerable<ProdukDTO>>(result);
            return output;
        }

        // GET api/<ProdukController>/5
        [HttpGet("{produkId}")]
        public async Task<ActionResult<ProdukDTO>> GetById(int categoryId, int produkId)
        {
            var result = await _produk.GetProduk(categoryId,produkId); 
            var output = _mapper.Map<ProdukDTO>(result);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(output);
            }
        }

        // POST api/<ProdukController>
        [HttpPost]
        public async Task<ActionResult<ProdukCreateDTO>> Post(int categoryId, ProdukCreateDTO produkCreateDTO)
        {

            if (!_produk.CategoryExist(categoryId))
                return NotFound();

            var produk = _mapper.Map<Produk>(produkCreateDTO);
            var result = await _produk.CreateProduk(categoryId, produk);
            var produkDto = _mapper.Map<ProdukDTO>(result);
            try
            {
               await _produkDataClient.SendProdukToTransaksi(produkDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Tidak dapat mengirimkan Sync Data: {ex.Message}");
            }
            return CreatedAtAction(nameof(GetById),
                   new { categoryId = categoryId, produkId = produkDto.Id },
                       produkDto);
        }

        // PUT api/<ProdukController>/5
        [HttpPut("{produkId}")]
        public async Task<ActionResult<ProdukCreateDTO>> Put(int categoryId, int produkId, ProdukCreateDTO produkCreateDTO)
        {
            try
            {
                if (!_produk.CategoryExist(categoryId))
                    return NotFound();

                var produk = _mapper.Map<Produk>(produkCreateDTO);
                var result = await _produk.UpdateProduk(categoryId, produkId,produk);
                var produkDto = _mapper.Map<ProdukDTO>(result);


                return CreatedAtAction(nameof(GetById),
                    new { categoryId = categoryId, produkId = produkDto.Id },
                        produkDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProdukController>/5
        [HttpDelete("{produkId}")]
        public async Task<IActionResult> Delete(int categoryId, int produkId)
        {
            try
            {
                await _produk.Delete(categoryId,produkId);
                return Ok($"record deleted {produkId}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
