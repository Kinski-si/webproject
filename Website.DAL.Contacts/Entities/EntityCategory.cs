using System.Collections.Generic;

namespace Website.DAL.Contacts.Entities
{
    public class EntityCategory : EntityBase
    {
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public List<EntityProduct> Product { get; set; }
    }
}