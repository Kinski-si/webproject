using System;
using System.Collections.Generic;

namespace Website.Domain.Contracts.Models
{
    public class Basket
    {
        public Guid Id { get; set; }

        public float TotalPrice { get; set; }

        public IEnumerable<Clothes> Clothes { get; set; }
    }
}