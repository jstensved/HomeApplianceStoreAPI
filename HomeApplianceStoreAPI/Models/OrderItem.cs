using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApplianceStoreAPI.Models
{
    public class OrderItem
    {
        [Required]
        /// <summary>
        /// Id of product
        /// </summary>
        public string ProductId { get; set; }

        [Required, Range(1, 99)]
        /// <summary>
        /// Amount of products on order
        /// </summary>
        public int Amount { get; set; }

        [Required, Range(1, float.MaxValue)]
        /// <summary>
        /// The price of the product when order was created
        /// </summary>
        public float Price { get; set; }
    }
}
