using System;
using System.ComponentModel.DataAnnotations;

namespace Website.Domain.Contracts.Models
{
    public class Clothes : ShopModelBase
    {
        [Required(ErrorMessage = "Имя товара не может быть пустым")]
        [StringLength(20)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Описание не может быть пустым")]
        [StringLength(400)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Имя категории не может быть пустым")]
        [StringLength(20)]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Материал должен быть указан")]
        [StringLength(20)]
        public string MaterialType { get; set; }

        [Required(ErrorMessage = "Производитель должен быть указан")]
        [StringLength(20)]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Тип одежды должен быть указан")]
        [StringLength(20)]
        public string ClothesType { get; set; }

        [Required(ErrorMessage = "Товар должен иметь изображение")]
        public string Img { get; set; }

        public float Price { get; set; }

        public bool IsFavourite { get; set; }

        public Clothes()
        {
            Id = Guid.NewGuid();
        }
    }
}