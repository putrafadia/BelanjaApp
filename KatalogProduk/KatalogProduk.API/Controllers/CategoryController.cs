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
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _category;
        private readonly IMapper _mapper;
        public CategoryController(ICategory category, IMapper mapper)
        {
            _category = category;
            _mapper = mapper;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> GetAsync()
        {
            var result = await _category.GetAll();
            var output = _mapper.Map<IEnumerable<CategoryDTO>>(result);
            return output;
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetById(int id)
        {
            var result = await _category.GetById(id);
            var output = _mapper.Map<CategoryDTO>(result);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(output);
            }

        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> Post(CreateCategoryDTO createCategoryDTO)
        {
            try
            {
                var newSamurai = _mapper.Map<Category>(createCategoryDTO);
                var result = await _category.Insert(newSamurai);
                var categotyDTO = _mapper.Map<CategoryDTO>(result);
                return CreatedAtAction("GetById", new { id = result.Id }, categotyDTO);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDTO>> Put(int id, CreateCategoryDTO createCategoryDTO)
        {
            try
            {
                var updateKategori = _mapper.Map<Category>(createCategoryDTO);
                var result = await _category.Update(id, updateKategori);
                var categoryDTO = _mapper.Map<CategoryDTO>(result);
                return Ok(categoryDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _category.Delete(id);
                return Ok($"record deleted {id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
