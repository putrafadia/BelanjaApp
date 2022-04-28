using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shipping.API.DTO;
using Shipping.Data.Interface;
using Shipping.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shipping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        private readonly IShipping _shipping;
        private readonly IMapper _mapper;

        public ShippingController(IShipping shipping, IMapper mapper)
        {
            _shipping = shipping;
            _mapper = mapper;
        }
        // GET: api/<ShippingController>
        [HttpGet]
        public async Task<IEnumerable<Pengiriman>> Get()
        {
            var result = await _shipping.GetAll();
            return result;
        }

        // GET api/<ShippingController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShippingDTO>> GetById(int id)
        {
            var result = await _shipping.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(_mapper.Map<ShippingDTO>(result));
        }

        // POST api/<ShippingController>
        [HttpPost]
        public async Task<ActionResult<ShippingDTO>> Post(ShippingCreateDTO shippingCreateDTO)
        {
            try
            {
                var newProduk = _mapper.Map<Pengiriman>(shippingCreateDTO);
                var result = await _shipping.Insert(newProduk);
                var shippingDTO = _mapper.Map<ShippingDTO>(result);
                return CreatedAtAction("GetById", new { id = result.Id }, shippingDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ShippingController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, ShippingCreateDTO shippingCreateDTO)
        {
            try
            {
                var updateKategori = _mapper.Map<Pengiriman>(shippingCreateDTO);
                var result = await _shipping.Update(id, updateKategori);
                var categoryDTO = _mapper.Map<ShippingDTO>(result);
                return Ok(categoryDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ShippingController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _shipping.Delete(id);
                return Ok($"record deleted {id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
