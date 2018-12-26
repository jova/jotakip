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
        public string Date { get; set; }
        public string AssignedByDate { get; set; }
        public int Count { get; set; }
    }
}
