using System.Collections.Generic;

namespace Website.Domain.Contracts.Models
{
    public class Category : ShopModelBase
    {
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public IEnumerable<Clothes> Clothes { get; set; }
    }
}