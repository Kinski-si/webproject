using System.Collections.Generic;

namespace Website.Domain.Contracts.Models
{
    public class Basket : ModelBase
    {
        public float TotalPrice { get; set; }
        
        public IEnumerable<Product> Clothes { get; set; }
    }
}   