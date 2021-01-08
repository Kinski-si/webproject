using System;
using Website.DAL.Contacts;

namespace Website.DAL.Implementations
{
    public class Clothes : IClothes
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string MaterialType { get; set; }
        public string Brand { get; set; }
        public string ClothesType { get; set; }
        public float Price { get; set; }
        public bool IsFavourite { get; set; }
    }
}