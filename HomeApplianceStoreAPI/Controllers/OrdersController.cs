using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeApplianceStoreAPI.Models;
using HomeApplianceStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HomeApplianceStoreAPI.Controllers
{
    /// <summary>
    /// Manage orders in the store
    /// </summary>
    [Route("api/orders")]
    public class OrdersController : Controller
    {

        private readonly StorageService<Order> storage;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="storage"></param>
        public OrdersController(StorageService<Order> storage)
        {
            this.storage = storage;
        }

        /// <summary>
        /// Get all orders
        /// </summary>
        /// <returns>A list of orders</returns>
        // GET api/values
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return storage.GetAll();
        }

        /// <summary>
        /// Get a specific order by id
        /// </summary>
        /// <param name="id">Id of ther order</param>
        /// <returns>The order</returns>
        // GET api/values/5
        [HttpGet("{id}")]
        public Order Get([FromRoute]string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create an order
        /// </summary>
        /// <param name="item">The order to create</param>
        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Order item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await this.storage.SaveItem(item);

            return Json(item);
        }

        /// <summary>
        /// Save an order
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(string id, Order item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete an order
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
