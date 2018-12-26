using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int AssignedById { get; set; }
        public DateTime Date { get; set; }
        public DateTime AssignedByDate { get; set; }
    }
}
