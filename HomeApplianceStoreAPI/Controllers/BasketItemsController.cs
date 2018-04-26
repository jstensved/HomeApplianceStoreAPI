using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeApplianceStoreAPI.Models;
using HomeApplianceStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace HomeApplianceStoreAPI.Controllers
{

    /// <summary>
    /// Manage items in user baskets
    /// </summary>
    [Route("api/basketitems")]
    public class BasketItemsController : Controller
    {
        private readonly StorageService<BasketItem> storage;

        public BasketItemsController(StorageService<BasketItem> storage)
        {
            this.storage = storage;
        }

        /// <summary>
        /// Read items from all baskets
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet]
        public IEnumerable<BasketItem> Get()
        {
            return storage.GetAll();
        }

        /// <summary>
        /// Read a specific item in a user basket
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add a basket entry
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]BasketItem item)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            await storage.SaveItem(item);

            return Json(item);
        }

        /// <summary>
        /// Get a specific entry by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]BasketItem item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete a basket entry
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
