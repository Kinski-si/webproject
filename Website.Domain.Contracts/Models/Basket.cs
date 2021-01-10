using System.Collections.Generic;

namespace Website.Domain.Contracts.Models
{
    public class Basket
    {
        public float TotalPrice { get; set; }

        public IEnumerable<Clothes> Clothes { get; set; }
    }
}