using System.Collections.Generic;

namespace Website.DAL.Contacts.Entities
{
    public class EntityCart : EntityBase
    {
        public float TotalPrice { get; set; }

        public IEnumerable<EntityProduct> Clothes { get; set; }
    }
}