using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Transaksi.Data.Interface;
using Transaksi.Domain;
using TransaksiBelanja.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransaksiBelanja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaksiController : ControllerBase
    {
        private readonly ITransaksi _transaksibelanja;
        private readonly IMapper _mapper;

        public TransaksiController(IMapper mapper,ITransaksi transaksi)
        {
            _transaksibelanja = transaksi;
            _mapper = mapper;

        }
        // GET: api/<TransaksiController>
        [HttpGet]
        public async Task<IEnumerable<TransaksiBelanjas>> Get()
        {
            var results = await _transaksibelanja.GetAll();
            return results;
        }


        // GET api/<TransaksiController>/5
        [HttpGet("{id}")]
            public async Task<ActionResult<ViewTransaksiDTO>> GetById(int id)           
            {
                var result = await _transaksibelanja.GetById(id);
                if (result == null)
                    return NotFound();

                return Ok(_mapper.Map<ViewTransaksiDTO>(result));                       
            }

        // POST api/<TransaksiController>
        [HttpPost]
        public async Task<ActionResult<ViewTransaksiDTO>> Post(CreateTransaksiDTO createTransaksiDTO)         
        {
            try
            {

                var newTransaksi = _mapper.Map<TransaksiBelanjas>(createTransaksiDTO);
                var result = await _transaksibelanja.Insert(newTransaksi);
                var transaksiDto = _mapper.Map<ViewTransaksiDTO>(result);

                return CreatedAtAction("GetById", new { id = result.Id },transaksiDto);  

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TransaksiController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, CreateTransaksiDTO createTransaksiDTO)
        {
            try
            {
                var updateTransaksi = _mapper.Map<TransaksiBelanjas>(createTransaksiDTO);
                var result = await _transaksibelanja.Update(id, updateTransaksi);
                var transaksiDTO = _mapper.Map<ViewTransaksiDTO>(result);
                return Ok(transaksiDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<TransaksiController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _transaksibelanja.Delete(id);
                return Ok($"record {id} deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
