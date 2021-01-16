using System.Collections.Generic;

namespace Website.DAL.Contacts.Entities
{
    public class EntityBasket : EntityBase
    {
        public float TotalPrice { get; set; }

        public IEnumerable<EntityProduct> Clothes { get; set; }
    }
}