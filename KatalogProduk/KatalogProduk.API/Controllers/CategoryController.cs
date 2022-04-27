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
        //private readonly IMapper _mapper;
        public CategoryController(ICategory category)
        {
            _category = category;
            //_mapper = mapper;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IEnumerable<Category>> GetAsync()
        {
            var result = await _category.GetAll();
           // var output = _mapper.Map<IEnumerable<SamuraiDTO>>(result);
            return result;
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
