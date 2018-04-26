using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApplianceStoreAPI.Models
{
    public class Order
    {
        /// <summary>
        /// Id of order
        /// </summary>
        [Required(ErrorMessage = "Order must have an id", AllowEmptyStrings = false)]
        public string Id { get; set; }

        /// <summary>
        /// Username of user
        /// </summary>
        [Required(ErrorMessage = "Order must have an user", AllowEmptyStrings = false)]
        public string User { get; set; }

        /// <summary>
        /// Time when this order was created
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Items in this order
        /// </summary>
        [Required(ErrorMessage = "Order must have order items")]
        public List<OrderItem> Items { get; set; }
    }
}
