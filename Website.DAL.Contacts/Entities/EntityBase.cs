using System;
using System.ComponentModel.DataAnnotations;

namespace Website.DAL.Contacts.Entities
{
    public class EntityBase : IEntity
    {
        [Key] public Guid Id { get; set; }
    }
}