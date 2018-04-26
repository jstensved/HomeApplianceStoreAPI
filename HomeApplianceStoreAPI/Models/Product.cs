using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApplianceStoreAPI.Models
{
    public class Product
    {
        /// <summary>
        /// Id of product
        /// </summary>
        [Required]
        public string Id { get; set; }

        /// <summary>
        /// Price if product
        /// </summary>
        [Required]
        public float Price { get; set; }

        /// <summary>
        /// Name of product
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Categories this product belongs to
        /// </summary>
        [Required]
        public string[] Categories { get; set; }
    }
}
