using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApplianceStoreAPI.Models
{
    public class BasketItem
    {
        /// <summary>
        /// Username of the user
        /// </summary>
        [Required]
        public string User { get; set; }

        /// <summary>
        /// Id of product
        /// </summary>
        [Required(ErrorMessage = "Basket item must have a product id", AllowEmptyStrings = false)]
        public string ProductId { get; set; }

        /// <summary>
        /// Amount of items in basket
        /// </summary>
        [Required,Range(1d, 100d, ErrorMessage = "Amount must be between 1 and 100.")]
        public int Amount { get; set; }
    }
}
