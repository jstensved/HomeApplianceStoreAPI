using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeApplianceStoreAPI.Models;
using HomeApplianceStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HomeApplianceStoreAPI.Controllers
{
    [Route("api/products")]
    public class ProductsController : Controller
    {
        private readonly StorageService<Product> storage;

        public ProductsController(StorageService<Product> storage)
        {
            this.storage = storage;
        }

        /// <summary>
        /// List all products with optional filtering
        /// </summary>
        /// <param name="cat">Enter a category to only show products in this category. Not case sensitive.</param>
        /// <returns>A list of products</returns>
        [HttpGet]
        public IEnumerable<Product> List(string cat = null)
        {
            var items = storage.GetAll();

            if (!string.IsNullOrEmpty(cat))
            {
                items = items.Where(x => x.Categories.Any(c => c.ToLowerInvariant() == cat.ToLowerInvariant())).ToList();
            }

            return items;
        }

        /// <summary>
        /// Return a single product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public string Get(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a new product
        /// </summary>
        /// <param name="item">The product to create</param>
        /// <returns>The created product</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Product item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await storage.SaveItem(item);

            return Json(item);
        }

        /// <summary>
        /// Save a product
        /// </summary>
        /// <param name="id">Id of the product to save</param>
        /// <param name="value">The product to save</param>
        [HttpPut("{id}")]
        public void Put([FromRoute]string id, [FromBody]Product value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="id">The Product to delete</param>
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
