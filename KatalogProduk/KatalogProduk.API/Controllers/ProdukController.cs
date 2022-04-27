using AutoMapper;
using KatalogProduk.API.DTO;
using KatalogProduk.Data.Interface;
using KatalogProduk.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KatalogProduk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdukController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProduk _produk;

        public ProdukController(IProduk produk, IMapper mapper)
        {
            _mapper = mapper;
            _produk = produk;
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
        public async Task<ActionResult<ProdukCreateDTO>> Post(ProdukCreateDTO produkCreateDTO)
        {
            try
            {
                var newProduk = _mapper.Map<Produk>(produkCreateDTO);
                var result = await _produk.Insert(newProduk);
                var samuraiDTO = _mapper.Map<ProdukDTO>(result);
                return CreatedAtAction("GetById", new { id = result.Id }, samuraiDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<ProdukController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProdukController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
