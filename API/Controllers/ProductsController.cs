using Microsoft.AspNetCore.Mvc;
// using Infrastructure.Data; -> replaced with Core.Interfaces
using Core.Interfaces;
using System.Collections.Generic;
using Core.Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController: ControllerBase
    {
        /* private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        } -> replaced with IProductRepository */
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        /* [HttpGet]
        public string GetProducts()
        {
            return "this will be a list of products";
        } */
        // Blocking
        /* [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        } */
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            // var products = await _context.Products.ToListAsync(); -> replace for IProductRepository
            var products = await _repo.GetProductsAsync();
            return Ok(products);
        }

        /* [HttpGet("{id}")]
        public string GetProduct(int id)
        {
            return "single product";
        } */
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            // return await _context.Products.FindAsync(id); -> replace for IProductRepository
            return await _repo.GetProductByIdAsync(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _repo.GetProductBrandsAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _repo.GetProductTypesAsync());
        }
    } 
}