using System;
using System.ComponentModel.DataAnnotations;

namespace Website.DAL.Contacts
{
    public interface IClothes
    {
        [Key] [Required] Guid Id { get; set; }

        [Required(ErrorMessage = "Имя категории не может быть пустым")]
        [StringLength(20)]
        string Name { get; set; }

        [Required(ErrorMessage = "Описание не может быть пустым")]
        [StringLength(400)]
        string Description { get; set; }

        [Required(ErrorMessage = "Имя категории не может быть пустым")]
        [StringLength(20)]
        string CategoryName { get; set; }

        [Required(ErrorMessage = "Материал должен быть указан")]
        [StringLength(20)]
        string MaterialType { get; set; }

        [Required(ErrorMessage = "Производитель должен быть указан")]
        [StringLength(20)]
        string Brand { get; set; }

        [Required(ErrorMessage = "Тип одежды должен быть указан")]
        [StringLength(20)]
        string ClothesType { get; set; }

        float Price { get; set; }
        bool IsFavourite { get; set; }
    }
}