namespace Website.DAL.Contacts.Entities
{
    public class EntityClothes : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public string MaterialType { get; set; }

        public string Brand { get; set; }

        public string ClothesType { get; set; }

        public string Img { get; set; }

        public float Price { get; set; }

        public bool IsFavourite { get; set; }
    }
}