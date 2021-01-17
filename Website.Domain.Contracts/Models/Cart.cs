using System.Collections.Generic;

namespace Website.Domain.Contracts.Models
{
    public class Cart : ModelBase
    {
        public float TotalPrice { get; set; }
        
        public IEnumerable<Product> Clothes { get; set; }
    }
}   